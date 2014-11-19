using Chess.Model;
using Chess.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        //public ObservableCollection<ChessPiece> pieces;
        private View.AssetHandler assets; 

        public MainWindow()
        {
            InitializeComponent();
            assets = new View.AssetHandler();
            engine = new ChessGameEngine();
            this.DataContext = engine;
            DrawBoard();
        }
        
        //WIP: Maybe I should do this in design (xaml).
        private void DrawBoard()
        {

            Chess.Model.Square[,] tiles = engine.Board.Tiles;

            foreach(Chess.Model.Square t in tiles)
            {
                Rectangle r = new Rectangle();
                r.Fill = t.Color;
                tile_grid.Children.Add(r);
            }
            
            Chess.Model.ChessPiece piece = new Model.Pawn(0,0,Model.PlayerType.Human);
            Chess.Model.ChessPiece piece2 = new Model.King(0, 0,Model.PlayerType.AI);

            Image img = assets.GetImageFor(piece.Type, piece.Player);
            img.Margin = new Thickness(0, 0, 800,390);

            grid.Children.Add(img);
            
            //grid.Children.Add(assets.GetImageFor(piece2.Type, piece2.Player));
        }


        /*public BitmapImage LoadBitmap(string filepath)
        {
            BitmapImage bitmap = new BitmapImage(new Uri(filepath, UriKind.Relative));
            return bitmap;
        }

        public CroppedBitmap LoadBitmapFromSheet(string filepath, int x, int y, int width, int height)
        {
            BitmapImage bmp = new BitmapImage(new Uri(filepath, UriKind.Relative));
            CroppedBitmap bitmap = new CroppedBitmap(bmp, new System.Windows.Int32Rect(x, y, width, height));
            return bitmap;
        }*/



        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            engine.Board.Reset();
        }
        
    }
}
