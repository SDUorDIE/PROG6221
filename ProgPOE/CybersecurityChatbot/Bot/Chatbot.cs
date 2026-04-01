using System;
using CybersecurityChatbot.UI;

namespace CybersecurityChatbot.Bot
{
    public class Chatbot
    {
        private string userName;

        public Chatbot(string name)
        {
            userName = name;
        }

        public void StartChat()
        {
            Helper.Divider();
            Helper.TypingEffect($"Hello {userName}! 👋");

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("\nYou: ");
                Console.ResetColor();

                string input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Please enter something.");
                    continue;
                }

                if (input.ToLower() == "exit")
                {
                    Console.WriteLine("Goodbye! Stay safe online.");
                    break;
                }

                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Bot: ");
                Console.ResetColor();

                Helper.TypingEffect(GetResponse(input));
            }
        }

        private string GetResponse(string input)
        {
            input = input.ToLower();

            if (input.Contains("how are you"))
                return "I'm doing great and ready to help!";

            if (input.Contains("purpose"))
                return "I help you stay safe online.";

            if (input.Contains("password"))
                return "Use strong passwords with letters, numbers, and symbols.";

            if (input.Contains("phishing"))
                return "Avoid clicking suspicious links or emails.";

            if (input.Contains("browsing"))
                return "Always use secure websites (https).";

            return "I didn’t quite understand that. Could you rephrase?";
        }
    }
}