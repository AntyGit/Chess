using Chess.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.ViewModel
{
    // This will be the class that feeds the GUI with information (i.e the data context) 
    public class ChessGameEngine : INotifyPropertyChanged
    {
       private bool initialized;
       private bool game_over;
       private ChessBoard board;
       private ChessRuleEngine rule_engine;
       private PlayerType active_player;
       private Player light_player;
       private AIPlayer dark_player;
       private string status;

       public event PropertyChangedEventHandler PropertyChanged;

       private void OnPropertyChanged(string propertyName)
       {
           if (PropertyChanged != null)
               PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
       }

       public ChessGameEngine()
       { 
          board = new ChessBoard(this);
          board.SetupBoard();
          rule_engine = new ChessRuleEngine(board);
          initialized = false;
       }

       public void InitializeGame(Player white, Player black)
       {
           status = "Turn: GUI";
           light_player = white;
           dark_player = (AIPlayer)black;
           active_player = PlayerType.Human;
           if(!DeserializeGame())
           {
               board.InitLightPieces();
               board.InitDarkPieces();
           }

           rule_engine.UpdateRules();
           UpdatePlayerStatus();
           initialized = true;
           game_over = false;
       }
       public ChessBoard Board
       {
         get
           {
             return board;
           }

         private set 
         {
             board = value;
             OnPropertyChanged("Board");
         }
       }

       public int TryMove(Utils.Vec2 source, Utils.Vec2 destination)
       {
          ChessPiece p = Board.GetPiece(source);

                   if (!source.Equals(destination))
                   {
                      ChessPiece dest_piece = Board.GetPiece(destination);
                       
                       if(dest_piece != null)
                           return dest_piece.Value;
                       else
                           return 0;
                   }

                   else
                   {
                       return 0;
                   }
       }


       public bool SimulateMove(ChessPiece piece, Utils.Vec2 source, Utils.Vec2 destination)
       {
           ChessBoard test_board = new ChessBoard(board);
           ChessPiece test_piece = test_board.Tiles[piece.Position.X,piece.Position.Y].Piece;
           rule_engine.Board = test_board;

           test_piece.Position = destination;
           test_board.UpdateTiles(source, destination);

           rule_engine.UpdateRules();

           ChessPiece king;

           if(test_piece.PieceType == PieceType.King)
             king = test_piece;
           else
             king = test_board.GetKing(test_piece.Player);

           if (test_board.ReachableFrom(king.Position, king.Player))
           {
               rule_engine.Board = this.board;
               return true;
           }

           else
           {
               rule_engine.Board = this.board;
               return false;
           }
               

           /*board2[i, j] = board2[a, b];
           board2[a, b] = new Blank();*/

           //ta fram kungens pos.

           //för alla motståndarpjäser
           //kolla om dom kan gå till kungen.
           //sant -> return true (det är chack)


           /*PlayerType opponent;
           PlayerType side = piece.Player;

           if (side == PlayerType.Human)
               opponent = PlayerType.AI;
           else
               opponent = PlayerType.Human;


           List<ChessPiece> player_pieces = board.GetPlayersPieces(opponent);

           foreach (ChessPiece p in pieces)
           {
               if (p.GetType() == typeof(Pawn))
               {

                   if ((p.Position.X == pos.X - 1 || p.Position.X == pos.X + 1))
                   {
                       if (p.Player == PlayerType.AI && (p.Position.Y == pos.Y - 1) || p.Player == PlayerType.Human && (p.Position.Y == pos.Y + 1))
                           return true;
                   }
               }

               else if (p.LegalMoves.Contains(pos))
               {
                   return true;
               }

           }
           return false;*/
       }

       public bool MovePiece(Utils.Vec2 source, Utils.Vec2 destination)
       {
           ChessPiece p = Board.GetPiece(source);

           if (initialized && !game_over && p.Player == active_player)
           {
               rule_engine.UpdateRules();

               if (rule_engine.IsMoveValid(p, destination) )
               {
                   if (!source.Equals(destination))
                   {
                       bool makes_checked = SimulateMove(p,source,destination);

                       if (!makes_checked)
                       {
                           p.Position = destination;
                           Board.UpdateTiles(source, destination);
                           rule_engine.UpdateRules();
                           //Check if a player has been checked or check mate
                           UpdatePlayerStatus();
                           SwitchTurn();
                           return true;
                       }

                       else
                           if(active_player == PlayerType.AI)
                           {

                               //UpdatePlayerStatus();
                               //SwitchTurn();
                               return false;
                           }


                   }
                   return true;
               }
               return false;
           }

           else
               return false;
       }

       private void UpdatePlayerStatus()
       {

           ChessPiece light_king = board.GetKing(light_player.PlayerType);
           ChessPiece dark_king = board.GetKing(dark_player.PlayerType);

          if (light_king != null && board.ReachableFrom(light_king.Position, light_king.Player))
          {
              light_player.Check = true;
              GameStatus = "GUI Check";

              foreach (Utils.Vec2 dest in light_king.LegalMoves)
              {
                  if(!SimulateMove(light_king,light_king.Position,dest))
                  {
                      break;
                  }

              }

              light_player.CheckMate = true;
              GameStatus = "Check Mate";
              game_over = true;

          }


          else if (dark_king != null && board.ReachableFrom(dark_king.Position, dark_king.Player))
           {
               dark_player.Check = true;
               GameStatus = "AI Check";

               foreach (Utils.Vec2 dest in dark_king.LegalMoves)
               {
                   if (!SimulateMove(dark_king, dark_king.Position, dest))
                   {
                       break;
                   }

               }

               dark_player.CheckMate = true;
               GameStatus = "Check Mate";
               game_over = true;


           }

       }


       private void SwitchTurn()
       {
           if(active_player == light_player.PlayerType)
           {
               active_player = dark_player.PlayerType;
               GameStatus = "Turn: GUI";
               dark_player.PlanMove();

               //System.Threading.Thread worker_thread = new System.Threading.Thread(dark_player.PlanMove);
               //worker_thread.Start();
           }

           else
           {
               active_player = light_player.PlayerType;
               GameStatus = "Turn: AI";

           }
       }


       public void SerializeGame()
       {
           // Create the XmlDocument.
           System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
           doc.LoadXml("<game><turn>" + active_player + "</turn></game>");
           //doc.LoadXml("<game><status>" + status + "</turn></game>");

           System.Xml.XmlElement new_element = doc.CreateElement("board");

           for (int i = 0; i < board.Rows; ++i)
           {
               for (int j = 0; j < board.Columns; ++j) 
               {
                   System.Xml.XmlElement square = doc.CreateElement("Square" + i + j);
                   new_element.AppendChild(square);
                   square.AppendChild(doc.CreateElement("color"));
                   square.ChildNodes[0].InnerText = board.Tiles[i, j].Color.ToString();
                   square.AppendChild(doc.CreateElement("X"));
                   square.AppendChild(doc.CreateElement("Y"));
                   square.ChildNodes[1].InnerText = i.ToString();
                   square.ChildNodes[2].InnerText = j.ToString();

                   if (board.Tiles[i, j].Piece != null)
                   {

                       System.Xml.XmlElement tmp_piece = doc.CreateElement("Piece" + i + j);
                       //Console.
                       square.AppendChild(tmp_piece);

                       tmp_piece.AppendChild(doc.CreateElement("PieceType"));
                       tmp_piece.AppendChild(doc.CreateElement("Player"));
                       tmp_piece.AppendChild(doc.CreateElement("HasMoved"));


                       tmp_piece.ChildNodes[0].InnerText = board.Tiles[i, j].Piece.PieceType.ToString();
                       tmp_piece.ChildNodes[1].InnerText = board.Tiles[i, j].Piece.Player.ToString();
                       tmp_piece.ChildNodes[2].InnerText = board.Tiles[i, j].Piece.HasMoved.ToString();
                   }


                   /*if (board.Tiles[i, j].Piece.PieceType == PieceType.Pawn)
                   {
                       tmp_piece.AppendChild(doc.CreateElement("hasMoved"));
                       Pawn tmpPawn = board[i] as Pawn;
                       tmpPiece.ChildNodes[2].InnerText = "" + tmpPawn.hasMoved;
                   }*/
               }


           }

           doc.DocumentElement.AppendChild(new_element);

           System.Xml.XmlWriterSettings settings = new System.Xml.XmlWriterSettings();
           settings.Indent = true;
           settings.CloseOutput = true;
           // Save the document to a file and auto-indent the output.
           System.Xml.XmlWriter writer = System.Xml.XmlWriter.Create("C:\\Users\\Gabi\\Desktop\\ChessGame.xml", settings);
           doc.Save(writer);
           writer.Close();
           GameStatus = "Game saved";
       }

       public bool DeserializeGame()
       {
           if(!System.IO.File.Exists("C:\\Users\\Gabi\\Desktop\\ChessGame.xml"))
           {
               return false;
           }

           System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
           doc.Load("C:\\Users\\Gabi\\Desktop\\ChessGame.xml");
           int i = 0;

           //AbstractPiece[] tmpBoard = new AbstractPiece[64];
           ChessBoard tmp_board = new ChessBoard(this);

           active_player = (PlayerType)Enum.Parse(typeof(PlayerType),doc.DocumentElement.FirstChild.InnerText);
           foreach (System.Xml.XmlNode square in doc.DocumentElement.LastChild.ChildNodes)
           {
               TileColor col = (TileColor)Enum.Parse(typeof(TileColor), square.FirstChild.InnerText);
               ChessPiece piece = null;
               Square s = new Square(col); ;
               int x, y;
               x = Int32.Parse(square.ChildNodes[1].InnerText);
               y = Int32.Parse(square.ChildNodes[2].InnerText);

               tmp_board.Tiles[x, y] = s;
               tmp_board.Tiles[x, y].Piece = null;

               if (square.ChildNodes.Count == 4)
               {
                   //var str = 
                   //int tmp_player = Int32.Parse(node.ChildNodes[0].InnerText); //node.Attributes["piece" + i].Attributes["team"].InnerText;
                   //string tmpType = node.ChildNodes[1].InnerText; //node.Attributes["piece" + i].Attributes["type"].InnerText;

                   PieceType type = (PieceType)Enum.Parse(typeof(PieceType), square.LastChild.FirstChild.InnerText);
                   PlayerType owner = (PlayerType)Enum.Parse(typeof(PlayerType), square.LastChild.ChildNodes[1].InnerText);

                   bool has_moved = Boolean.Parse(square.LastChild.ChildNodes[2].InnerText);
                   
                   if (type == PieceType.Pawn)
                   {
                       //bool pawnHasMoved = Convert.ToBoolean(node.ChildNodes[2].InnerText);
                       piece = new Pawn(x,y,owner);
                       piece.HasMoved = has_moved;
                   }
                   else if (type == PieceType.Rook)
                   {
                       piece = new Rook(x,y,owner);
                   }
                   else if (type == PieceType.Knight)
                   {
                       piece = new Knight(x,y,owner);
                   }
                   else if (type == PieceType.Bishop)
                   {
                       piece = new Bishop(x,y,owner);
                   }
                   else if (type == PieceType.Queen)
                   {
                       piece = new Queen(x,y,owner);
                   }               

                   else
                   {
                       piece = new King(x,y,owner);
                   }
                   /*else
                   {
                       piece = null;
                   }*/

                   tmp_board.Tiles[x,y].Piece = piece;
                   tmp_board.Pieces.Add(piece);
                   ++i;
               }

           }
               

           Board = tmp_board;
           GameStatus = "Game loaded";
           return true;
       }

       public string GameStatus
       {
           get { return status; }
           set { OnPropertyChanged("GameStatus"); status = value; }
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
