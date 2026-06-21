using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CybersecurityChatbotGUI.Models
{
    public class QuizQuestion
    {
        public string Question { get; set; }

        public string[] Options { get; set; }

        public string CorrectAnswer { get; set; }

        public string Explanation { get; set; }
    }
}
