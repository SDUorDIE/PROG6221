using System;
using System.Threading;

namespace CybersecurityChatbot.UI
{
    public class Helper
    {
        public static void ShowLogo()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.WriteLine(@"
   ██████╗ ██╗   ██╗██████╗ ███████╗██████╗ 
  ██╔════╝ ██║   ██║██╔══██╗██╔════╝██╔══██╗
  ██║  ███╗██║   ██║██████╔╝█████╗  ██████╔╝
  ██║   ██║██║   ██║██╔══██╗██╔══╝  ██╔══██╗
  ╚██████╔╝╚██████╔╝██║  ██║███████╗██║  ██║
   ╚═════╝  ╚═════╝ ╚═╝  ╚═╝╚══════╝╚═╝  ╚═╝

        CYBERSECURITY AWARENESS BOT
");

            Console.ResetColor();
        }

        public static void TypingEffect(string message)
        {
            foreach (char c in message)
            {
                Console.Write(c);
                Thread.Sleep(30);
            }
            Console.WriteLine();
        }

        public static void Divider()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("============================================");
            Console.ResetColor();
        }
    }
}