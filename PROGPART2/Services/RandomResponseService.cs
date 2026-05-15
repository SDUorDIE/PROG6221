using System;
using System.Collections.Generic;

namespace CybersecurityChatbotGUI.Services
{
    //static class
    public static class RandomResponseService
    {
        //single shared random instance
        private static Random random = new Random();

        //aacepts lists of strings and returns a random index 
        public static string GetRandomResponse(List<string> responses)
        {
            //returns a value from 0 to n-1
            return responses[random.Next(responses.Count)];
        }
    }
}