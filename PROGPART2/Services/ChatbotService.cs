using System.Collections.Generic;

namespace CybersecurityChatbotGUI.Services
{
    public class ChatbotService
    {
        //tracks last matched topic
        private string currentTopic = "";

        //composition
        private MemoryService memoryService = new MemoryService();
        private SentimentService sentimentService = new SentimentService();

        //maps keyword to responses
        private Dictionary<string, List<string>> responses =
            new Dictionary<string, List<string>>()
        {
            {
                "password",
                new List<string>()
                {
                    "Use strong passwords with symbols and numbers.",
                    "Never reuse passwords across accounts.",
                    "Use a password manager for better security."
                }
            },

            {
                "phishing",
                new List<string>()
                {
                    "Avoid suspicious links in emails.",
                    "Verify sender addresses carefully.",
                    "Phishing scams often create urgency."
                }
            },

            {
                "privacy",
                new List<string>()
                {
                    "Review your privacy settings regularly.",
                    "Avoid sharing too much online.",
                    "Protect personal information carefully."
                }
            }
        };

        public string GetResponse(string input)
        {
            input = input.ToLower();

            //checks emotional tone
            string sentiment = sentimentService.DetectSentiment(input);

            if (sentiment == "worried")
            {
                return "It is understandable to feel worried about online threats. Never share personal information through suspicious emails.";
            }

            if (input.Contains("i like privacy"))
            {
                memoryService.FavouriteTopic = "privacy";

                return "Great! I will remember that you are interested in privacy.";
            }
            
            //follow up prompts
            if (input.Contains("tell me more") ||
                input.Contains("another tip"))
            {
                if (responses.ContainsKey(currentTopic))
                {
                    //fetch a random response 
                    return RandomResponseService.GetRandomResponse(
                        responses[currentTopic]
                    );
                }
            }

            foreach (var keyword in responses.Keys)
            {
                if (input.Contains(keyword))
                {
                    currentTopic = keyword;

                    return RandomResponseService.GetRandomResponse(
                        responses[keyword]
                    );
                }
            }

            if (memoryService.FavouriteTopic == "privacy")
            {
                return "As someone interested in privacy, remember to check your account permissions regularly.";
            }

            return "I didn't quite understand that. Could you rephrase?";
        }
    }
}