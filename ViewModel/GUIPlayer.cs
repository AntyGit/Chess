using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.ViewModel
{
    public class GUIPlayer : Player
    {
        private ChessGameEngine engine;
        private Utils.Vec2 source;

        public GUIPlayer(ChessGameEngine engine)
        {
            this.engine = engine;
        }

        public void InitMove(Utils.Vec2 source)
        {
            this.source = source;
        }

        public void MakeMove(Utils.Vec2 destination)
        {
            engine.TryMovePiece(source,destination);
        }

        public Model.ChessBoard Board
        {
            get
            {
                return engine.Board;
            }
        }

        public ChessGameEngine Engine
        {
            get
            {
                return engine;
            }
        }
    }
}
