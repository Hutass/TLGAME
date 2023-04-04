using System;

namespace TLGAME
{
    [Serializable]
    public abstract class GhostObject : BaseObject
    {
        protected double vx, vy;
        public GhostObject(double x, double y, double vx, double vy) : base(x, y)
        {
            this.vx = vx;
            this.vy = vy;
        }
        public double VX { get => vx; set => vx = value; }
        public double VY { get => vy; set => vy = value; }
        public abstract void ObjectMove();
    }
}
