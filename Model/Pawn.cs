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
            : base(x, y, PieceType.Pawn, player)
            {
                if(player == PlayerType.Human)
                {
                    legal_moves.Add(new Utils.Vec2(x, y + 1));
                }

                else
                {
                    legal_moves.Add(new Utils.Vec2(x, y - 1));
                }
            }
        public override void UpdateLegalMoves(ChessBoard board)
        {

        }
    }
}
