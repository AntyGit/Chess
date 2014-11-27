using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Model
{
    public class King : ChessPiece
    {
        public King(int x, int y, PlayerType player)
            : base(x, y, @"Assets/W_KING.png", PieceType.King, player)
        { }
    }
}
