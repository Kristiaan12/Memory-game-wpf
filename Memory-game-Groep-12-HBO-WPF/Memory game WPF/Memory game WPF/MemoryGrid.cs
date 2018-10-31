using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using static System.Windows.Visibility;

namespace Memory_game_WPF
{
    public class MemoryGrid : MainWindow
    {
        int currPlayer = 1;
        int streakP1 = 0;
        int streakP2 = 0;
        Boolean beginTurnP2 = true;
        Boolean p1Done = false;
        Boolean p2Done = false;
        int[] Highscore = new int[10];
        string[] Highscorenaam = new string[10];
        int intScore1 = 0;
        int intScore2 = 0;
        bool allowClick = false;
        DispatcherTimer clickTimer = new DispatcherTimer();
        int time = 60;
        int time1 = 60;
        int time2 = 60;
        DispatcherTimer timer1 = new DispatcherTimer();
        DispatcherTimer timer = new DispatcherTimer();
        DispatcherTimer timer2 = new DispatcherTimer();
        public Grid grid;
        private const int cols = 4;
        private const int rows = 4;
        // firstClicked points to the first Label control 
        // that the player clicks, but it will be null 
        // if the player hasn't clicked a label yet
        Label firstClicked = null;
        
        // secondClicked points to the second Label control 
        // that the player clicks
        Label secondClicked = null;

        private List<int> Cards = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 1, 2, 3, 4, 5, 6, 7, 8 };
 

        public MemoryGrid(Grid grid, int cols, int rows)
        {
            this.grid = grid;
            InitializeGameGrid(cols, rows);
            AddImage();
        }


        private void InitializeGameGrid(int cols, int rows)
        {

            for (int i = 0; i < rows; i++)
            {
                grid.RowDefinitions.Add(new RowDefinition());
            }
            for (int i = 0; i < cols; i++)
            {
                grid.ColumnDefinitions.Add(new ColumnDefinition());
            }
        }

        private void AddImage()
        {
            for (int row = 0; row < rows; row++)
            {
                for (int column = 0; column < cols; column++)
                {
                    Image backgroundImage = new Image();
                    backgroundImage.Source = new BitmapImage(new Uri("Resources/Kaartachtergrond1.png", UriKind.Relative));
                    Grid.SetColumn(backgroundImage, column);
                    Grid.SetRow(backgroundImage, row);
                    grid.Children.Add(backgroundImage);

                }
            }
        }


        private void startGameTimer(Boolean run)
        {

            if (run)
            {

                timer.Start();

                timer.Tick += delegate
                {
                    time--;
                    if (time < 0)
                    {
                        timer.Stop();
                        MessageBox.Show("Je tijd is op!");
                        p1Done = true;
                        allowClick = false;
                        //Only reset when the game is over?
                        //ResetImages();
                    }

                    var ssTime = TimeSpan.FromSeconds(time);

                    lblTijdP1.Content = "P1: 00:" + time1.ToString();
                };
            }
            if (!run)
            {
                timer.Stop();
            }

            //}

            //private void startGameTimerP2(Boolean run)
            //{

            //    if (run)
            //    {
            //        timer2.Start();
            //        timer2.Tick += delegate
            //        {
            //            time2--;
            //            if (time2 < 0)
            //            {
            //                timer2.Stop();
            //                MessageBox.Show("Je tijd is op!");
            //                p2Done = true;
            //                allowClick = false;
            //                //Only reset when the game is over?
            //                //ResetImages();
            //            }

            //            var ssTime2 = TimeSpan.FromSeconds(time);

            //            lblTijdP2.Content = "P2: 00:" + time2.ToString();
            //        };
            //    }
            //    if (!run)
            //    {
            //        timer2.Stop();
            //    }

            //}


            //private void CardClick(object sender, MouseButtonEventArgs e)
            //{
            //    // The timer is only on after two non-matching 
            //    // icons have been shown to the player, 
            //    // so ignore any clicks if the timer is running
            //    if (timer1.IsEnabled == true)
            //        return;

            //    Label clickedLabel = sender as Label;

            //    if (clickedLabel != null)
            //    {
            //        // If the clicked label is black, the player clicked
            //        // an icon that's already been revealed --
            //        // ignore the click
            //        if (clickedLabel.Foreground == Brushes.Black)
            //            return;

            //        // If firstClicked is null, this is the first icon
            //        // in the pair that the player clicked, 
            //        // so set firstClicked to the label that the player 
            //        // clicked, change its color to black, and return
            //        if (firstClicked == null)
            //        {
            //            firstClicked = clickedLabel;
            //            firstClicked.Foreground = Brushes.Black;
            //            return;
            //        }

            //        // If the player gets this far, the timer isn't
            //        // running and firstClicked isn't null,
            //        // so this must be the second icon the player clicked
            //        // Set its color to black
            //        secondClicked = clickedLabel;
            //        secondClicked.Foreground = Brushes.Black;


            //        // If the player clicked two matching icons, keep them 
            //        // black and reset firstClicked and secondClicked 
            //        // so the player can click another icon
            //        if (firstClicked.Content == secondClicked.Content)
            //        {
            //            if (currPlayer == 1 || currPlayer == 0)
            //            {
            //                streakP1++;
            //                intScore1 += (10 * streakP1);
            //                lblspeler1.Content = "Speler 1 score:" + intScore1.ToString();
            //            }
            //            else
            //            {
            //                streakP2++;
            //                intScore2 += (10 * streakP2);
            //                lblspeler2.Content = "Speler 2 score:" + intScore2.ToString();
            //            }
            //            firstClicked = null;
            //            secondClicked = null;
            //            return;
            //        }
            //        else
            //        {
            //            allowClick = false;
            //            //Check if the 'previous' player is 1.
            //            if (currPlayer == 1 || currPlayer == 0)
            //            {
            //                //Check if player 2 is already out of time.
            //                if (p2Done == false)
            //                {
            //                    streakP1 = 0;
            //                    currPlayer = 2;
            //                    //Pauzeer timer1
            //                    timer.Stop();

            //                    MessageBox.Show("Speler 2 is nu aan de beurt.");
            //                    timer1.Start();
            //                    //Initialize if player2 is starting his first round, else resume timer.
            //                    if (beginTurnP2)
            //                    {
            //                        //Begin timer2
            //                        startGameTimerP2(true);
            //                        beginTurnP2 = false;
            //                    }
            //                    else
            //                    {
            //                        //Hervat timer2
            //                        timer2.Start();

            //                    }
            //                }
            //            }
            //            else
            //            {
            //                //Check if player 1 is already out of time.
            //                if (p1Done == false)
            //                {

            //                    streakP2 = 0;
            //                    currPlayer = 1;
            //                    //Pauzeer timer2
            //                    timer2.Stop();
            //                    MessageBox.Show("Speler 1 is nu aan de beurt.");
            //                    timer.Start();
            //                    //Hervat timer1
            //                    timer1.Start();
            //                }
            //            }
            //        }
            //    }
            // }
        }
}
