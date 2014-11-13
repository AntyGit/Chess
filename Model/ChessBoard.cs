﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Chess.Model
{
    class ChessBoard
    {
        private List<Square> tiles; 
        private int rows;
        private int columns;

        public ChessBoard()
        {
            this.rows = 8;
            this.columns = 8;
            this.tiles = new List<Square>(rows*columns);
            SetupBoard();
        }

        public List<Square> Tiles
        {
            get
            {
                return tiles;
            }
        }

        public void SetupBoard()
        {
            AddTiles();
            //InitPieces();
            //AddPieces();
        }

        private void AddTiles()
        {
            SolidColorBrush color = new SolidColorBrush();
            for (int i = 0; i < rows; ++i)
            {
                for (int j = 0; j < columns; ++j)
                {

                    if ((j + i) % 2 == 0)
                    {
                        color = Brushes.WhiteSmoke;

                    }

                    else
                    {
                        color = Brushes.SlateGray;
                    }

                    tiles.Add(new Square(color, ""));
                }
            }
        }

    }
}
