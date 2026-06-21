using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CybersecurityChatbotGUI.Services
{
    public class ActivityLogService
    {
        private List<string> logs = new();

        public void AddLog(string action)
        {
            logs.Add(
                $"[{DateTime.Now:HH:mm}] {action}"
            );
        }

        public List<string> GetLogs()
        {
            return logs.TakeLast(10).ToList();
        }
    }
}
