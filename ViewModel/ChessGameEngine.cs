using Chess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.ViewModel
{
    // This will be the class that feeds the GUI with information (i.e the data context) 
    class ChessGameEngine
    {
       private ChessBoard board;
       private Utils.Vec2 source; 

       public ChessGameEngine()
       { 
          source = null;
          board = new ChessBoard();

       }

       public ChessBoard Board
       {
         get
           {
             return board;
           }
       }

       public void InitMove(Utils.Vec2 source)
       {
           this.source = source;
       }

       public void MovePiece(Utils.Vec2 destination)
       {
           ChessPiece p = Board.GetPiece(source);

           if (p != null && p.Player == PlayerType.Human)
           {
               p.Position = destination;
               Board.UpdateTiles(source,destination);
           }
       }


    }

}
