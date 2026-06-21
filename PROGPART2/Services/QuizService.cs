using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CybersecurityChatbotGUI.Models;

namespace CybersecurityChatbotGUI.Services
{
    public class QuizService
    {
        public List<QuizQuestion> Questions { get; private set; }

        public int CurrentQuestion { get; private set; }

        public int Score { get; private set; }

        public QuizService()
        {
            Questions = new List<QuizQuestion>()
            {
                new QuizQuestion
                {
                    Question = "What is phishing?",
                    Options = new[]
                    {
                        "A scam email",
                        "An antivirus",
                        "A firewall",
                        "A browser"
                    },
                    CorrectAnswer = "A scam email",
                    Explanation = "Phishing tries to steal information."
                },

                new QuizQuestion
                {
                    Question = "True or False: Use the same password everywhere.",
                    Options = new[]
                    {
                        "True",
                        "False"
                    },
                    CorrectAnswer = "False",
                    Explanation = "Every account should have a unique password."
                },

                new QuizQuestion
                {
                    Question = "What does a firewall do?",
                    Options = new[]
                    {
                        "Blocks unauthorized access",
                        "Scans for viruses",
                        "Manages passwords",
                        "Encrypts data"
                    },
                    CorrectAnswer = "Blocks unauthorized access",
                    Explanation = "Firewalls protect your network from intruders."
                },

                    new QuizQuestion
                    {
                        Question = "What is a VPN?",
                        Options = new[]
                        {
                            "A virtual private network",
                            "A virus protection program",
                            "A video conferencing tool",
                            "A version control system"
                        },
                        CorrectAnswer = "A virtual private network",
                        Explanation = "A VPN creates a secure connection over the internet."
                    },

                    new QuizQuestion
                    {
                        Question = "True or False: Public Wi-Fi is always safe to use.",
                        Options = new[]
                        {
                            "True",
                            "False"
                        },
                        CorrectAnswer = "False",
                        Explanation = "Public Wi-Fi can be insecure and should be used with caution."
                    },

                    new QuizQuestion
                    {
                        Question = "What is two-factor authentication?",
                        Options = new[]
                        {
                            "A security process that requires two forms of identification",
                            "A type of malware",
                            "A method of encrypting data",
                            "A software update"
                        },
                        CorrectAnswer = "A security process that requires two forms of identification",
                        Explanation = "Two-factor authentication adds an extra layer of security to your account."
                    },

                    new QuizQuestion
                    {
                        Question = "What is ransomware?",
                        Options = new[]
                        {
                            "A type of malware that encrypts files and demands payment",
                            "A software update",
                            "A security protocol",
                            "A type of firewall"
                        },
                        CorrectAnswer = "A type of malware that encrypts files and demands payment",
                        Explanation = "Ransomware can lock you out of your own data until you pay a ransom."
                    },

                    new QuizQuestion
                    {
                        Question = "True or False: It's safe to click on links from unknown senders.",
                        Options = new[]
                        {
                            "True",
                            "False"
                        },
                        CorrectAnswer = "False",
                        Explanation = "Links from unknown senders can lead to phishing sites or malware."
                    },

                    new QuizQuestion
                    {
                        Question = "What is the best way to protect your online accounts?",
                        Options = new[]
                        {
                            "Use strong, unique passwords and enable two-factor authentication",
                            "Share your passwords with friends",
                            "Use the same password for all accounts",
                            "Avoid updating software"
                        },
                        CorrectAnswer = "Use strong, unique passwords and enable two-factor authentication",
                        Explanation = "Using strong, unique passwords and enabling two-factor authentication adds an extra layer of security to your accounts."
                    },

                        new QuizQuestion
                        {
                            Question = "What is malware?",
                            Options = new[]
                            {
                                "Malicious software designed to harm or exploit devices",
                                "A type of firewall",
                                "A security protocol",
                                "A software update"
                            },
                            CorrectAnswer = "Malicious software designed to harm or exploit devices",
                            Explanation = "Malware is malicious software designed to harm or exploit devices."
                        },

                        new QuizQuestion
                        {
                            Question = "True or False: It's safe to download attachments from unknown emails.",
                            Options = new[]
                            {
                                "True",
                                "False"
                            },
                            CorrectAnswer = "False",
                            Explanation = "Attachments from unknown emails can contain malware or viruses."
                        },

                        new QuizQuestion
                        {
                            Question = "What is encryption?",
                            Options = new[]
                            {
                                "The process of converting data into a coded form to prevent unauthorized access",
                                "A type of firewall",
                                "A security protocol",
                                "A software update"
                            },
                            CorrectAnswer = "The process of converting data into a coded form to prevent unauthorized access",
                            Explanation = "Encryption is the process of converting data into a coded form to prevent unauthorized access."
                        },

                        new QuizQuestion
                        {
                            Question = "What is a strong password?",
                            Options = new[]
                            {
                                "A password that is at least 12 characters long and includes a mix of letters, numbers, and symbols",
                                "A password that is easy to remember",
                                "A password that is the same as your username",
                                "A password that is short and simple"
                            },
                            CorrectAnswer = "A password that is at least 12 characters long and includes a mix of letters, numbers, and symbols",
                            Explanation = "A strong password is at least 12 characters long and includes a mix of letters, numbers, and symbols."
                        }
            };
        }

        public bool CheckAnswer(string answer)
        {
            bool correct =
                Questions[CurrentQuestion].CorrectAnswer == answer;

            if (correct)
                Score++;

            CurrentQuestion++;

            return correct;
        }
    }
}
