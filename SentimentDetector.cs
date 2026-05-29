using System;
using System.Collections.Generic;
using System.Text;

namespace CyberSecurityChatbot
{
    
      // inter class to public classs

public enum Sentiment { Neutral, Worried, Curious, Frustrated, Happy }// our setiement words

public class SentimentDetector
{
    //  list of trigger words
    private Dictionary<Sentiment, List<string>> sentimentTriggers = new Dictionary<Sentiment, List<string>>
    {// some trigger words from List
        { Sentiment.Worried, new List<string> { "worried", "scared", "afraid", "anxious", "nervous", "unsafe" } },
        { Sentiment.Curious, new List<string> { "curious", "wondering", "interested", "want to know", "how does" } },
        { Sentiment.Frustrated, new List<string> { "frustrated", "annoyed", "confused", "don't understand" } },
        { Sentiment.Happy, new List<string> { "great", "thanks", "helpful", "awesome", "love it" } }
    };

    // Detect(string input)
    public Sentiment Detect(string input)
    {
        string lowerInput = input.ToLower();
        foreach (var entry in sentimentTriggers)
        {
            if (entry.Value.Any(word => lowerInput.Contains(word)))
            {
                return entry.Key;
            }
        }
        return Sentiment.Neutral;
    }

    //  return empathetic opening sentence
    public string GetSentimentResponse(Sentiment s)
    {
        return s switch
        {
            Sentiment.Worried => "Do not worry, we are here to ease your concerns.",
            Sentiment.Curious => "That is a good question.",
            Sentiment.Frustrated => "We apologise for any confusion and frustrations caused.Lets get this problem sorted.",
            Sentiment.Happy => "Im so glad we were able to help you.",
            _ => "" // Neutral returns an empty string
        };
    }
}

    }

