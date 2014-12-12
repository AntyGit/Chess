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

        public AIPlayer(ChessGameEngine engine):base(engine,Model.PlayerType.AI)
        {
        }

        public void PlanMove()
        {
            InitMove(new Utils.Vec2(7, 1));
            Utils.Vec2 dest = new Utils.Vec2(7, 3);
            MakeMove(dest);
        }

        public override void InitMove(Utils.Vec2 source)
        {
            this.source = source;
        }

        public override void MakeMove(Utils.Vec2 destination)
        {
            Engine.TryMovePiece(source,destination);
        }



    }
}
