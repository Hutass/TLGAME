using System.Drawing;

namespace TLGAME
{
    class ProjectileSmallScrap : Projectile
    {
        private int tick = 0;
        public ProjectileSmallScrap(double x = 0, double y = 0, double vx = 0, double vy = 0) : base(x, y, vx, vy)
        {

        }
        public override void Draw(Graphics field)
        {
            Bitmap Bmp_Scrap = new Bitmap(Properties.Resources.Player_Small_Scrap_Sheet);
            GraphicsUnit unit = GraphicsUnit.Pixel;
            Rectangle rect = new Rectangle(((tick / Globals.UPDATE_TIME) * 6) % 24, 0, 6, 6);
            field.DrawImage(Bmp_Scrap, (int)x, (int)y, rect, unit);
        }
        public override void Erase()
        {

        }
        protected override void OnProjectileDelete(Projectile projectile)
        {
            // Safely raise the event for all subscribers
            base.OnProjectileDelete(projectile);
        }
        public override void ObjectMove()
        {
            x += vx;
            y += vy;
            tick++;
        }
        public override void Behavior(Graphics field)
        {
            ObjectMove();
            Draw(field);
            if (y <= -6)
                OnProjectileDelete(this);
        }
        public override void Init(double x, double y, double vx, double vy, int damage)
        {
            this.x = x + 31;
            this.y = y + 20;
            this.vx = vx;
            this.vy = vy - Globals.BULLET_SPEED_VY;
            this.damage = damage;
        }
        public override Rectangle Rectangle()
        {
            return new Rectangle((int)x, (int)y, 6, 6);
        }
    }
}
