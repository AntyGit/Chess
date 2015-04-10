using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Chess.Model
{
    public enum TileColor {Dark,Light}

    public sealed class Square
    {
        private ChessPiece piece;
        private TileColor color;

        public Square(TileColor color)
        {
            this.piece = null;
            this.color = color;
        }

        public Square(Square square)
        {
            if (square.Piece == null)
                this.piece = null;
            else
                this.piece = new ChessPiece(square.Piece);

            this.color = square.color;
        }

        public TileColor Color
        {
            get
            {
                return color;
            }
        }

        public ChessPiece Piece
        {
            get
            {
                return piece;
            }

            set
            {
                this.piece = value;
            }
        }


    }
}
