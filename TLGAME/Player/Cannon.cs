using System;

namespace TLGAME
{
    public delegate void CannonEvents(Cannon cannon);
    [Serializable]
    public abstract class Cannon
    {
        protected double x, y, vx, vy, accuracy;
        protected int damage, fireTick, reload;
        public virtual event CannonEvents CannonFire;
        protected Random rand = new Random();
        public Cannon()
        {
        }
        protected virtual void OnCannonFire(Cannon cannon)
        {
            // Safely raise the event for all subscribers
            CannonFire?.Invoke(cannon);
        }
        public int Reload { get => reload; set => reload = value; }
        public double VX { get => vx; set => vx = value; }
        public double VY { get => vy; set => vy = value; }
        public double Accuracy { get => accuracy; set => accuracy = value; }
        public int Damage { get => damage; set => damage = value; }
        public int FireTick { get => fireTick; set => fireTick = value; }
        public abstract void Fire();
    }
}
