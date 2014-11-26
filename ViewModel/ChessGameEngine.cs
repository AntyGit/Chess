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

       public ChessGameEngine()
       { 
          board = new ChessBoard();

       }

       public ChessBoard Board
       {
         get
           {
             return board;
           }
       }

       public void StartMove(Utils.Vec2 position)
       {
           Square tile = board.Tiles[position.Y,position.X];
           ChessPiece p = tile.Piece;
           board.Tiles[position.Y + 1, position.X].Piece = p;
           

           /*if(tile.Piece.Player == PlayerType.Human)
           {
           }*/
       }


    }

}
