using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Model
{
    public class Knight : ChessPiece
    {
        public Knight(int x, int y, PlayerType player)
            : base(x, y, PieceType.Knight, player,3)
        {
            if (player == PlayerType.AI)
            {
                legal_moves.Add(new Utils.Vec2(x-1, y + 2));
                legal_moves.Add(new Utils.Vec2(x+1, y + 2));
            }

            else
            {
                legal_moves.Add(new Utils.Vec2(x-1, y - 2));
                legal_moves.Add(new Utils.Vec2(x+1, y - 2));
            }
        }

        public Knight (Knight p) : base(p)
        {
        }
    }
}
