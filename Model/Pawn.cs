using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Model
{
    public class Pawn : ChessPiece
    {

        public Pawn(int x, int y, PlayerType player)
            : base(x, y, PieceType.Pawn, player,1)
            {

                if(player == PlayerType.AI)
                {
                    legal_moves.Add(new Utils.Vec2(x, y + 1));
                    legal_moves.Add(new Utils.Vec2(x, y + 2));
                }

                else
                {
                    legal_moves.Add(new Utils.Vec2(x, y - 1));
                    legal_moves.Add(new Utils.Vec2(x, y - 2));
                }
                
            }

    }
}
