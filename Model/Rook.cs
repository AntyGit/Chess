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
        {}

        public override void UpdateLegalMoves(ChessBoard board)
        {

                List<Utils.Vec2> moves = new List<Utils.Vec2>();

                for (int i = Position.X+1; i < board.Columns; ++i)
                {
                    if (board.Tiles[i, Position.Y].Piece == null)
                    {
                        moves.Add(new Utils.Vec2(i, Position.Y));
                    }

                    else
                    {
                        if(board.Tiles[i, Position.Y].Piece.Player != this.Player)
                        {
                            moves.Add(new Utils.Vec2(i, Position.Y));
                            break;
                        }
                    }
                }

                for (int i = Position.X-1; i >= 0; --i)
                {
                    if (board.Tiles[i, Position.Y].Piece == null)
                    {
                        moves.Add(new Utils.Vec2(i, Position.Y));
                    }

                    else
                    {
                        if (board.Tiles[i, Position.Y].Piece.Player != this.Player)
                        {
                            moves.Add(new Utils.Vec2(i, Position.Y));
                            break;
                        }
                    }
                }

                for (int i = Position.Y-1; i >= 0 ; --i)
                {
                    if (board.Tiles[Position.X, i].Piece == null)
                    {
                        moves.Add(new Utils.Vec2(Position.X, i));
                    }

                    else
                    {
                        if (board.Tiles[Position.X, i].Piece.Player != this.Player)
                        {
                            moves.Add(new Utils.Vec2(Position.X, i));
                            break;
                        }
                    }
                }

                for (int i = Position.Y+1; i < board.Rows; ++i)
                {
                    if (board.Tiles[Position.X, i].Piece == null)
                    {
                        moves.Add(new Utils.Vec2(Position.X, i));
                    }

                    else
                    {
                        if (board.Tiles[Position.X, i].Piece.Player != this.Player)
                        {
                            moves.Add(new Utils.Vec2(Position.X, i));
                            break;
                        }

                        else
                        {
                            moves.Add(new Utils.Vec2(Position.X, i-1));
                            break;
                        }
                    }
                }

                legal_moves = moves;
            }
    }
}
