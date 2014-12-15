using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.ViewModel
{
    public class GUIPlayer : Player
    {
        private Utils.Vec2 source;

        public GUIPlayer(ChessGameEngine engine): base(engine,Model.PlayerType.Human)
        {
        }

        public override void InitMove(Utils.Vec2 source)
        {
            this.source = source;
        }

        public override void MakeMove(Utils.Vec2 destination)
        {
            Engine.MovePiece(source,destination);
        }

        public Model.ChessBoard Board
        {
            get
            {
                return Engine.Board;
            }
        }


    }
}
