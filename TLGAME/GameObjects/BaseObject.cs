using System;
using System.Drawing;

namespace TLGAME
{
    [Serializable]
    public abstract class BaseObject
    {
        protected double x, y;
        protected string image;
        public BaseObject(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public double X { get => x; set => x = value; }
        public double Y { get => y; set => y = value; }

        public abstract void Draw(Graphics field);
        public abstract void Erase();
    }
}
