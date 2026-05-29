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
}



}
