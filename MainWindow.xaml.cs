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

namespace Chess
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            //this.DataContext = new ChessGameEngine();
          
            SetupBoard();
        }
        
        //WIP: TO BE REMOVED
        private void SetupBoard()
        {
            
            //multidimensional array in C# unlike Rectangle[][] which is an array of arrays;
            //Rectangle[,] tiles = new Rectangle[tile_grid.Rows, tile_grid.Columns];
            //tile_grid.Margin = new Thickness(15);
            for(int i = 0; i<tile_grid.Rows; ++i)
            {
                for(int j = 0 ; j<tile_grid.Columns; ++j)
                {
                    Rectangle r = new Rectangle ();
                    if((j + i) % 2 == 0)
                    {
                        r.Fill = Brushes.WhiteSmoke;
                    }

                    else 
                    {
                        r.Fill = Brushes.SlateGray;
                    }
                    tile_grid.Children.Add(r);
                }
            }

            Image img = new Image();

            //I need to load the image assets from a local folder(Assets) and so I create a path to that folder. 
            string path = System.IO.Path.Combine(Environment.CurrentDirectory,"Assets","chess-pieces.png");

            Uri uri_src = new Uri(path);
            BitmapImage bmp = new BitmapImage(uri_src);
            bmp.DecodePixelWidth = 64;
            img.Source = bmp;
            img.Width = 385;
            img.Height = 130;
            grid.Children.Add(img);
            
        }
  
        
    }
}
