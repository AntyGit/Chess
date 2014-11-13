using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Chess.Model
{
    public sealed class Square
    {
        private ChessPiece piece;
        private SolidColorBrush color;
        private string name;

        public Square(SolidColorBrush color, string name)
        {
            this.piece = null;
            this.color = color;
            this.name = name;
        }

/*        Square(ChessPiece piece, SolidColorBrush color, string name)
        {
            this.piece = piece;
            this.color = color;
            this.name = name;

        }*/

        public SolidColorBrush Color
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
