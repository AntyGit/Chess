using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Utils
{
    public struct Vec2
    {
        private int x, y;

        public Vec2(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public int X
        {
            get
            {
                return x;
            }

            set
            {
                x = value;
            }
        }


        public int Y
        {
            get
            {
                return y;
            }

            set
            {
                y = value;
            }
        }


        public static Vec2 operator +(Vec2 point1, Vec2 point2)
        {
            return new Vec2(point1.X + point2.X, point1.Y + point2.Y);
        }

        public static Vec2 operator -(Vec2 point1, Vec2 point2)
        {
            return new Vec2(point1.X - point2.X, point1.Y - point2.Y);
        }

        
        //If this was a reference type the following would be neccessary
        /* 
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            // Use the as keyword instead of cast operation since it will return null instead of raising an exception if it fails to cast.
            Vec2 p = obj as Vec2;

            if ((Object)p == null)
                return false;


            return (this.X == p.X) && (this.Y == p.Y);
        }*/
        
    }
}
