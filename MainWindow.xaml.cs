using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CyberSecurityChatbot


{
   
    public partial class MainWindow : Window
    {
         public MainWindow()
         {
            
            InitializeComponent();
            
            ChatBot myObj = new ChatBot(); // load the ASCII art into the display
            myObj.LoadAsciiArt();

            ChatBot myObj1 = new ChatBot();//play the voice greeting *PLACE IN CHATBOT CLASS
            myObj1.PlayVoiceGreeting();

            ChatBot myObj2 = new ChatBot(); // in chatbot class   
            myObj2.GetGreeting();

             
         }

     


       private void SendButton_Click(object sender, RoutedEventArgs e)
    {
        SendMessage();
    }

    private void UserInput_KeyDown(object sender, KeyEventArgs e)// connected to MainWindow.xaml
    {
        if (e.Key == Key.Enter)
        {
            SendMessage();
        }
    }

    private void SendMessage()
    {
        string input = InputBox.Text;
        if (string.IsNullOrWhiteSpace(input)) return;

        AppendUserMessage(input);
        InputBox.Clear();

        // Process logic and display result
        string response = chatBot.ProcessInput(input);
        AppendBotMessage(response);
    }

    private void AppendBotMessage(string text)
    {
        ChatDisplay.Text += $"\nBot: {text}";
        AutoScroll();
    }

    private void AppendUserMessage(string text)
    {
        ChatDisplay.Text += $"\nYou: {text}";
        AutoScroll();
    }

    private void AutoScroll()
    {
        
        ChatScrollViewer.ScrollToBottom();
    }
    

      
            private QuizManager _quizManager;//--3.4 3.5

            public MainWindow()
            {
                InitializeComponent();
                _quizManager = new QuizManager();
                DisplayQuestion();
            }

            private void DisplayQuestion()
            {
                // resetting GUI
                FeedbackBorder.Visibility = Visibility.Collapsed;
                NextButton.Visibility = Visibility.Collapsed;
                SubmitButton.IsEnabled = true;

                // clearing previos
                RadioA.IsChecked = false;
                RadioB.IsChecked = false;
                RadioC.IsChecked = false;
                RadioD.IsChecked = false;

                // loading current ndata
                QuizQuestion currentQuestion = _quizManager.GetCurrentQuestion();
                QuestionTextBlock.Text = currentQuestion.QuestionText;

                /
                RadioA.Content = currentQuestion.Options[0];
                RadioB.Content = currentQuestion.Options[1];

                if (currentQuestion.Options.Count > 2)
                {
                    RadioC.Visibility = Visibility.Visible;
                    RadioD.Visibility = Visibility.Visible;
                    RadioC.Content = currentQuestion.Options[2];
                    RadioD.Content = currentQuestion.Options[3];
                }
                else
                {
                    RadioC.Visibility = Visibility.Collapsed;
                    RadioD.Visibility = Visibility.Collapsed;
                }
            }

            private void SubmitButton_Click(object sender, RoutedEventArgs e)
            {
                //which option checked
                string selectedAnswer = "";
                if (RadioA.IsChecked == true) selectedAnswer = "A";
                else if (RadioB.IsChecked == true) selectedAnswer = "B";
                else if (RadioC.IsChecked == true) selectedAnswer = "C";
                else if (RadioD.IsChecked == true) selectedAnswer = "D";

               
                if (string.IsNullOrEmpty(selectedAnswer))
                {
                    MessageBox.Show("Please select an answer option before submitting.", "Selection Required");
                    return;
                }

                
                bool isCorrect = _quizManager.SubmitAnswer(selectedAnswer);

                
                ScoreTracker.Text = _quizManager.GetFinalScore();

                /
                FeedbackBorder.Visibility = Visibility.Visible;
                if (isCorrect)
                {
                    FeedbackBorder.Background = new SolidColorBrush(Color.FromRgb(212, 239, 223)); // Soft Green
                    FeedbackTextBlock.Text = "CORRECT!\n" + _quizManager.GetFeedback();
                }
                else
                {
                    FeedbackBorder.Background = new SolidColorBrush(Color.FromRgb(F9, D5, D5)); // Soft Red
                    FeedbackTextBlock.Text = "INCORRECT.\n" + _quizManager.GetFeedback();
                }

               //toggle for submission
                SubmitButton.IsEnabled = false;
                NextButton.Visibility = Visibility.Visible;
            }

            private void NextButton_Click(object sender, RoutedEventArgs e)
            {
                if (_quizManager.IsFinished())
                {
                    //switching display
                    QuizPanel.Visibility = Visibility.Collapsed;
                    SubmitButton.Visibility = Visibility.Collapsed;
                    NextButton.Visibility = Visibility.Collapsed;
                    FeedbackBorder.Visibility = Visibility.Collapsed;

                    FinalResultsPanel.Visibility = Visibility.Visible;
                    FinalScoreTextBlock.Text = _quizManager.GetFinalScore();
                    FinalMessageTextBlock.Text = _quizManager.GetFinalMessage();
                }
                else
                {
                    DisplayQuestion();
                }
            }
        }
    }




