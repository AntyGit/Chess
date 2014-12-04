using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Model
{
    public interface RuleEngine
    {
       bool IsMoveValid(ChessPiece p, Utils.Vec2 pos);
       void UpdateRules();
    }
}
