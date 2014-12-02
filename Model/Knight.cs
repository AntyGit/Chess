using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Model
{
    public class Knight : ChessPiece
    {
        public Knight(int x, int y, PlayerType player)
            : base(x, y, PieceType.Knight, player)
        { }

        public override void UpdateLegalMoves(ChessBoard board)
        {
            //throw new NotImplementedException();
        }
    }
}
