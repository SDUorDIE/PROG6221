using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CybersecurityChatbotGUI.Models
{
    //Represents a cybersecurity task
    public class TaskItem
    {
        //Unique identifier
        public int Id { get; set; }

        //Task title
        public string Title { get; set; }

        //Task description
        public string Description { get; set; }

        //Reminder date
        public DateTime ReminderDate { get; set; }

        //Completion status
        public bool IsCompleted { get; set; }

        //Creation timestamp
        public DateTime CreatedDate { get; set; }
    }
}