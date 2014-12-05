using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Model
{
    public class ChessRuleEngine : RuleEngine
    {
        private ChessBoard board;

        private readonly List<Utils.Vec2> pawn_moves;
        private readonly List<Utils.Vec2> king_moves;
        private readonly List<Utils.Vec2> knight_moves;

        /*private readonly int pawn_reach = 1;
        private readonly int rook_reach = 7;
        private readonly int bishop_reach = 7;
        private readonly int king_reach = 1;
        private readonly int queen_reach = 7;
        private readonly int knight_reach = 1;*/

        public ChessRuleEngine(ChessBoard board)
        {
            this.board = board;

            pawn_moves = new List<Utils.Vec2>()
            {

            };

            king_moves = new List<Utils.Vec2>()
            {
                new Utils.Vec2(-1, 0),new Utils.Vec2(-1, 1),new Utils.Vec2(0, 1),new Utils.Vec2(1, 1),
                new Utils.Vec2(1, 0),new Utils.Vec2(1, -1),new Utils.Vec2(0, -1),new Utils.Vec2(-1, -1)
            };

            knight_moves = new List<Utils.Vec2>() 
            { 
                new Utils.Vec2(-2, -1),new Utils.Vec2(-1, -2),new Utils.Vec2(1, -2),new Utils.Vec2(-2, 2),
                new Utils.Vec2(2, 1),new Utils.Vec2(1, 2),new Utils.Vec2(-1, 2),new Utils.Vec2(-2, 1)
            };
        }

       public bool IsMoveValid(ChessPiece piece, Utils.Vec2 position)
        {
           return piece.LegalMoves.Contains(position);
        }

       public void UpdateRules()
       {
           foreach(ChessPiece p in board.Pieces)
           {
               //The dynamic type is awesome...
               p.LegalMoves = Update( (dynamic)p );
           }
       }

       private List<Utils.Vec2> Update(Rook rook)
       {
           List<Utils.Vec2> moves = new List<Utils.Vec2>();

           for (int i = rook.Position.X + 1; i < board.Columns; ++i)
           {
               if (board.Tiles[i, rook.Position.Y].Piece == null)
               {
                   moves.Add(new Utils.Vec2(i, rook.Position.Y));
               }

               else
               {
                   if (board.Tiles[i, rook.Position.Y].Piece.Player != rook.Player)
                   {
                       moves.Add(new Utils.Vec2(i, rook.Position.Y));
                       break;
                   }
               }
           }

           for (int i = rook.Position.X - 1; i >= 0; --i)
           {
               if (board.Tiles[i, rook.Position.Y].Piece == null)
               {
                   moves.Add(new Utils.Vec2(i, rook.Position.Y));
               }

               else
               {
                   if (board.Tiles[i, rook.Position.Y].Piece.Player != rook.Player)
                   {
                       moves.Add(new Utils.Vec2(i, rook.Position.Y));
                       break;
                   }
               }
           }

           for (int i = rook.Position.Y - 1; i >= 0; --i)
           {
               if (board.Tiles[rook.Position.X, i].Piece == null)
               {
                   moves.Add(new Utils.Vec2(rook.Position.X, i));
               }

               else
               {
                   if (board.Tiles[rook.Position.X, i].Piece.Player != rook.Player)
                   {
                       moves.Add(new Utils.Vec2(rook.Position.X, i));
                       break;
                   }
               }
           }

           for (int i = rook.Position.Y + 1; i < board.Rows; ++i)
           {
               if (board.Tiles[rook.Position.X, i].Piece == null)
               {
                   moves.Add(new Utils.Vec2(rook.Position.X, i));
               }

               else
               {
                   if (board.Tiles[rook.Position.X, i].Piece.Player != rook.Player)
                   {
                       moves.Add(new Utils.Vec2(rook.Position.X, i));
                       break;
                   }

                   else
                   {
                       moves.Add(new Utils.Vec2(rook.Position.X, i - 1));
                       break;
                   }
               }
           }

           return moves;
       }

       private List<Utils.Vec2> Update(Knight knight)
       {
           List<Utils.Vec2> moves = new List<Utils.Vec2>();

           foreach(Utils.Vec2 dir in knight_moves)
           {
               Utils.Vec2 dest = knight.Position + dir;

               if (!board.OutOfBounds(dest))
               {
                   if (board.Tiles[dest.X, dest.Y].Piece == null)
                     moves.Add(dest);
                   else if(board.Tiles[dest.X, dest.Y].Piece != null && knight.Player != board.Tiles[dest.X, dest.Y].Piece.Player)
                     moves.Add(dest);
               }
           }
           return moves;
       }

       private List<Utils.Vec2> Update(Bishop bishop)
       {
           List<Utils.Vec2> moves = new List<Utils.Vec2>();
           return moves;

       }
       private List<Utils.Vec2> Update(Queen queen)
       {
           return new List<Utils.Vec2>();
       }
       private List<Utils.Vec2> Update(Pawn pawn)
       {
           List<Utils.Vec2> moves = new List<Utils.Vec2>();

           if (pawn.Player == PlayerType.Human)
           {
               moves.Add( new Utils.Vec2(pawn.Position.X, pawn.Position.Y + 1));
           }

           else
           {
               moves.Add(new Utils.Vec2(pawn.Position.X, pawn.Position.Y - 1));
           }

           return moves;
       }

       private List<Utils.Vec2> Update(King king)
       {
           List<Utils.Vec2> moves = new List<Utils.Vec2>();

           foreach (Utils.Vec2 dir in king_moves)
           {
               Utils.Vec2 dest = king.Position + dir;

               if (!board.OutOfBounds(dest))
               {
                   if (board.Tiles[dest.X, dest.Y].Piece == null)
                       moves.Add(dest);
                   else if (board.Tiles[dest.X, dest.Y].Piece != null && king.Player != board.Tiles[dest.X, dest.Y].Piece.Player)
                       moves.Add(dest);
               }
           }

           return moves;
       }

    }
}
