using Chess.ViewModel;
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
        private ChessGameEngine engine;

        public MainWindow()
        {
            InitializeComponent();
            engine = new ChessGameEngine();
            //this.DataContext = engine;
            DrawBoard();
        }
        
        //WIP: Maybe I should do this in design (xaml).
        private void DrawBoard()
        {

            List<Chess.Model.Square> tiles = engine.Board.Tiles;

            foreach(Chess.Model.Square t in tiles)
            {
                Rectangle r = new Rectangle();
                r.Fill = t.Color;
                tile_grid.Children.Add(r);
            }
            
            Chess.Model.ChessPiece piece = new Chess.Model.ChessPiece(0,0,@"Assets/chess-pieces.png",Model.PlayerType.Human);

            Image img = new Image();
            img.Source = piece.Texture;  
            img.Width = 64;
            img.Height = 64;
   
            tile_grid.Children.Add(img);
        }

        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            
        }
        
    }
}
