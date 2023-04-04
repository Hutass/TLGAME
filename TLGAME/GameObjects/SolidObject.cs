using System;

namespace TLGAME
{
    [Serializable]
    public abstract class SolidObject : BaseObject
    {
        public SolidObject(double x, double y) : base(x, y) { }

        public abstract void Init(double x, double y);
        public abstract void Collision(int xc1, int xc2, int yc1, int yc2);
        public abstract System.Drawing.Rectangle Rectangle();
    }
}
