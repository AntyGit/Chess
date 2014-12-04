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
            : base(x, y, PieceType.King, player)
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

        public override void UpdateLegalMoves(ChessBoard board)
        {
            List<Utils.Vec2> moves = new List<Utils.Vec2>();

            foreach(Utils.Vec2 dir in direction_vectors)
            {
                Utils.Vec2 dest = this.Position + dir;

                if(!board.OutOfBounds(dest))
                {
                    if(board.Tiles[dest.X, dest.Y].Piece == null)
                        moves.Add(dest); 
                    else if (board.Tiles[dest.X, dest.Y].Piece != null && this.Player != board.Tiles[dest.X, dest.Y].Piece.Player )
                        moves.Add(dest);       
                }
            }

            legal_moves = moves;
        }
    }
}
