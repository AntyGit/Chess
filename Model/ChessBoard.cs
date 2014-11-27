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
        private ObservableCollection<Square> observable_tiles;
        private ObservableCollection<ChessPiece> pieces;
        private int rows;
        private int columns;

        public ChessBoard()
        {
            this.rows = 8;
            this.columns = 8;
            this.tiles = new Square[columns,rows];
            this.observable_tiles = new ObservableCollection<Square>();
            this.pieces = new ObservableCollection<ChessPiece>();
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

        public ObservableCollection<Square> ObservableTiles
        {
            get
            {
                return observable_tiles;
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
            TileColor color;

            for (int i = 0; i < rows; ++i)
            {
                for (int j = 0; j < columns; ++j)
                {

                    if ((j + i) % 2 == 0)
                    {
                        color = TileColor.Light;

                    }

                    else
                    {
                        color = TileColor.Dark;
                    }

                    //tiles[i,j] = new Square(color,"");
                    observable_tiles.Add(new Square (color, ""));
                }
            }
        }

        private void InitPieces()
        {

            /*for(int i = 0; i<columns; ++i)
            {
                tiles[1,i].Piece = new Pawn(i, 1, PlayerType.Human);
                tiles[rows - 2, i].Piece = new Pawn(i, rows - 2, PlayerType.AI);
                pieces.Add(tiles[1, i].Piece);
                pieces.Add(tiles[rows - 1, i].Piece);
            }

            tiles[0,0].Piece = new Rook(0, 0, PlayerType.Human);
            tiles[rows-1,0].Piece = new Rook(0,rows-1, PlayerType.AI);
            pieces.Add(tiles[0,0].Piece);
            pieces.Add(tiles[rows - 1, 0].Piece);

            tiles[0, 1].Piece = new Knight(1, 0, PlayerType.Human);
            tiles[rows - 1, 1].Piece = new Knight( 1, rows-1, PlayerType.AI);
            pieces.Add(tiles[0, 1].Piece);
            pieces.Add(tiles[rows - 1, 1].Piece);

            tiles[0, 2].Piece = new Bishop(2, 0, PlayerType.Human);
            tiles[rows - 1, 2].Piece = new Bishop(2, rows - 1, PlayerType.AI);
            pieces.Add(tiles[0, 2].Piece);
            pieces.Add(tiles[rows - 1, 2].Piece);

            tiles[0, 3].Piece = new Queen(3, 0, PlayerType.Human);
            tiles[rows - 1, 3].Piece = new Queen(3, rows - 1, PlayerType.AI);
            pieces.Add(tiles[0, 3].Piece);
            pieces.Add(tiles[rows - 1, 3].Piece);

            tiles[0, 4].Piece = new King(4, 0, PlayerType.Human);
            tiles[rows - 1, 4].Piece = new King(4, rows - 1, PlayerType.AI);
            pieces.Add(tiles[0, 4].Piece);
            pieces.Add(tiles[rows - 1, 4].Piece);

            tiles[0, 5].Piece = new Bishop(5, 0, PlayerType.Human);
            tiles[rows - 1, 5].Piece = new Bishop(5, rows - 1, PlayerType.AI);
            pieces.Add(tiles[0, 5].Piece);
            pieces.Add(tiles[rows - 1, 5].Piece);

            tiles[0, 6].Piece = new Knight(6, 0, PlayerType.Human);
            tiles[rows - 1, 6].Piece = new Knight(6, rows - 1, PlayerType.AI);
            pieces.Add(tiles[0, 6].Piece);
            pieces.Add(tiles[rows - 1, 6].Piece);

            tiles[0, 7].Piece = new Rook(7, 0, PlayerType.Human);
            tiles[rows - 1, 7].Piece = new Rook(7, rows - 1, PlayerType.AI);
            pieces.Add(tiles[0, 7].Piece);
            pieces.Add(tiles[rows - 1, 7].Piece);*/

            observable_tiles.ElementAt(0).Piece = new Rook(0, 0, PlayerType.Human);
            observable_tiles.ElementAt(1).Piece = new Knight(1, 0, PlayerType.Human);

        }

        public void Reset()
        {

        }

    }
}
