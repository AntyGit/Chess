using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Model
{
    public class Pawn : ChessPiece
    {
        public Pawn(int x, int y, PlayerType player)
            : base(x, y, @"Assets/W_PAWN.png", PieceType.Pawn, player)
        {
                
        }
    }
}
