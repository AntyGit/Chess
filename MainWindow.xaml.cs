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
        private Rectangle selected_rectangle;
        private Rectangle piece_texture;

        public MainWindow()
        {
            InitializeComponent();
            assets = new View.AssetHandler();
            engine = new ChessGameEngine();
            this.DataContext = engine;
            selected_rectangle = null;
            piece_texture = null;
            DrawBoard();
            DrawPieces();

        }
        
        //WIP: Maybe I should do this in design (xaml).
        private void DrawBoard()
        {

            Chess.Model.Square[,] tiles = engine.Board.Tiles;

            foreach(Chess.Model.Square t in tiles)
            {
                Rectangle r = new Rectangle();

                if(t.Color == Model.TileColor.Light)
                    r.Fill = new SolidColorBrush(Colors.WhiteSmoke);

                else
                    r.Fill = new SolidColorBrush(Colors.SlateGray);

                //r.MouseEnter += r_MouseEnter;
                //r.MouseLeave += r_MouseLeave;
                tile_grid.Children.Add(r);
            }
            

        }

        private void DrawPieces()
        {
            Chess.Model.Square[,] tiles = engine.Board.Tiles;

            for (int i = 0; i < 8; ++i )
            {
                for (int j = 0; j < 8; ++j)
                {
                    Rectangle r = new Rectangle();

                    if (tiles[i,j].Piece == null)
                    {
                        //For some reason the rectangle needs to have its Fill property set to be able to trigger events. 
                        //This is equivalent to Fill = "Transparent" (in XAML).  
                        r.Fill = new SolidColorBrush(Colors.Transparent);
                    }

                    else
                    {
                        ImageBrush img = new ImageBrush (assets.GetImageFor(tiles[i, j].Piece.Type, tiles[i, j].Piece.Player).Source);
                       
                        img.Stretch = Stretch.None;
                        r.Fill = img;    
                    }

                    r.MouseLeftButtonDown += r_MouseDown;
                    r.MouseUp += r_MouseUp;
                    piece_grid.Children.Add(r);
                    
                }
            }
        }

        void r_MouseUp(object sender, MouseEventArgs e)
        {
            Rectangle r = sender as Rectangle;

            System.Windows.Point p = e.GetPosition(this);
            double tile_width = tile_grid.RenderSize.Width / (Math.Sqrt(tile_grid.Children.Count));
            double tile_height = tile_grid.RenderSize.Height / (Math.Sqrt(tile_grid.Children.Count));

            Utils.Vec2 position = new Utils.Vec2((int)(p.X/tile_width), (int)(p.Y/tile_height));

            if (engine.Board.Tiles[position.Y, position.X].Piece == null)
            {
                r.Fill = piece_texture.Fill;
                piece_texture.Fill = new SolidColorBrush(Colors.Transparent);
                HighlightBorder(r);
            }
        }

        void HighlightBorder(Rectangle r)
        {
            if (r != selected_rectangle && selected_rectangle != null)
            {
                selected_rectangle.Stroke = null;
            }

            selected_rectangle = r;
            r.StrokeThickness = 3;
            r.Stroke = new SolidColorBrush(Colors.Crimson);
        }

        void r_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Rectangle r = sender as Rectangle;

            HighlightBorder(r);

            System.Windows.Point p = e.GetPosition(this);
            double tile_width = tile_grid.RenderSize.Width / (Math.Sqrt(tile_grid.Children.Count));
            double tile_height = tile_grid.RenderSize.Height / (Math.Sqrt(tile_grid.Children.Count));

            Utils.Vec2 position = new Utils.Vec2((int)(p.X/tile_width), (int)(p.Y/tile_height));

            if(engine.Board.Tiles[position.Y,position.X].Piece != null)
            {
                piece_texture = r;

            }

        }


        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            engine.Board.Reset();
        }

        

    }
}
