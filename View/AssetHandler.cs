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
        private Dictionary<Model.PieceType, Image> light_images;
        private Dictionary<Model.PieceType, Image> dark_images;
        private BitmapImage sprite_sheet; 

        public AssetHandler()
        {
            light_bounds = new Dictionary<Model.PieceType,System.Windows.Int32Rect>();
            dark_bounds = new Dictionary<Model.PieceType, System.Windows.Int32Rect>();
            light_images = new Dictionary<Model.PieceType,Image>();
            dark_images = new Dictionary<Model.PieceType,Image>();

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
                Image img = new Image();
                img.Source = bitmap;
                img.Width = 64;
                img.Height = 64;
                light_images.Add(p.Key, img);
            }

            foreach (var p in dark_bounds)
            {
                CroppedBitmap bitmap = new CroppedBitmap(sprite_sheet, p.Value);
                Image img = new Image();
                img.Source = bitmap;
                img.Width = 64;
                img.Height = 64;
                dark_images.Add(p.Key, img);
            }

        }

        public Image GetImageFor(Model.PieceType piece_type, Model.PlayerType player)
        {
            if (player == Model.PlayerType.Human)
                return light_images[piece_type];
            else
                return dark_images[piece_type];
        }

    }
}
