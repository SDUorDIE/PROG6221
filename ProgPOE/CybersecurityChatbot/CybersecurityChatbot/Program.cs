using System;
using CybersecurityChatbot.Audio;
using CybersecurityChatbot.Bot;
using CybersecurityChatbot.UI;

namespace CybersecurityChatbot
{
    class Program
    {
        static void Main()
        {
            Console.Title = "Cybersecurity Awareness Bot";

            AudioPlayer.PlayGreeting();

            Helper.ShowLogo();

            Console.Write("Enter your name: ");
            string name = Console.ReadLine();

            while (string.IsNullOrWhiteSpace(name))
            {
                Console.Write("Enter a valid name: ");
                name = Console.ReadLine();
            }

            Chatbot bot = new Chatbot(name);
            bot.StartChat();
        }
    }
}