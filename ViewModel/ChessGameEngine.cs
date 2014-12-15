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
       private bool initialized;
       private ChessBoard board;
       private RuleEngine rule_engine;
       private PlayerType active_player;
       private Player light_player;
       private AIPlayer dark_player;
       
       public ChessGameEngine()
       { 
          board = new ChessBoard(this);
          rule_engine = new ChessRuleEngine(board);
          initialized = false;
       }

       public void InitializeGame(Player white, Player black)
       {
           light_player = white;
           dark_player = (AIPlayer)black;
           active_player = PlayerType.Human;
           board.InitLightPieces();
           board.InitDarkPieces();
           initialized = true;
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

           if (initialized && p.Player == active_player)
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
           get
           {
               return dark_player;
           }

           set
           {
               this.dark_player = value;
           }
       }

    }

}
