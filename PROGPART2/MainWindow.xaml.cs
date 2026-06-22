using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CybersecurityChatbotGUI.Services;
using CybersecurityChatbotGUI.Models;

namespace CybersecurityChatbotGUI
{
   
    public partial class MainWindow : Window
    {
        private ChatbotService chatbot = new ChatbotService();

        private TaskService taskService = new TaskService();

        private QuizService quizService = new QuizService();

        private ActivityLogService logService = new ActivityLogService();


        public MainWindow()
        {
            InitializeComponent();

            chatbot = new ChatbotService();

            AddMessage("Bot", "Welcome to the Cybersecurity Awareness Bot");

            LoadQuestion();
        }

        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            string input = MessageTextBox.Text;

            ChatListBox.Items.Add("You: " + input);

            string response = chatbot.GetResponse(input);

            ChatListBox.Items.Add("Bot: " + response);

            MessageTextBox.Clear();
        }

        private void AddMessage(string sender, string message)
        {
            ChatListBox.Items.Add($"{sender}: {message}");
            ChatListBox.ScrollIntoView(ChatListBox.Items[ChatListBox.Items.Count - 1]);
        }

        private void AddTask_Click(object sender, RoutedEventArgs e)
        {
            TaskItem task = new TaskItem()
            {
                Id = TaskGrid.Items.Count + 1,
                Title = TaskTitleTextBox.Text,
                Description = TaskDescriptionTextBox.Text,
                ReminderDate = TaskDatePicker.SelectedDate ?? DateTime.Now,
                IsCompleted = false
            };

            taskService.AddTask(task);

            TaskGrid.ItemsSource = null;
            TaskGrid.ItemsSource = taskService.GetTasks();

            logService.AddLog($"Task Added: {task.Title}");

            ActivityLogListBox.ItemsSource = null;
            ActivityLogListBox.ItemsSource = logService.GetLogs();
        }

        private void LoadQuestion()
        {
            if (quizService.CurrentQuestion >=
                quizService.Questions.Count)
            {
                QuestionText.Text =
                    $"Quiz Finished! Score: {quizService.Score}/{quizService.Questions.Count}";

                QuizOptions.ItemsSource = null;

                return;
            }

            var question =
                quizService.Questions[quizService.CurrentQuestion];

            QuestionText.Text = question.Question;

            QuizOptions.ItemsSource = question.Options;
        }

        private void SubmitAnswer_Click(object sender, RoutedEventArgs e)
        {
            if (QuizOptions.SelectedItem == null)
                return;

            string answer =
                QuizOptions.SelectedItem.ToString();

            bool correct =
                quizService.CheckAnswer(answer);

            QuizFeedback.Text =
                correct ? "Correct!" : "Incorrect!";

            LoadQuestion();

            logService.AddLog("Quiz Question Answered");

            ActivityLogListBox.ItemsSource = null;
            ActivityLogListBox.ItemsSource = logService.GetLogs();
        }
    }
}