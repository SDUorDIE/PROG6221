using System.Windows;
using CybersecurityChatbotGUI.Services;
using CybersecurityChatbotGUI.Models;

namespace CybersecurityChatbotGUI
{
    public partial class MainWindow : Window
    {
        //Main chatbot service
        private ChatbotService chatbot = new ChatbotService();

        //Handles task management
        private TaskService taskService = new TaskService();

        //Handles quiz functionality
        private QuizService quizService = new QuizService();

        //Records user activities
        private ActivityLogService logService = new ActivityLogService();

        //Constructor
        public MainWindow()
        {
            InitializeComponent();

            //Display welcome message
            AddMessage("Bot", "Welcome to the Cybersecurity Awareness Bot!");

            //Load first quiz question
            LoadQuestion();
        }

        //Handles sending chatbot messages
        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            string input = MessageTextBox.Text;

            //Prevent empty messages
            if (string.IsNullOrWhiteSpace(input))
                return;

            //Display user message
            AddMessage("You", input);

            //Generate chatbot response
            string response = chatbot.GetResponse(input);

            //Display bot response
            AddMessage("Bot", response);

            //Clear textbox after sending
            MessageTextBox.Clear();
        }

        //Adds messages to chat window
        private void AddMessage(string sender, string message)
        {
            ChatListBox.Items.Add($"{sender}: {message}");

            //Auto-scroll to newest message
            ChatListBox.ScrollIntoView(
                ChatListBox.Items[ChatListBox.Items.Count - 1]
            );
        }

        //Handles adding new cybersecurity tasks
        private void AddTask_Click(object sender, RoutedEventArgs e)
        {
            //Creates new task object
            TaskItem task = new TaskItem()
            {
                Id = TaskGrid.Items.Count + 1,
                Title = TaskTitleTextBox.Text,
                Description = TaskDescriptionTextBox.Text,
                ReminderDate = TaskDatePicker.SelectedDate ?? DateTime.Now,
                IsCompleted = false
            };

            //Saves task
            taskService.AddTask(task);

            //Refresh task grid
            TaskGrid.ItemsSource = null;
            TaskGrid.ItemsSource = taskService.GetTasks();

            //Log activity
            logService.AddLog($"Task Added: {task.Title}");

            //Refresh activity log display
            ActivityLogListBox.ItemsSource = null;
            ActivityLogListBox.ItemsSource = logService.GetLogs();

            //Clear input fields
            TaskTitleTextBox.Clear();
            TaskDescriptionTextBox.Clear();
        }

        //Loads current quiz question
        private void LoadQuestion()
        {
            //Checks if quiz is complete
            if (quizService.CurrentQuestion >= quizService.Questions.Count)
            {
                QuestionText.Text =
                    $"Quiz Finished! Score: {quizService.Score}/{quizService.Questions.Count}";

                QuizOptions.ItemsSource = null;

                return;
            }

            //Gets current question
            var question =
                quizService.Questions[quizService.CurrentQuestion];

            //Displays question text
            QuestionText.Text = question.Question;

            //Displays answer choices
            QuizOptions.ItemsSource = question.Options;
        }

        //Handles quiz answer submission
        private void SubmitAnswer_Click(object sender, RoutedEventArgs e)
        {
            //Ensures an answer is selected
            if (QuizOptions.SelectedItem == null)
                return;

            //Get selected answer
            string answer =
                QuizOptions.SelectedItem.ToString();

            //Checks if answer is correct
            bool correct =
                quizService.CheckAnswer(answer);

            //Displays feedback
            QuizFeedback.Text =
                correct ? "Correct!" : "Incorrect!";

            //Logs activity
            logService.AddLog("Quiz Question Answered");

            //Refresh activity log
            ActivityLogListBox.ItemsSource = null;
            ActivityLogListBox.ItemsSource = logService.GetLogs();

            //Loads next question
            LoadQuestion();
        }
    }
}