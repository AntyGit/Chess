using Chess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.ViewModel
{
    // This will be the class that feeds the GUI with information (i.e the data context) 
    public class ChessGameEngine
    {
       private ChessBoard board;
       private RuleEngine rule_engine;
       private PlayerType active_player;
       private Player light_player;
       private AIPlayer dark_player;
       
       public ChessGameEngine()
       { 
          board = new ChessBoard();
          rule_engine = new ChessRuleEngine(board);
          active_player = PlayerType.Human;
       }

       public ChessBoard Board
       {
         get
           {
             return board;
           }
       }

       /*public void InitMove(Utils.Vec2 source)
       {
           this.source = source;
       }*/

       public bool TryMovePiece(Utils.Vec2 source, Utils.Vec2 destination)
       {
           ChessPiece p = Board.GetPiece(source);

           if (p.Player == active_player)
           {
               if (rule_engine.IsMoveValid(p, destination))
               {
                   if (!source.Equals(destination))
                   {
                       p.Position = destination;
                       Board.UpdateTiles(source, destination);
                       rule_engine.UpdateRules();
                       SwitchTurn();
                       return true;
                   }
                   return false;
               }
               return false;
           }

           else
               return false;
       }

       private void SwitchTurn()
       {
           if(active_player == light_player.PlayerType)
           {
               active_player = dark_player.PlayerType;
               dark_player.PlanMove();
           }

           else
           {
               active_player = light_player.PlayerType;
           }
       }

       public ViewModel.Player LightPlayer
       {
           set
           {
               this.light_player = value;
           }
       }


       public ViewModel.AIPlayer DarkPlayer
       {
           set
           {
               this.dark_player = value;
           }
       }

    }

}
