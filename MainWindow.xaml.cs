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
        private Rectangle selected_rectangle;
        private Rectangle piece_texture;
        bool piece_selected;

        public MainWindow()
        {
            InitializeComponent();
            engine = new ChessGameEngine();
            this.DataContext = engine;
            selected_rectangle = null;
            piece_texture = null;
            piece_selected = false;
            DrawBoard();
        }

        //WIP: Maybe I should do this in design (xaml).
        private void DrawBoard()
        {

            ObservableCollection<Square> tiles = engine.Board.ObservableTiles;

            foreach(Chess.Model.Square t in tiles)
            {
                Rectangle r = new Rectangle();

                if(t.Color == Model.TileColor.Light)
                    r.Fill = new SolidColorBrush(Colors.WhiteSmoke);

                else
                    r.Fill = new SolidColorBrush(Colors.SlateGray);

                r.MouseDown += Piece_MouseDown;
                //r.MouseLeave += r_MouseLeave;
                tile_grid.Children.Add(r);
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

                void Piece_MouseDown(object sender, MouseButtonEventArgs e)
                {
                    if (piece_selected == false && sender is Image)
                    {
                        piece_selected = true;
                        System.Windows.Point p = e.GetPosition(this);
                        double tile_width = tile_grid.RenderSize.Width / (Math.Sqrt(tile_grid.Children.Count));
                        double tile_height = tile_grid.RenderSize.Height / (Math.Sqrt(tile_grid.Children.Count));

                        Utils.Vec2 source = new Utils.Vec2((int)(p.X / tile_width), (int)(p.Y / tile_height));
                        engine.InitMove(source);
                    }

                    else if(piece_selected==true && sender is Rectangle)
                    {
                        Rectangle r = sender as Rectangle;

                        System.Windows.Point p = e.GetPosition(this);
                        double tile_width = tile_grid.RenderSize.Width / (Math.Sqrt(tile_grid.Children.Count));
                        double tile_height = tile_grid.RenderSize.Height / (Math.Sqrt(tile_grid.Children.Count));

                        Utils.Vec2 destination = new Utils.Vec2((int)(p.X / tile_width), (int)(p.Y / tile_height));
                        engine.MovePiece(destination);
                        piece_selected = false;
                    }

                }


        private void ResetButton_Click(object sender, RoutedEventArgs e)
                {
                    engine.Board.Reset();
                }

        
        
    }
}

