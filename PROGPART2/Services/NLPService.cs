using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CybersecurityChatbotGUI.Services
{
    public class NLPService
    {
        public string DetectIntent(string input)
        {
            input = input.ToLower();

            if (input.Contains("add task") ||
                input.Contains("create task") ||
                input.Contains("new task"))
            {
                return "ADD_TASK";
            }

            if (input.Contains("show tasks") ||
                input.Contains("view tasks"))
            {
                return "VIEW_TASKS";
            }

            if (input.Contains("quiz") ||
                input.Contains("start game"))
            {
                return "START_QUIZ";
            }

            return "UNKNOWN";
        }
    }
}
