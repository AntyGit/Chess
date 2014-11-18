using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Chess.Model
{
    class ChessBoard
    {
        private Square[,] tiles;
        private ObservableCollection<ChessPiece> pieces;
        private int rows;
        private int columns;
        private const string filepath = @"Assets/chess-pieces.png";

        public ChessBoard()
        {
            this.rows = 8;
            this.columns = 8;
            this.tiles = new Square[rows,columns];
            SetupBoard();
        }

        public ObservableCollection<ChessPiece> Pieces
        {
            get
            {
                return pieces;
            }
        }


        public Square[,] Tiles
        {
            get
            {
                return tiles;
            }
        }

        public void SetupBoard()
        {
            AddTiles();
            InitPieces();
            //AddPieces();
        }

        private void AddTiles()
        {
            SolidColorBrush color = new SolidColorBrush();
            for (int i = 0; i < rows; ++i)
            {
                for (int j = 0; j < columns; ++j)
                {

                    if ((j + i) % 2 == 0)
                    {
                        color = Brushes.WhiteSmoke;

                    }

                    else
                    {
                        color = Brushes.SlateGray;
                    }

                    tiles[i,j] = new Square(color,"");
                }
            }
        }

        private void InitPieces()
        {
            BitmapImage bmp = new BitmapImage(new Uri(filepath, UriKind.Relative));
            CroppedBitmap bitmap = new CroppedBitmap(bmp, new System.Windows.Int32Rect(0,0, 64, 64));
            
            for(int i = 0; i<rows; ++i)
            {
                ChessPiece p = new ChessPiece(0, 0, bitmap, PieceType.Pawn, PlayerType.Human);
                pieces.Add(p);
                Square[]
            }
            



        }

        public void Reset()
        {

        }

    }
}
