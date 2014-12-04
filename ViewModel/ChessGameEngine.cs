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
       private RuleEngine rule_engine;
       private Utils.Vec2 source;
       //private PlayerType next_player;
        
       //public event Func<PlayerType> e;

       public ChessGameEngine()
       { 
          source = new Utils.Vec2();
          board = new ChessBoard();
          rule_engine = new ChessRuleEngine(board);
          //next_player = PlayerType.Human;
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

           if (p.Player == PlayerType.Human)
           {
               if(rule_engine.IsMoveValid(p,destination))
               {
                   if (!source.Equals(destination))
                   {
                       p.Position = destination;
                       Board.UpdateTiles(source, destination);
                       rule_engine.UpdateRules();
                   }
               }
           }
       }

    }

}
