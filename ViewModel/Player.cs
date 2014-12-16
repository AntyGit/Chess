using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.ViewModel
{
    public abstract class Player
    {
        private bool check;
        private bool check_mate;
        private ChessGameEngine engine;
        private Model.PlayerType type;

        public Player(ChessGameEngine engine, Model.PlayerType type )
        {
            this.engine = engine;
            this.type = type;
            check = false;
            check_mate = false;
        }

        public abstract void InitMove(Utils.Vec2 source);
        public abstract void MakeMove(Utils.Vec2 destination);


        public ChessGameEngine Engine
        {
            get
            {
                return engine;
            }
        }

        public Model.PlayerType PlayerType
        {
            get
            {
                return type;
            }
        }
    }
}
