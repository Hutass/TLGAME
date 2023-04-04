using System.Drawing;

namespace TLGAME
{
    public delegate void GameEvents(GameEvent events);
    public abstract class GameEvent :GhostObject
    {
        public virtual event GameEvents CreateEvent;
        public virtual event GameEvents DeleteEvent;
        protected int time, tick;
        public GameEvent(double x, double y, double vx, double vy) : base(x, y, vx, vy)
        {
            this.vx = vx;
            this.vy = vy;
        }
        public int Time { get => time; set => vx = time; }
        protected virtual void OnCreateEvent(GameEvent events)
        {
            // Safely raise the event for all subscribers
            CreateEvent?.Invoke(events);
        }
        protected virtual void OnDeleteEvent(GameEvent events)
        {
            // Safely raise the event for all subscribers
            DeleteEvent?.Invoke(events);
        }
        public abstract void CreateNewEvent();
        public abstract void Behavior(Graphics field);
    }
}
