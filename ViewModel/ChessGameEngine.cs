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

    }

}
