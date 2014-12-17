using Chess.Utils;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Chess.Model
{
    public enum PlayerType {Human, AI}
    public enum PieceType { Pawn,King,Queen,Rook,Knight,Bishop}

    //This class should be made extendable later on.

    //INotify is an interface that is implemented to notify the view model that a property of the model has changed
    public class ChessPiece : INotifyPropertyChanged
    {
        //Eventhandler that must be implemnted for INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        private Vec2 position;
        bool has_moved;
        private PlayerType player;
        private PieceType type;
        protected List<Utils.Vec2> legal_moves;
        protected readonly List<Utils.Vec2> direction_vectors;
        private int value;

        protected ChessPiece(int x, int y,PieceType type,PlayerType player, int value)
        {
            this.position = new Vec2(x, y);
            this.has_moved = false;
            this.type = type;
            this.player = player;
            this.legal_moves = new List<Vec2>();
            this.direction_vectors = new List<Vec2>();
            this.value = value;
        }

        public ChessPiece(ChessPiece p)
        {
            this.position = new Vec2(p.Position.X, p.Position.Y);
            this.has_moved = p.HasMoved;
            this.type = p.type;
            this.player = p.Player;
            this.legal_moves = new List<Vec2>(p.LegalMoves);
            this.direction_vectors = new List<Vec2>(p.direction_vectors);
            this.value = p.Value;
        }

        public bool Equals(ChessPiece p)
        {
            if (p == null)
                return false;

            else
            {
                return position.X == p.Position.X && position.Y == p.Position.Y && type == p.PieceType && player == p.Player;
            }
        }

        public PieceType PieceType
        {
            get 
            {
                return type;
            }

        }

        public System.Type Type
        {
            get
            {
                
                return GetType();
                
            }
        }

        public List<Utils.Vec2> LegalMoves
        {
            get
            {
                return legal_moves;
            }

            set
            {
                this.legal_moves = value;
            }
        }

        public PlayerType Player
        {
            get
            {
                return player;
            }
        }

        public Vec2 Position
        {
            get
            {
                return position;
            }

            set
            {
                position = value;
                has_moved = true;
                NotifyPropertyChanged("Position");
            }
        }

        public int Value
        {
            get
            {
                return value;
            }
        }

        public bool HasMoved
        {
            get
            {
                return has_moved;
            }
        }

        //Publish an event (a property changed). This is called by set method of propreties
        //[CallerMemberName] causes the name of the property that calls this method to substituted as an argument.
        protected virtual void NotifyPropertyChanged([CallerMemberName] string property_name = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property_name));
            }
        }
    }
}
