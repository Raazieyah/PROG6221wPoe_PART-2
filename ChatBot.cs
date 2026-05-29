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

        public void PlayVoiceGreeting(){
            SoundPlayer player = new SoundPlayer("C:\\Users\\david\\source\\repos\\CyberSecurityChatbot\\CyberSecurityChatbot\\chatbotGreeting.wav");
        player.Play();
            }

        public string GetGreeting()
        {
            return "Hello! What is your name?";
        }

        //Order1-9 + What to check and do
        public string ProcessInput(string input)// Processing input Routing Flow
        {
            //order 1 capture name from input + welcome message
            if (_awaitingName)
            {
                _awaitingName = false;
                return "Its nice to meet you," + input;
            }
            else if (input == "tell me more" || input == "explain more")//order 2 - follow up phrase
            {
                return Memory.GetMoreOnTopic(lastTopic);
            }
            else if (sentiment.Detect(input) != "Netrual")// order 3 neutral
            {
                return sentiment.GetOpener();
            } else {    
                string keywordResponses = keywords.GetResponse(input);// order 4 - get response
                if (keywordResponses != null)
                {
                    _lastTopic = input;
                    return keywordResponses;
                }
        }
            if (input.Contains("how are you"))//order 5- special phrases
            {
                return "I'm doing great, thank you!";
            }

            return "I'm not sure I understand. Can you rephrase?"; // order 6 - fallback



        }
    

