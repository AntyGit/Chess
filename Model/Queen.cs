using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Model
{
    public class Queen : ChessPiece
    {
        public Queen(int x, int y, PlayerType player)
            : base(x, y, PieceType.Queen, player,9)
        { }

    }
}
