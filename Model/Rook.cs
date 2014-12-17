using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Model
{
    public class Rook : ChessPiece
    {
        public Rook(int x, int y, PlayerType player)
            : base(x, y, PieceType.Rook, player,5)
        {}

        public Rook (Rook p) : base(p)
        {
        }
    }
}
