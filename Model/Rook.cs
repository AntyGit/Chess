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
            : base(x, y, PieceType.Rook, player)
        {
            legal_moves.Add(new Utils.Vec2(x, y));
            legal_moves.Add(new Utils.Vec2(x, y));
            legal_moves.Add(new Utils.Vec2(x, y));
            legal_moves.Add(new Utils.Vec2(x, y));
        }

        public override void UpdateLegalMoves(ChessBoard board)
        {
            for (int i = Position.X; i < board.Columns; ++i )
            {
                if(board.Tiles[i , Position.Y].Piece != null)
                {
                    legal_moves[0] = new Utils.Vec2(i - 1, Position.Y);
                    break;
                }
            }

            for (int i = Position.X; i >= 0; --i )
            {
                if(board.Tiles[i , Position.Y].Piece != null)
                {
                    legal_moves[1] = new Utils.Vec2(i+1, Position.Y);
                    break;
                }
            }

            for (int i = Position.Y; i < board.Rows; ++i )
            {
                if (board.Tiles[Position.X, i].Piece != null)
                {
                    legal_moves[2] = new Utils.Vec2(Position.X, i+1);
                    break;
                }
            }

            for (int i = Position.Y; i >= 0; --i)
            {
                if (board.Tiles[Position.X, i].Piece != null)
                {
                    legal_moves[3] = new Utils.Vec2(Position.X, i-1);
                    break;
                }
            }

        }
        

    }
}
