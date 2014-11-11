using Chess.Utils;
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

    //INotify is an interface that is implemented to notify the view model that a property of the model has changed
    public abstract class ChessPiece : INotifyPropertyChanged
    {
        //Eventhandler that must be implemnted for INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        private Vec2 position;
        private BitmapImage bitmap;
        private PlayerType player;

        public ChessPiece(int x, int y, string filepath, PlayerType player)
        {
            position = new Vec2(x, y);
            LoadBitmap(filepath);
            this.player = player;
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

        public void LoadBitmap(string filepath)
        {
            bitmap = new BitmapImage(new Uri(filepath, UriKind.Relative));
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
