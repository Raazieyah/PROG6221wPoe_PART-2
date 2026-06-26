using System;
using System.Collections.Generic;
using System.Media;
using System.Text;

namespace CyberSecurityChatbot
{
    public class ChatBot
    {
        private KeywordResponder keywords;
        private SentimentDetector sentiment;
        private MemoryStore _memory;
        private bool _awaitingName = true;
        private string _lastTopic;

        public void LoadAsciiArt()
        {
            Console.WriteLine(@"  ___  _  _  ____  ____  ____  ____  _____  ____ 
 / __)( \/ )(  _ \( ___)(  _ \(  _ \(  _  )(_  _)
( (__  \  /  ) _ < )__)  )   / ) _ < )(_)(   )(  
 \___) (__) (____/(____)(_)\_)(____/(_____) (__) ");
        }

        public void PlayVoiceGreeting()
        {
            SoundPlayer player = new SoundPlayer("C:\\Users\\david\\source\\repos\\CyberSecurityChatbot\\CyberSecurityChatbot\\chatbotGreeting.wav");
            player.Play();
        }

        public string GetGreeting()
        {
            return "Hello! What is your name?";
        }

        //Order1-9 + What to check and do
        



        }
public class ChatbotManager //--4.1 4.2
        {
// Lists to log recent actions for the "Show log" intent
        private List<string> _actionLog = new List<string>();

        // Keywords and Phrases dictionaries defined in Step 4.2
        private List<string> _addTaskKeywords = new List<string> { "add task", "add a task", "create task", "i need to", "enable", "set up" };
        private List<string> _setReminderKeywords = new List<string> { "remind me", "reminder", "set a reminder", "remind me to", "don't forget" };
        private List<string> _startQuizKeywords = new List<string> { "start quiz", "take quiz", "test my knowledge", "quiz me", "play the game" };
        private List<string> _showLogKeywords = new List<string> { "show activity log", "what have you done", "what did you do", "show log", "recent actions" };
        private List<string> _securityKeywords = new List<string> { "password", "phishing", "privacy", "scam", "malware", "2fa" };

        public string ProcessMessage(string userInput)
        {
            // Convert to lowercase to make parsing flexible and case-insensitive
            string lowerInput = userInput.ToLower().Trim();

            // 1. Detect "Show log" Intent
            foreach (string keyword in _showLogKeywords)
            {
                if (lowerInput.Contains(keyword))
                {
                    return GetActivityLogResponse();
                }
            }

            // 2. Detect "Set reminder" Intent
            foreach (string keyword in _setReminderKeywords)
            {
                if (lowerInput.Contains(keyword))
                {
                    // Capture everything after the keyword phrases for dynamic responses if needed
                    _actionLog.Add("Reminder set for 'Update my password' tomorrow.");
                    return "Reminder set for 'Update my password' on tomorrow's date.";
                }
            }

            // 3. Detect "Add task" Intent
            foreach (string keyword in _addTaskKeywords)
            {
                if (lowerInput.Contains(keyword))
                {
                    _actionLog.Add("Task added: 'Enable two-factor authentication' (no reminder set).");
                    return "Task added: 'Enable two-factor authentication.'\nWould you like to set a reminder for this task?";
                }
            }

            // 4. Detect "Start quiz" Intent
            foreach (string keyword in _startQuizKeywords)
            {
                if (lowerInput.Contains(keyword))
                {
                    return "Starting the Cybersecurity Quiz now! Good luck!";
                }
            }

            // 5. Detect "Cybersecurity topics" Intent
            foreach (string keyword in _securityKeywords)
            {
                if (lowerInput.Contains(keyword))
                {
                    return $"I noticed you mentioned '{keyword}'. Keeping your data safe is essential! How can I assist you with this topic?";
                }
            }

            // Fallback response if no keywords match
            return "I did not quite understand that. Could you please rephrase your request?";
        }

        private string GetActivityLogResponse()
        {
            if (_actionLog.Count == 0)
            {
                return "Here's a summary of recent actions:\nNo recent actions found.";
            }

            string response = "Here's a summary of recent actions:\n";
            for (int i = 0; i < _actionLog.Count; i++)
            {
                response += $"{i + 1}. {_actionLog[i]}\n";
            }
            return response.TrimEnd();
        }
        

        public string ProcessInput(string userInput)
        {
            /
            string input = userInput.ToLower().Trim();

           //checing for task intent
            if (input.Contains("add task") || input.Contains("add a task") ||
                input.Contains("create task") || input.Contains("enable"))
            {
                
                string taskDescription = ExtractTaskName(userInput);

                
                TaskManager.AddTask(taskDescription);

                
                ActivityLogger.LogAction($"Task added: '{taskDescription}' (no reminder set).");

                // returining confirmation
                return $"Task added: '{taskDescription}.'\nWould you like to set a reminder for this task?";
            }

            //reminder intent
            if (input.Contains("remind me") || input.Contains("reminder") ||
                input.Contains("set a reminder") || input.Contains("don't forget"))
            {
                ActivityLogger.LogAction("Reminder set for 'Update my password' tomorrow.");
                return "Reminder set for 'Update my password' on tomorrow's date.";
            }

            //checking for quiz intent
            if (input.Contains("start quiz") || input.Contains("take quiz") ||
                input.Contains("quiz me") || input.Contains("test knowledge"))
            {
                ActivityLogger.LogAction("User initiated quiz mode.");
                return "Starting the Cybersecurity Quiz now! Good luck!";
            }

            //checking for log intent
            if (input.Contains("show activity log") || input.Contains("show log") ||
                input.Contains("what did you do") || input.Contains("recent actions"))
            {
                return ActivityLogger.GetRecentLog();
            }

            
            
        }

    }


}


