using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Input;

namespace Memory_game_WPF
{
    public partial class MainWindow : Window
    {
        private const int rowCount = 4;
        private const int colCount = 4;
        MemoryGrid grid;

        public MainWindow()
        {
            InitializeComponent();
            grid = new MemoryGrid(GameGrid, rowCount, colCount);
        }
    }
}