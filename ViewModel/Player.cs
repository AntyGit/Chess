using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.ViewModel
{
    public interface Player
    {
        void InitMove(Utils.Vec2 source);
        void MakeMove(Utils.Vec2 destination);
 
    }
}
