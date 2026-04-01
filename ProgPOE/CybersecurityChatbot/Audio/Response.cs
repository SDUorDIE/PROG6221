using System;

namespace CyberSecurityBot.Services
{
    public class ResponseHandler
    {
        public static string GetResponse(string input)
        {
            input = input.ToLower();

            if (input.Contains("how are you"))
                return "I'm functioning perfectly and ready to help you stay safe online!";

            if (input.Contains("purpose"))
                return "My purpose is to educate you about cybersecurity and help you avoid online threats.";

            if (input.Contains("password"))
                return "Use strong passwords with a mix of uppercase, lowercase, numbers, and symbols.";

            if (input.Contains("phishing"))
                return "Be cautious of emails asking for personal info. Always verify the sender.";

            if (input.Contains("browsing"))
                return "Always browse secure websites (https) and avoid suspicious links.";

            if (input.Contains("help"))
                return "You can ask me about passwords, phishing, safe browsing, or my purpose.";

            return "I didn’t quite understand that. Could you rephrase?";
        }
    }
}