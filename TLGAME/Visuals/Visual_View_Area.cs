using System.Drawing;

namespace TLGAME
{
    class Visual_View_Area : Visuals
    {
        public Visual_View_Area(double x = 0, double y = 0, double vx = 0, double vy = 0) : base(x, y, vx, vy)
        {

        }
        public override void ObjectMove()
        {

        }
        public override void Behavior(Graphics field)
        {
            Draw(field);
            tick--;
            if (tick==0)
                OnVisualDelete(this);
        }
        protected override void OnVisualDelete(Visuals visual)
        {
            // Safely raise the event for all subscribers
            base.OnVisualDelete(visual);
        }
        public override void Draw(Graphics field)
        {
            Bitmap Bmp_View = new Bitmap(Properties.Resources.View_Area);

            field.DrawImage(Bmp_View, (int)x, (int)y);
            field.FillRectangle(new SolidBrush(Color.FromArgb(255, 4, 5, 8)), 0, 0,(int)x,1080);
            field.FillRectangle(new SolidBrush(Color.FromArgb(255, 4, 5, 8)), (int)x, (int)y+1400, 470, 1080-(int)y);
            field.FillRectangle(new SolidBrush(Color.FromArgb(255, 4, 5, 8)), (int)x+469, 0, 960-(int)x, 1080);
        }
        public override void SetPlayerCords(double x, double y)
        {
            this.x = x - 200;
            this.y = y - 1170;
        }
        public override void Erase()
        {

        }


    }
}
