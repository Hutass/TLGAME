using System.Drawing;

namespace TLGAME
{
    public class DarkSpaceEvent : GameEvent
    {
        public DarkSpaceEvent(double x = 0, double y = 0, double vx = 0, double vy = 0) : base(x, y, vx, vy)
        {
            this.vx = vx;
            this.vy = vy;
        }
        public override void CreateNewEvent()
        {
            time = Globals.DARK_SPACE_TIME;
            base.OnCreateEvent(this);
        }
        public override void ObjectMove()
        {

        }
        public override void Draw(Graphics field)
        {

        }
        public override void Erase()
        {

        }
        public override void Behavior(Graphics field)
        {
            time--;
            if (time == 0)
                base.OnDeleteEvent(this);
        }
    }
}
