using System;
using System.Collections.Generic;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CyberSecurityChatbot
{
    public class QuizManager//--3.1
    {

       
            private List<QuizQuestion> _questions;
            private int _currentIndex = 0;
            private int _score = 0;

            public QuizManager()
            {
                _questions = new List<QuizQuestion> {//10question about topics
            
            new QuizQuestion(//poe question 1
                "What should you do if you receive an email asking for your password?",
                new List<string> {
                    "A) Reply with your password",
                    "B) Delete the email",
                    "C) Report the email as phishing",
                    "D) Ignore it"
                },
                "C",
                "Correct! Reporting phishing emails helps prevent scams."
            ),
             new QuizQuestion(//QUESTION 2
                "Why should you keep your antivirus updated?",
                new List<string> {
                    "A) It does not need to be updated.",
                    "B) To prevent any virus corrupting your device.",
                    "C) To prevent you PC from shutting down",
                    "D) All of the above."
                },
                "B",
                "Correct!"
            ),
             new QuizQuestion( //question 3
                "If you are asked to go into an account while using public wifi,what should you do??",
                new List<string> {
                    "A) Not log into the account unless youre using a vpn",
                    "B) log into the accounts",
                    "C) Connect to another public Wi-Fi",
                    "D) Ignore it"
                },
                "A",
                "Correct!"
            ),
             new QuizQuestion(//question 4
                "You download a free resource from the internet,what is the first thing you should do?",
                new List<string> {
                    "A) Run the antivirus scan on file before opening it",
                    "B) Open the file file immediately",
                    "C) Share the file",
                    "D) All of the above"
                },
                "A",
                "Correct! "
            ),
             new QuizQuestion(//question 5
                "What is two factor authentication?",
                new List<string> {
                    "A) Logging into your account twice",
                    "B) Authentication two accounts",
                    "C) Enhancing security by requesting a second form of identification",
                    
                },
                "C",
                "Correct! "
            ),
             new QuizQuestion(//question 6
                "Why should you keep your antivirus updated?",
                new List<string> {
                    "A) Antivirus does not need to be updated",
                    "B) To prevent any virus on your pcs or mobiles",
                    "C) Ignore it",
                   
                },
                "B",
                "Correct! "
            ),
             new QuizQuestion(//question 7
                "Which one below creates the strongest password?",
                new List<string> {
                    "A) Using a phrase with numbers,letters and symbols",
                    "B) Using your own name",
                    "C) Usin numbers 123 on their own",

                },
                "A",
                "Correct! "
            ),
             new QuizQuestion(//question 8
                "What is the risk of accessing your bank account on unkown WiFi?",
                new List<string> {
                    "A) Banking app will not load",
                    "B) Other people can access your account",
                    "C) App will be deleted",

                },
                "B",
                "Correct! "
            ),
             new QuizQuestion(//question 9
                "What is the term for following an employees into a building ?",
                new List<string> {
                    "A)Baiting",
                    "B) Hacking",
                    "C) Piggy backing",

                },
                "C",
                "Correct! "
            ),
             new QuizQuestion(//question 10
                "Social engineering target",
                new List<string> {
                    "A) Employee ID",
                    "B) Firewalls",
                    "C) Huamn pschology",

                },
                "C",
                "Correct! "
            ),
            
        };
            }

            public QuizQuestion GetCurrentQuestion()
            {
                return _questions[_currentIndex];
            }

            public bool SubmitAnswer(string answer)
            {
                //comparing user input
                bool isCorrect = _questions[_currentIndex].CorrectAnswer.Trim().ToLower() == answer.Trim().ToLower();

                if (isCorrect)
                {
                    _score++;
                }

                _currentIndex++;
                return isCorrect;
            }

            public string GetFeedback()
            {
                return _questions[_currentIndex - 1].Explanation;
            }

            public bool IsFinished()
            {
                return _currentIndex >= _questions.Count;
            }

            public string GetFinalScore()
            {
                return $"Score: {_score} out of {_questions.Count}";
            }

            public void ResetQuiz()
            {
                _currentIndex = 0;
                _score = 0;
            }
        }

    }
}
    public class QuizQuestion //--3.2 model class created
    {
        public string QuestionText { get; set; }
        public List<string> Options { get; set; } //where we store options
        public string CorrectAnswer { get; set; }
        public string Explanation { get; set; }

        public QuizQuestion(string text, List<string> options, string answer, string feedback)
        {
            QuestionText = text;
            Options = options;
            CorrectAnswer = answer;
            Explanation = feedback;
        }

    }
}
