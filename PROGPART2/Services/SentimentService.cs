namespace CybersecurityChatbotGUI.Services
{
    public class SentimentService
    {
        //analyses user message and returns emotional category
        public string DetectSentiment(string input)
        {
            input = input.ToLower();

            //checks for any keywords related to worry
            if (input.Contains("worried") ||
                input.Contains("scared") ||
                input.Contains("nervous"))
            {
                return "worried";
            }

            //checks for frustration
            if (input.Contains("confused") ||
                input.Contains("frustrated"))
            {
                return "frustrated";
            }

            //checks for curiosity
            if (input.Contains("curious") ||
                input.Contains("interested"))
            {
                return "curious";
            }

            //default sentiment
            return "neutral";
        }
    }
}