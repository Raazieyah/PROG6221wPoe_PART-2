using System;
using System.Collections.Generic;
using System.Text;

namespace CyberSecurityChatbot
{
    public class MemoryStore // internal = public
    {


       

        // stores basic information about the user
        public string UserName { get; set; }
        public string FavouriteTopic { get; set; }

        
        private Dictionary<string, string> _storage = new Dictionary<string, string>();

        // saves information into our dictionary
        public void Store(string key, string value)
        {
            _storage[key] = value;
        }

        // looks up information =  doesn't exist = "null" 
        public string Recall(string key)
        {
            if (_storage.ContainsKey(key))
            {
                return _storage[key];
            }
            else
            {
                return null;
            }
        }

        // Creates a greeting based on whether we know their favorite topic
        public string GetPersonalisedOpener()
        {
            if (string.IsNullOrEmpty(FavouriteTopic))
            {
                return "Hello " + UserName + "!";
            }
            else
            {
                return "As someone interested in " + FavouriteTopic + ", hello " + UserName + "!";
            }
        }

        public class UserMemory // storing favourite topic
        {
            public string FavouriteTopic { get; set; }
        }

       
        public void ProcessInput()
        {
           

            var memory = new UserMemory();

            string userInput = "I am interested in coding";

            
            if (userInput.Contains("I am interested in", StringComparison.OrdinalIgnoreCase))
            {
                string topic = userInput.Replace("I am interested in", "", StringComparison.OrdinalIgnoreCase).Trim();
                memory.FavouriteTopic = topic;
            }
        }


    }
}
