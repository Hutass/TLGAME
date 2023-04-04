using System.Drawing;

namespace TLGAME
{
    class ProjectileBigScrap : Projectile
    {
        private int tick = 0;
        public ProjectileBigScrap(double x = 0, double y = 0, double vx = 0, double vy = 0) : base(x, y, vx, vy)
        {

        }
        public override void Draw(Graphics field)
        {
            Bitmap Bmp_Scrap = new Bitmap(Properties.Resources.Player_Big_Scrap_Sheet);
            GraphicsUnit unit = GraphicsUnit.Pixel;
            Rectangle rect = new Rectangle(((tick / Globals.UPDATE_TIME) * 12) % 36, 0, 12, 12);
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
            if (y <= -12)
                OnProjectileDelete(this);
        }
        public override void Init(double x, double y, double vx, double vy, int damage)
        {
            this.x = x + 26;
            this.y = y + 20;
            this.vx = vx;
            this.vy = vy - Globals.BULLET_SPEED_VY;
            this.damage = damage * Globals.CANNON_SHOTGUN_DAMAGE_MULTIPLIER;
        }
        public override Rectangle Rectangle()
        {
            return new Rectangle((int)x, (int)y, 12, 12);
        }
    }
}
