using System;
using System.Collections.Generic;
using System.Text;


namespace CyberSecurityChatbot
{
    public class KeywordResponder // class changed from internal to public
    {
        


    private Dictionary<string, List<string>> responses;
    private Random _random = new Random();

    public KeywordResponder() { //keep key words in lower bcase for users + part 1 chatbot responses copiued over
                                // Initialize and populate the dictionary
            responses = new Dictionary<string, List<string>> {
                { "password", new List<string> { "Make sure to enable two-factor authentication on all accounts." } },
                { "phishing", new List<string> { "Make sure that you never click on links or open unexpected emails." } },
                { "malware", new List<string> { " Make sure to keep your antivirus updated to prevent any virus on your PCs or mobiles." } },
                { "browsing", new List<string> { "Always keep your browser updated and manager browser permissions." } }
            ; }

    public string GetResponse(string input) {
        string lowerInput = input.ToLower();
        foreach (var key in responses.Keys) {
            if (lowerInput.Contains(key)) {
                // Return a random response from the associated list
                int index = _random.Next(responses[key].Count);
                return responses[key][index];
            }
        }
        return "Sorry I don't quite understand that.Could you please rephrase that?";
    }

    public List<string> GetAllKeywords() {
        return responses.Keys.ToList();
    }
}

    }

