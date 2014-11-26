using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Chess.View
{
    public class AssetHandler
    {
        private readonly string filepath = @"Assets/chess-pieces.png";
        private Dictionary<Model.PieceType,System.Windows.Int32Rect> light_bounds;
        private Dictionary<Model.PieceType, System.Windows.Int32Rect> dark_bounds;
        private Dictionary<Model.PieceType, CroppedBitmap> light_images;
        private Dictionary<Model.PieceType, CroppedBitmap> dark_images;
        private BitmapImage sprite_sheet; 

        public AssetHandler()
        {
            light_bounds = new Dictionary<Model.PieceType,System.Windows.Int32Rect>();
            dark_bounds = new Dictionary<Model.PieceType, System.Windows.Int32Rect>();
            light_images = new Dictionary<Model.PieceType,CroppedBitmap>();
            dark_images = new Dictionary<Model.PieceType,CroppedBitmap>();

            light_bounds.Add(Model.PieceType.King, new System.Windows.Int32Rect(0, 64, 64, 64));
            light_bounds.Add(Model.PieceType.Queen, new System.Windows.Int32Rect(64, 64, 64, 64));
            light_bounds.Add(Model.PieceType.Rook, new System.Windows.Int32Rect(128, 64, 64, 64));
            light_bounds.Add(Model.PieceType.Bishop, new System.Windows.Int32Rect(192, 64, 64, 64));
            light_bounds.Add(Model.PieceType.Knight, new System.Windows.Int32Rect(256, 64, 64, 64));
            light_bounds.Add(Model.PieceType.Pawn, new System.Windows.Int32Rect(320, 64, 64, 64));

            dark_bounds.Add(Model.PieceType.King, new System.Windows.Int32Rect(0, 0, 64, 64));
            dark_bounds.Add(Model.PieceType.Queen, new System.Windows.Int32Rect(64, 0, 64, 64));
            dark_bounds.Add(Model.PieceType.Rook, new System.Windows.Int32Rect(128, 0, 64, 64));
            dark_bounds.Add(Model.PieceType.Bishop, new System.Windows.Int32Rect(192, 0, 64, 64));
            dark_bounds.Add(Model.PieceType.Knight, new System.Windows.Int32Rect(256, 0, 64, 64));
            dark_bounds.Add(Model.PieceType.Pawn, new System.Windows.Int32Rect(320, 0, 64, 64));

            sprite_sheet = new BitmapImage(new Uri(filepath,UriKind.Relative));
            
            LoadImagesFromSheet();
        }

        private void LoadImagesFromSheet()
        {
            foreach(var p in light_bounds)
            {
                CroppedBitmap bitmap = new CroppedBitmap(sprite_sheet, p.Value);
                light_images.Add(p.Key, bitmap);
            }

            foreach (var p in dark_bounds)
            {
                CroppedBitmap bitmap = new CroppedBitmap(sprite_sheet, p.Value);
                dark_images.Add(p.Key, bitmap);
            }

        }


        /*public BitmapImage LoadBitmap(string filepath)
        {
            BitmapImage bitmap = new BitmapImage(new Uri(filepath, UriKind.Relative));
            return bitmap;
        }

        public CroppedBitmap LoadBitmapFromSheet(string filepath, int x, int y, int width, int height)
        {
            BitmapImage bmp = new BitmapImage(new Uri(filepath, UriKind.Relative));
            CroppedBitmap bitmap = new CroppedBitmap(bmp, new System.Windows.Int32Rect(x, y, width, height));
            return bitmap;
        }*/

        public Image GetImageFor(Model.PieceType piece_type, Model.PlayerType player)
        {
            if (player == Model.PlayerType.Human)
            {

                Image img = new Image();
                img.Source = light_images[piece_type];
                return img;
            }
                
            else
            {
                Image img = new Image();
                img.Source = dark_images[piece_type];
                return img;
            }
        }

    }
}
