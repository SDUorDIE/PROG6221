using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CybersecurityChatbotGUI.Services
{
    //Handles natural language processing for user input
    public class NLPService
    {
        public string DetectIntent(string input)
        {
            input = input.ToLower();

            //Detects if the user wants to add a task
            if (input.Contains("add task") ||
                input.Contains("create task") ||
                input.Contains("new task"))
            {
                return "ADD_TASK";
            }

            //Detects if the user wants to view tasks
            if (input.Contains("show tasks") ||
                input.Contains("view tasks"))
            {
                return "VIEW_TASKS";
            }

            //quiz 
            if (input.Contains("quiz") ||
                input.Contains("start game"))
            {
                return "START_QUIZ";
            }

            //Detects if the user wants to view activity log
            if (input.Contains("activity") ||
                input.Contains("show log"))
            {
                return "SHOW_LOG";
            }

            return "UNKNOWN";
        }
    }
}
