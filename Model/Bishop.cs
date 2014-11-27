using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Model
{
    public class Bishop : ChessPiece
    {
        public Bishop(int x, int y, PlayerType player)
            : base(x, y, @"Assets/W_BISHOP.png", PieceType.Bishop, player)
        { }
    }
}
