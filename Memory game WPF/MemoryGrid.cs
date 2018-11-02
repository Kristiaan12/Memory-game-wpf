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
    public class MemoryGrid
    {
        int intScore1 = 0;
        int intScore2 = 0;
        bool allowClick = false;
        Boolean beginTurnP2 = true;
        Boolean p1Done = false;
        Boolean p2Done = false;
        int time1 = 6000;
        int time = 6000;
        int time2 = 6000;
        DispatcherTimer timer = new DispatcherTimer();
        DispatcherTimer timer2 = new DispatcherTimer();
        public Grid grid;
        private const int cols = 4;
        private const int rows = 4;
        Random rnd = new Random();
        public object lblTijdP1 { get; private set; }
        public object lblTijdP2 { get; private set; }

        public MemoryGrid(Grid grid, int cols, int rows)
        {
            this.grid = grid;
            InitializeGameGrid(cols, rows);
            AddImage();
            startGameTimer(true);
            startGameTimerP2(false);

        }
        //METHODEN
        /// <summary>
        /// create a board.
        /// </summary>
        /// <param name="cols">het aantal kolommen</param>
        /// <param name="rows">het aantal rijen</param>
        public void InitializeGameGrid(int cols, int rows)
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
            List<ImageSource> images = GetImagesList();
            for (int row = 0; row < rows; row++)
            {
                for (int column = 0; column < cols; column++)
                {
                    Image backgroundImage = new Image();
                    backgroundImage.Source = new BitmapImage(new Uri("Resources/Kaartachtergrond1.png", UriKind.Relative));
                    backgroundImage.Tag = images.First();
                    images.RemoveAt(0);
                    backgroundImage.MouseDown += new MouseButtonEventHandler(CardClick);
                    Grid.SetColumn(backgroundImage, column);
                    Grid.SetRow(backgroundImage, row);
                    grid.Children.Add(backgroundImage);
                }
            }
        }
        private List<ImageSource> GetImagesList()
        {
            List<ImageSource> images = new List<ImageSource>();
            for (int i = 0; i < 16; i++)
            {
                int imageNr = i % 8 + 1;
                ImageSource source = new BitmapImage(new Uri("Resources/" + imageNr + ".png", UriKind.Relative));
                images.Add(source);
            }
            return images;
        }

        private void CardClick(object sender, MouseButtonEventArgs e)
        {
            Image card = (Image)sender;
            ImageSource front = (ImageSource)card.Tag;
            card.Source = front;
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

                    lblTijdP1 = "P1: 00:" + time1.ToString();
                };
            }
            if (!run)
            {
                timer.Stop();
            }

        }

        private void startGameTimerP2(Boolean run)
        {

            if (run)
            {
                timer2.Start();
                timer2.Tick += delegate
                {
                    time2--;
                    if (time2 < 0)
                    {
                        timer2.Stop();
                        MessageBox.Show("Je tijd is op!");
                        p2Done = true;
                        allowClick = false;
                        //Only reset when the game is over?
                        //ResetImages();
                    }

                    var ssTime2 = TimeSpan.FromSeconds(time);

                    lblTijdP2 = "P2: 00:" + time2.ToString();
                };
            }
            if (!run)
            {
                timer2.Stop();
            }

        }

    }
    }

