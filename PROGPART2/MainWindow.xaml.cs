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
        private ChatbotService chatbot;

        public MainWindow()
        {
            InitializeComponent();

            chatbot = new ChatbotService();

            AddMessage("Bot", "Welcome to the Cybersecurity Awareness Bot");
        }

        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            string input = MessageTextBox.Text;

            if (string.IsNullOrWhiteSpace(input))
                return;

            AddMessage("You", input);

            string response = chatbot.GetResponse(input);

            AddMessage("Bot", response);

            MessageTextBox.Clear();
        }

        private void AddMessage(string sender, string message)
        {
            ChatListBox.Items.Add($"{sender}: {message}");
            ChatListBox.ScrollIntoView(ChatListBox.Items[ChatListBox.Items.Count - 1]);
        }
    }
}