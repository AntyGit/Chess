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
            bool success = false;

            while(!success)
            {
                Model.ChessPiece move_piece = ai_pieces.ElementAt(rnd.Next(0, ai_pieces.Count));
                InitMove(move_piece.Position);
                if(move_piece.LegalMoves.Count > 0)
                {
                    Utils.Vec2 dest = move_piece.LegalMoves.ElementAt(rnd.Next(0, move_piece.LegalMoves.Count));
                    System.Threading.Thread.Sleep(500);
                    MakeMove(dest);
                    break;
                }
            }
        }

        public override void InitMove(Utils.Vec2 source)
        {
            this.source = source;
        }

        public override void MakeMove(Utils.Vec2 destination)
        {
            Engine.TryMovePiece(source,destination);
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
