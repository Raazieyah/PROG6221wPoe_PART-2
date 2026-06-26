using System;
using System.Collections.Generic;
using System.Text;

namespace CyberSecurityChatbot
{
    public class ActivityLogger
    {
       
        
        private List<string> _log = new List<string>();

        public void Log(string action)// log string


        {
            
            string entry = $"[{DateTime.Now:HH:mm}] {action}";
            _log.Add(entry);
        }

        //get recent log
        public string GetRecentLog(int count = 10)
        {
            if (_log.Count == 0)
            {
                return "Here's a summary of recent actions:\nNo recent actions found.";
            }

            
            int itemsToTake = Math.Min(count, _log.Count);
            var recentEntries = _log.Skip(_log.Count - itemsToTake).ToList();

            return FormatNumberedList(recentEntries);
        }

        // getting full logh
        public string GetFullLog()
        {
            return FormatNumberedList(_log);
        }

        // get count method
        public int GetCount()
        {
            return _log.Count;
        }

        // Helper method to keep lists formatted cleanly with sequence indexing numbers
        private string FormatNumberedList(List<string> entries)
        {
            string result = "Here's a summary of recent actions:\n";
            for (int i = 0; i < entries.Count; i++)
            {
                result += $"   {i + 1}. {entries[i]}\n";
            }
            return result.TrimEnd();
           
        }
        /
        public string HandleLogRequest(string userMessage)
        {
            string lowerMessage = userMessage.ToLower().Trim();

           
            if (lowerMessage == "show activity log" || lowerMessage == "what have you done for me?")
            {
                
                string output = myLogger.GetRecentLog(10);

                
                if (myLogger.GetCount() > 10)
                {
                    output += "\n\n[Type 'show more' or click the Show More button to view full history.]";
                }

                return output;
            }

            //add correction for logger
            if (lowerMessage == "show more")
            {
                if (myLogger.GetCount() > 10)
                {
                    return myLogger.GetFullLog();
                }
                return "No further historic entries to display.";
            }

            return "Message context unrecognized by log parsing module.";
        }

    }


}
}
