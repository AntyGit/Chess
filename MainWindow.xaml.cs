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
        private GUIPlayer human_player;
        //private ChessGameEngine engine;
        private Rectangle selected_rectangle;
        private Rectangle piece_texture;
        bool piece_selected;

        public MainWindow()
        {
            InitializeComponent();
            //engine = new ChessGameEngine();
            //human_player = new GUIPlayer(engine);
            
            InitializeGame();
            this.DataContext = human_player.Engine;
            selected_rectangle = null;
            piece_texture = null;
            piece_selected = false;
            DrawBoard();
        }

        private void InitializeGame()
        {
            human_player = new GUIPlayer(new ChessGameEngine());
        }

        private void DrawBoard()
        {

           Square[,] tiles = human_player.Board.Tiles;

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
                    System.Windows.Point p = e.GetPosition(tile_grid);
                    int tile_width = (int)(tile_grid.RenderSize.Width / tile_grid.Columns);
                    int tile_height = (int)(tile_grid.RenderSize.Height / tile_grid.Rows);

                    Utils.Vec2 position = new Utils.Vec2((int)(p.X / tile_width), (int)(p.Y / tile_height));

                    Console.WriteLine(position.X +" "+position.Y);

                    if (piece_selected == false)
                    {
                        human_player.InitMove(position);
                        if(sender is Image)
                        { 
                            piece_selected = true;
                        }

                    }

                    else if(piece_selected == true)
                    {
                        Rectangle r = sender as Rectangle;

                        human_player.MakeMove(position);
                        piece_selected = false;
                    }

                }

        private void ResetButton_Click(object sender, RoutedEventArgs e)
                {
                    //engine.ResetGame();
                }
 
    }
}

