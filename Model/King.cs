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
            : base(x, y, PieceType.King, player,15)
        {
            direction_vectors.Add(new Utils.Vec2(-1, 0));
            direction_vectors.Add(new Utils.Vec2(-1, 1));
            direction_vectors.Add(new Utils.Vec2(0, 1));
            direction_vectors.Add(new Utils.Vec2(1, 1));
            direction_vectors.Add(new Utils.Vec2(1, 0));
            direction_vectors.Add(new Utils.Vec2(1, -1));
            direction_vectors.Add(new Utils.Vec2(0, -1));
            direction_vectors.Add(new Utils.Vec2(-1, -1));
        }

        public King (King p) : base(p)
        {
        }

       
    }
}
