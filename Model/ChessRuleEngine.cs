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

        private readonly List<Utils.Vec2> dark_pawn_moves;
        private readonly List<Utils.Vec2> light_pawn_moves;
        private readonly List<Utils.Vec2> king_moves;
        private readonly List<Utils.Vec2> rook_moves;
        private readonly List<Utils.Vec2> knight_moves;
        private readonly List<Utils.Vec2> bishop_moves;
        private readonly List<Utils.Vec2> queen_moves;

        /*private readonly int pawn_reach = 1;
        private readonly int rook_reach = 7;
        private readonly int bishop_reach = 7;
        private readonly int king_reach = 1;
        private readonly int queen_reach = 7;
        private readonly int knight_reach = 1;*/

        private int move_reach = 0;

        public ChessRuleEngine(ChessBoard board)
        {
            this.board = board;

            light_pawn_moves = new List<Utils.Vec2>()
            {
                 new Utils.Vec2(0, -1),new Utils.Vec2(1, -1),new Utils.Vec2(-1, -1),new Utils.Vec2(0, -2)
            };

            dark_pawn_moves = new List<Utils.Vec2>()
            {
                new Utils.Vec2(0, 1), new Utils.Vec2(-1, 1),new Utils.Vec2(1, 1),new Utils.Vec2(0, 2)
            };

            king_moves = new List<Utils.Vec2>()
            {
                new Utils.Vec2(-1, 0),new Utils.Vec2(-1, 1),new Utils.Vec2(0, 1),new Utils.Vec2(1, 1),
                new Utils.Vec2(1, 0),new Utils.Vec2(1, -1),new Utils.Vec2(0, -1),new Utils.Vec2(-1, -1)
            };

            rook_moves = new List<Utils.Vec2>()
            {
                new Utils.Vec2(-1, 0),new Utils.Vec2(0, 1),new Utils.Vec2(1, 0),new Utils.Vec2(0, -1)
            };

            knight_moves = new List<Utils.Vec2>() 
            { 
                new Utils.Vec2(-2, -1),new Utils.Vec2(-1, -2),new Utils.Vec2(1, -2),new Utils.Vec2(2, -1),
                new Utils.Vec2(2, 1),new Utils.Vec2(1, 2),new Utils.Vec2(-1, 2),new Utils.Vec2(-2, 1)
            };

            bishop_moves = new List<Utils.Vec2>()
            {
                new Utils.Vec2(-1, 1),new Utils.Vec2(1, -1),new Utils.Vec2(1, 1),new Utils.Vec2(-1, -1)
            };

            queen_moves = new List<Utils.Vec2>()
            {
                new Utils.Vec2(-1, 0),new Utils.Vec2(0, 1),new Utils.Vec2(1, 0),new Utils.Vec2(0, -1),
                new Utils.Vec2(-1, 1),new Utils.Vec2(1, -1),new Utils.Vec2(1, 1),new Utils.Vec2(-1, -1)
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

       public bool TestCheckMove(ChessPiece piece , Utils.Vec2 pos)
       {
           var pieces = board.Pieces.ToList();

           



           /*board2[i, j] = board2[a, b];
           board2[a, b] = new Blank();*/

           

           //ta fram kungens pos.

           //för alla motståndarpjäser
                //kolla om dom kan gå till kungen.
                    //sant -> return true (det är chack)


            PlayerType opponent;
            PlayerType side = piece.Player;

            if (side == PlayerType.Human)
                opponent = PlayerType.AI;
            else
                opponent = PlayerType.Human;


            List<ChessPiece> player_pieces = board.GetPlayersPieces(opponent);

            foreach (ChessPiece p in pieces)
            {
                if (p.GetType() == typeof(Pawn))
                {

                    if ((p.Position.X == pos.X - 1 || p.Position.X == pos.X + 1))
                    {
                        if (p.Player == PlayerType.AI && (p.Position.Y == pos.Y - 1) || p.Player == PlayerType.Human && (p.Position.Y == pos.Y + 1))
                            return true;
                    }
                }

                else if (p.LegalMoves.Contains(pos))
                {
                    return true;
                }

            }
            return false;
       }

       private List<Utils.Vec2> GetMoves(ChessPiece p,List<Utils.Vec2> directions)
       {
           List<Utils.Vec2> moves = new List<Utils.Vec2>();

           foreach(Utils.Vec2 dir in directions)
           {
               for(int i = 1; i <= move_reach; ++i)
               {
                   Utils.Vec2 dest = new Utils.Vec2(p.Position.X + (dir.X * i),p.Position.Y + (dir.Y * i));
                   if(!board.OutOfBounds(dest))
                   {
                       if (board.Tiles[dest.X, dest.Y].Piece == null)
                           moves.Add(dest);
                       else if (board.Tiles[dest.X, dest.Y].Piece != null && p.Player != board.Tiles[dest.X, dest.Y].Piece.Player)
                       {
                           moves.Add(dest);
                           break;
                       }

                       else if (board.Tiles[dest.X, dest.Y].Piece != null && p.Player == board.Tiles[dest.X, dest.Y].Piece.Player)
                           break;
                   }
               }
           }

           //moves.Remove(p.Position);

           return moves;
       }

       
       private List<Utils.Vec2> Update(Rook rook)
       {
           move_reach = 7;
           List<Utils.Vec2> moves = GetMoves(rook,rook_moves);

           /*for (int i = rook.Position.X + 1; i < board.Columns; ++i)
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
                   }
                   break;
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
                   }
                   break;

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
                   }
                   break;
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
                   }

                   break;
               }
           }*/

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
                   else if (board.Tiles[dest.X, dest.Y].Piece != null && knight.Player != board.Tiles[dest.X, dest.Y].Piece.Player)
                     moves.Add(dest);
               }
           }
           return moves;
       }

       private List<Utils.Vec2> Update(Bishop bishop)
       {
           move_reach = 7;
           List<Utils.Vec2> moves = GetMoves(bishop,bishop_moves);
           return moves;

       }

       private List<Utils.Vec2> Update(Queen queen)
       {
           move_reach = 7;
           List<Utils.Vec2> moves = GetMoves(queen, queen_moves);
           return moves;
       }

       private List<Utils.Vec2> Update(Pawn pawn)
       {
           List<Utils.Vec2> moves = new List<Utils.Vec2>();
           List<Utils.Vec2> movement_vectors;
           List<Utils.Vec2> forbidden_moves = new List<Utils.Vec2>();
           move_reach = 1;

           if (pawn.Player == PlayerType.Human)
           {
               movement_vectors = new List<Utils.Vec2> (light_pawn_moves);
           }

           else
               movement_vectors =  new List<Utils.Vec2> (dark_pawn_moves);



           if (pawn.HasMoved)
           {
               movement_vectors.RemoveAt(movement_vectors.Count - 1);
           }

           else
           {
               Utils.Vec2 p1 = pawn.Position + movement_vectors.ElementAt(movement_vectors.Count - 1);
               Utils.Vec2 p2 = pawn.Position + movement_vectors.First();

               bool blocked = board.Tiles[p1.X, p1.Y].Piece != null || board.Tiles[p2.X, p2.Y].Piece != null;
               if(blocked)
               {
                   movement_vectors.RemoveAt(movement_vectors.Count - 1);
               }
           }

           moves = GetMoves(pawn,movement_vectors);

           foreach(Utils.Vec2 point in moves)
           {
               if(point.Equals(pawn.Position) )
               {
                   forbidden_moves.Add(point);
               }

               if(pawn.Position.X == point.X)
               {
                   if(board.Tiles[point.X,point.Y].Piece != null)
                   {
                       forbidden_moves.Add(point);
                   }
               }

               else
                {
                   if(board.Tiles[point.X,point.Y].Piece == null)
                   {
                       forbidden_moves.Add(point);
                   }
                }
           }

           foreach (Utils.Vec2 point in forbidden_moves)
           {
               moves.Remove(point);
           }

           /*for (int i = 0; i < 4; ++i )
           {
               Utils.Vec2 dest = pawn.Position + movement_vectors.ElementAt(i);

               if (!board.OutOfBounds(dest))
               {
                   if (board.Tiles[dest.X, dest.Y].Piece == null)
                       moves.Add(dest);
                   else if (board.Tiles[dest.X, dest.Y].Piece != null && pawn.Player != board.Tiles[dest.X, dest.Y].Piece.Player)
                       moves.Add(dest);
               }
           }*/

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
                   //bool reachable = board.ReachableFrom(dest,king.Player);

                   if (board.Tiles[dest.X, dest.Y].Piece == null /*&& reachable == false*/)
                       moves.Add(dest);
                   else if (board.Tiles[dest.X, dest.Y].Piece != null && king.Player != board.Tiles[dest.X, dest.Y].Piece.Player /*&& reachable == false*/)
                       moves.Add(dest);
               }
           }

           return moves;
       }

      public ChessBoard Board
       {
           get { return board; }
           set { this.board = value; }
       }

    }
}
