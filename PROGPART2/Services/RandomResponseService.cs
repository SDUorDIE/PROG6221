using System;
using System.Collections.Generic;

namespace CybersecurityChatbotGUI.Services
{
    public static class RandomResponseService
    {
        private static Random random = new Random();

        public static string GetRandomResponse(List<string> responses)
        {
            return responses[random.Next(responses.Count)];
        }
    }
}