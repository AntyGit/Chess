﻿using System;
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

                Model.ChessPiece move_piece = ai_pieces.ElementAt(rnd.Next(0, ai_pieces.Count));
                if (move_piece.LegalMoves.Count > 0)
                {
                    Utils.Vec2 dest = move_piece.LegalMoves.ElementAt(rnd.Next(0, move_piece.LegalMoves.Count));
                    if(!Engine.SimulateMove(move_piece,move_piece.Position,dest))
                        candidate_moves.Add(new Tuple<Utils.Vec2, Utils.Vec2>(move_piece.Position, dest));
                }
            }

            candidate_moves.Sort((t1, t2) => Engine.TryMove(t2.Item1, t2.Item2).CompareTo(Engine.TryMove(t1.Item1, t1.Item2)) );

            bool success = false;
            for (int i = 0; i < candidate_moves.Count; ++i )
            {;
                 InitMove(candidate_moves[i].Item1);
                 success = MakeMove(candidate_moves[i].Item2);

                if (success)
                    break;
            }

            if(!success)
            {
                Engine.SwitchTurn();
            }

        }

        public override void TakeTurn()
        {
            PlanMove();
        }

        public override void InitMove(Utils.Vec2 source)
        {
            this.source = source;
        }

        public override bool MakeMove(Utils.Vec2 destination)
        {
            return Engine.MovePiece(source,destination);
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
