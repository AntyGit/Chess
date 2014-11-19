﻿using Chess.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Chess.Model
{
    public enum PlayerType {Human, AI}
    public enum PieceType { Pawn,King,Queen,Rook,Knight,Bishop}

    //This class should be made extendable later on.

    //INotify is an interface that is implemented to notify the view model that a property of the model has changed
    public abstract class ChessPiece : INotifyPropertyChanged
    {
        //Eventhandler that must be implemnted for INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        private Vec2 position;
        private PlayerType player;
        private PieceType type;

        public ChessPiece(int x, int y, PieceType type,PlayerType player)
        {
            position = new Vec2(x, y);

            this.type = type;
            this.player = player;
        }

        public PieceType Type
        {
            get 
            {
                return type;
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
