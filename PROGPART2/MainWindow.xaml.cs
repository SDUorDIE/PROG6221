using System.Windows;
using CybersecurityChatbotGUI.Services;
using CybersecurityChatbotGUI.Models;

namespace CybersecurityChatbotGUI
{
    public partial class MainWindow : Window
    {
        //Main chatbot service
        private ChatbotService chatbot = new ChatbotService();

        //Handles quiz functionality
        private QuizService quizService = new QuizService();

        //Records user activities
        private ActivityLogService logService = new ActivityLogService();

        //Handles MongoDB operations
        private MongoDbService mongoDbService =
            new MongoDbService();

        private NLPService nlpService = new NLPService();

        //Constructor
        public MainWindow()
        {
            InitializeComponent();

            //Display welcome message
            AddMessage("Bot", "Welcome to the Cybersecurity Awareness Bot!");

            //Load first quiz question
            LoadQuestion();

            //Load tasks from MongoDB
            LoadTasks();
        }

        //Handles sending chatbot messages
        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            string input = MessageTextBox.Text;
            string intent = nlpService.DetectIntent(input);

            switch (intent)

            {

                case "VIEW_TASKS":

                    AddMessage("Bot",

                        $"You currently have {mongoDbService.GetTasks().Count} task(s).");

                    MessageTextBox.Clear();

                    return;

                case "START_QUIZ":

                    AddMessage("Bot",

                        "Open the Quiz tab to start the quiz.");

                    MessageTextBox.Clear();

                    return;

                case "SHOW_LOG":

                    AddMessage("Bot",

                        "Open the Activity Log tab to view recent activities.");

                    MessageTextBox.Clear();

                    return;

            }

            if (string.IsNullOrWhiteSpace(input))

                return;

            AddMessage("You", input);

            string response = chatbot.GetResponse(input);

            AddMessage("Bot", response);

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
                CreatedDate = DateTime.Now,
                IsCompleted = false
            };

            //Saves task to MongoDB
            mongoDbService.AddTask(task);
            LoadTasks();

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
                double percentage =
                     (double)quizService.Score /
                     quizService.Questions.Count * 100;

                QuestionText.Text =
                    $"Quiz Complete! Score: {quizService.Score}/{quizService.Questions.Count} ({percentage:F0}%)";

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

            if (correct)
            {
                logService.AddLog("Correct Answer");
            }
            else
            {
                logService.AddLog("Incorrect Answer");
            }

            //Refresh activity log
            ActivityLogListBox.ItemsSource = null;
            ActivityLogListBox.ItemsSource = logService.GetLogs();

            //Loads next question
            LoadQuestion();
        }
             //Handles task completion
            private void CompleteTask_Click(object sender, RoutedEventArgs e)
        {
            if (TaskGrid.SelectedItem is TaskItem task)
            {
                mongoDbService.CompleteTask(task.Id);
                LoadTasks();

                logService.AddLog($"Task Completed: {task.Title}");

                RefreshLog();
            }
        }

        private void DeleteTask_Click(object sender, RoutedEventArgs e)
        {
            if (TaskGrid.SelectedItem is TaskItem task)
            {
                mongoDbService.DeleteTask(task.Id);
                LoadTasks();

                logService.AddLog($"Task Deleted: {task.Title}");

                RefreshLog();
            }
        }

        private void RefreshLog()
        {
            ActivityLogListBox.ItemsSource = null;
            ActivityLogListBox.ItemsSource = logService.GetLogs();
        }

        private void LoadTasks()
        {
            TaskGrid.ItemsSource = null;

            TaskGrid.ItemsSource =
                mongoDbService.GetTasks();
        }
    }
}