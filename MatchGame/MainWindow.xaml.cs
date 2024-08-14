using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace MatchGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    using System.Windows.Threading;

    public partial class MainWindow : Window
    {  
        DispatcherTimer timer = new DispatcherTimer();
        int secondsElapsed;
        int matchesFound;
        public MainWindow()
        {
            InitializeComponent();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
            SetUpGame();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            secondsElapsed++;
            timeTextBlock.Text = (secondsElapsed / 10f).ToString("0.0s");
            if(matchesFound == 8)
            {
                timer.Stop();
                timeTextBlock.Text = "- Play Again.";

            }
        }

        List<String> emojiList = new List<String>()
            {
                "😊","😊",
                "😂","😂",
                "❤️","❤️",
                "💕","💕",
                "👌","👌",
                "😘","😘",
                "🎶","🎶",
                "🍖","🍖",
                
            };
        List<string> removedEmojis = new List<string>();
        void SetUpGame() { 
            Random random = new Random();
            foreach (TextBlock text in mainGrid1.Children.OfType<TextBlock>()) {
                int index = random.Next(emojiList.Count);
                string Text = emojiList[index];
                text.Text = Text;
                emojiList.Remove(text.Text);
            }
            timer.Start();
            secondsElapsed = 0;
            matchesFound = 0;
           


        }
        TextBlock lastTextBlock = null;
        bool founfMatch = false;

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            TextBlock text = sender as TextBlock;
            if (!founfMatch)
            {
                text.Visibility = Visibility.Hidden;
                lastTextBlock = text;
                founfMatch= true;
            }else if (lastTextBlock.Text == text.Text)
            {
                text.Visibility = Visibility.Hidden;
                founfMatch = false;
                matchesFound++;
            }
            else
            {
                lastTextBlock.Visibility = Visibility.Visible;
                founfMatch = false;
            
            }
            
        }

        private void timeTextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(matchesFound == 8)
            {
                SetUpGame();
            }
        }

        private void timeTextBlock_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            if (matchesFound == 8)
            {
                SetUpGame();
            }
        }
    }
}
