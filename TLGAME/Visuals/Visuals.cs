using System.Drawing;

namespace TLGAME
{
    public delegate void VisualsEvents(Visuals visual);
    public abstract class Visuals : GhostObject
    {
        public virtual event VisualsEvents VisualDelete;
        protected int tick;
        public Visuals(double x = 0, double y = 0, double vx = 0, double vy = 0) : base(x, y, vx, vy)
        {

        }
        public double Tick { get => tick; set => tick = (int)value; }
        protected virtual void OnVisualDelete(Visuals visual)
        {
            // Safely raise the event for all subscribers
            VisualDelete?.Invoke(visual);
        }
        public abstract void SetPlayerCords(double x, double y);
        public abstract void Behavior(Graphics gield);
    }
}
