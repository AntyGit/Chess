using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.ViewModel
{
    public class AIPlayer : Player
    {
        private Utils.Vec2 source;
        private List<Model.ChessPiece> ai_pieces;

        public AIPlayer(ChessGameEngine engine):base(engine,Model.PlayerType.AI)
        {
        }

        public void PlanMove()
        {
            Random rnd = new Random();
            List < Tuple<Utils.Vec2, Utils.Vec2> > candidate_moves = new List<Tuple<Utils.Vec2,Utils.Vec2>>();
            ai_pieces = Engine.Board.GetPlayersPieces(this.PlayerType);

            while(candidate_moves.Count < 50)
            {
                /*Model.ChessPiece move_piece = ai_pieces.ElementAt(rnd.Next(0, ai_pieces.Count));
                InitMove(move_piece.Position);
                if(move_piece.LegalMoves.Count > 0)
                {
                    Utils.Vec2 dest = move_piece.LegalMoves.ElementAt(rnd.Next(0, move_piece.LegalMoves.Count));
                    System.Threading.Thread.Sleep(500);
                    MakeMove(dest);
                    break;
                }*/

                Model.ChessPiece move_piece = ai_pieces.ElementAt(rnd.Next(0, ai_pieces.Count));
                if (move_piece.LegalMoves.Count > 0)
                {
                    Utils.Vec2 dest = move_piece.LegalMoves.ElementAt(rnd.Next(0, move_piece.LegalMoves.Count));
                    candidate_moves.Add(new Tuple<Utils.Vec2, Utils.Vec2>(move_piece.Position, dest));
                }
            }

            int max_value = -1;
            int index = 0;

            for(int i = 0; i<candidate_moves.Count ; ++i)
            {
                Utils.Vec2 source = candidate_moves[i].Item1;
                Utils.Vec2 dest = candidate_moves[i].Item2;

                if(Engine.TryMove(source, dest) > max_value)
                {
                    max_value = Engine.TryMove(source, dest);
                    index = i;
                }
            }

            Tuple<Utils.Vec2, Utils.Vec2> chosen_move = candidate_moves[index];
            InitMove(chosen_move.Item1);
            System.Threading.Thread.Sleep(500);

            MakeMove(chosen_move.Item2);

        }

        public override void InitMove(Utils.Vec2 source)
        {
            this.source = source;
        }

        public override void MakeMove(Utils.Vec2 destination)
        {
            Engine.MovePiece(source,destination);
        }

        public List<Model.ChessPiece> Pieces
        {
            set
            {
                this.ai_pieces = value;
            }
        }

    }
}
