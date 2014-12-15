﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Chess.Model
{
    public class ChessBoard
    {
        private ViewModel.ChessGameEngine engine;
        private Square[,] tiles;
        private ObservableCollection<ChessPiece> pieces;
        private int rows;
        private int columns;

        public ChessBoard(ViewModel.ChessGameEngine engine)
        {
            this.rows = 8;
            this.columns = 8;
            this.tiles = new Square[columns,rows];
            this.pieces = new ObservableCollection<ChessPiece>();
            this.engine = engine;
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
        }

        public int Columns
        {
            get
            {
                return columns;
            }
        }

        public int Rows
        {
            get
            {
                return rows;
            }
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

                    Square s = new Square(color, "");
                    tiles[i, j] = s;
                }
            }
        }

        public void InitLightPieces()
        {

            for(int i = 0; i<columns; ++i)
            {
                Pawn wp = new Pawn(i, rows - 2, PlayerType.Human);
                tiles[i,rows-2].Piece = wp;
                pieces.Add(wp);
            }

            tiles[0,rows-1].Piece = new Rook(0,rows-1, PlayerType.Human);
            pieces.Add(tiles[0, rows - 1].Piece);

            tiles[1,rows-1].Piece = new Knight(1, rows-1, PlayerType.Human);
            pieces.Add(tiles[1, rows - 1].Piece);


            tiles[2,rows - 1].Piece = new Bishop(2, rows - 1, PlayerType.Human);
            pieces.Add(tiles[2,rows - 1].Piece);


            tiles[3,rows - 1].Piece = new Queen(3, rows - 1, PlayerType.Human);
            pieces.Add(tiles[3,rows - 1].Piece);


            tiles[4,rows - 1].Piece = new King(4, rows - 1, PlayerType.Human);
            pieces.Add(tiles[4,rows - 1].Piece);


            tiles[5,rows - 1].Piece = new Bishop(5, rows - 1, PlayerType.Human);
            pieces.Add(tiles[5,rows - 1].Piece);

            tiles[6,rows - 1].Piece = new Knight(6, rows - 1, PlayerType.Human);
            pieces.Add(tiles[6,rows - 1].Piece);

            tiles[7,rows - 1].Piece = new Rook(7, rows - 1, PlayerType.Human);
            pieces.Add(tiles[7,rows - 1].Piece);

        }

        public void InitDarkPieces()
        {
            List<ChessPiece> ai_pieces = new List<ChessPiece>();

            for (int i = 0; i < columns; ++i)
            {
                Pawn bp = new Pawn(i, 1, PlayerType.AI);
                tiles[i, 1].Piece = bp;
                pieces.Add(bp);
                ai_pieces.Add(bp);
            }

            tiles[0, 0].Piece = new Rook(0, 0, PlayerType.AI);
            pieces.Add(tiles[0, 0].Piece);
            ai_pieces.Add(tiles[0, 0].Piece);

            tiles[1, 0].Piece = new Knight(1, 0, PlayerType.AI);
            pieces.Add(tiles[1, 0].Piece);
            ai_pieces.Add(tiles[1, 0].Piece);


            tiles[2, 0].Piece = new Bishop(2, 0, PlayerType.AI);
            pieces.Add(tiles[2, 0].Piece);
            ai_pieces.Add(tiles[2, 0].Piece);


            tiles[3, 0].Piece = new Queen(3, 0, PlayerType.AI);
            pieces.Add(tiles[3, 0].Piece);
            ai_pieces.Add(tiles[3, 0].Piece);


            tiles[4, 0].Piece = new King(4, 0, PlayerType.AI);
            pieces.Add(tiles[4, 0].Piece);
            ai_pieces.Add(tiles[4, 0].Piece);


            tiles[5, 0].Piece = new Bishop(5, 0, PlayerType.AI);
            pieces.Add(tiles[5, 0].Piece);
            ai_pieces.Add(tiles[5, 0].Piece);

            tiles[6, 0].Piece = new Knight(6, 0, PlayerType.AI);
            pieces.Add(tiles[6, 0].Piece);
            ai_pieces.Add(tiles[6, 0].Piece);

            tiles[7, 0].Piece = new Rook(7, 0, PlayerType.AI);
            pieces.Add(tiles[7, 0].Piece);
            ai_pieces.Add(tiles[7, 0].Piece);

            engine.DarkPlayer.Pieces = ai_pieces;
        }

        public ChessPiece GetPiece(Utils.Vec2 position)
        {
            return tiles[position.X, position.Y].Piece;
        }

        public bool OutOfBounds(Utils.Vec2 position)
        {
            return position.X > columns-1 || position.X < 0 || position.Y > rows-1 || position.Y < 0;
        }

        public void UpdateTiles(Utils.Vec2 source, Utils.Vec2 destination)
        {
            ChessPiece p = tiles[destination.X, destination.Y].Piece;


            if (p != null && tiles[source.X, source.Y].Piece.Player != tiles[destination.X, destination.Y].Piece.Player)
            { 
                int index = pieces.IndexOf(p);
                if(index != -1)
                {
                    pieces.Remove(pieces.ElementAt(index));

                }
            }

            tiles[destination.X, destination.Y].Piece = tiles[source.X, source.Y].Piece;
            tiles[source.X, source.Y].Piece = null;
        }

        /*public void UpdatePieces()
        {
            foreach(ChessPiece p in Pieces)
            {
                p.UpdateLegalMoves(this);
            }
        }*/

        public void Reset()
        {

        }

    }
}
