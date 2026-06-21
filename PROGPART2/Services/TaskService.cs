using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CybersecurityChatbotGUI.Models;

namespace CybersecurityChatbotGUI.Services
{
    public class TaskService
    {
        private List<TaskItem> tasks = new();

        public void AddTask(TaskItem task)
        {
            tasks.Add(task);
        }

        public List<TaskItem> GetTasks()
        {
            return tasks;
        }

        public void CompleteTask(int id)
        {
            var task = tasks.FirstOrDefault(t => t.Id == id);

            if (task != null)
                task.IsCompleted = true;
        }

        public void DeleteTask(int id)
        {
            tasks.RemoveAll(t => t.Id == id);
        }
    }
}