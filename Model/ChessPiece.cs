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
    public enum PieceType { Pawn,King,Queen,Rook,Knight,Bishop}

    //INotify is an interface that is implemented to notify the view model that a property of the model has changed
    public class ChessPiece : INotifyPropertyChanged
    {
        //Eventhandler that must be implemnted for INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        private Vec2 position;
        private CroppedBitmap bitmap;
        private PlayerType player;
        private PieceType type;

        public ChessPiece(int x, int y, CroppedBitmap bmp, PieceType type,PlayerType player)
        {
            position = new Vec2(x, y);
            LoadBitmap(filepath,320,64,64,64);
            this.type = type;
            this.player = player;
        }

        public CroppedBitmap Texture
        {
            get {return bitmap;}
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

        public void LoadBitmap(string filepath,int x,int y, int width,int height)
        {
            BitmapImage bmp = new BitmapImage(new Uri(filepath, UriKind.Relative));
            bitmap = new CroppedBitmap(bmp, new System.Windows.Int32Rect(x, y, width, height));
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
