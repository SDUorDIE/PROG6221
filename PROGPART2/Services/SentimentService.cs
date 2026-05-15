namespace CybersecurityChatbotGUI.Services
{
    public class SentimentService
    {
        public string DetectSentiment(string input)
        {
            input = input.ToLower();

            if (input.Contains("worried") ||
                input.Contains("scared") ||
                input.Contains("nervous"))
            {
                return "worried";
            }

            if (input.Contains("confused") ||
                input.Contains("frustrated"))
            {
                return "frustrated";
            }

            if (input.Contains("curious") ||
                input.Contains("interested"))
            {
                return "curious";
            }

            return "neutral";
        }
    }
}