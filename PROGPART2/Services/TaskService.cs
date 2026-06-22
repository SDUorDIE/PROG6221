using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CybersecurityChatbotGUI.Models;

namespace CybersecurityChatbotGUI.Services
{
    //Handles task management operations
    public class TaskService
    {
        private List<TaskItem> tasks = new();

        //Add task
        public void AddTask(TaskItem task)
        {
            tasks.Add(task);
        }

        //Return all tasks
        public List<TaskItem> GetTasks()
        {
            return tasks;
        }

        //Mark task completed
        public void CompleteTask(int id)
        {
            var task = tasks.FirstOrDefault(t => t.Id == id);

            if (task != null)
            {
                task.IsCompleted = true;
            }
        }

        //Delete task
        public void DeleteTask(int id)
        {
            var task = tasks.FirstOrDefault(t => t.Id == id);

            if (task != null)
            {
                tasks.Remove(task);
            }
        }

        //Get upcoming reminders
        public List<TaskItem> GetUpcomingTasks()
        {
            return tasks.Where(
                t => t.ReminderDate.Date <= DateTime.Today.AddDays(3)
            ).ToList();
        }
    }
}