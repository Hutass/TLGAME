using System.Drawing;

namespace TLGAME
{
    class ProjectileBullet : Projectile
    {
        private int tick = 0;
        public ProjectileBullet(double x = 0, double y = 0, double vx = 0, double vy = 0) : base(x, y, vx, vy)
        {

        }
        public override void Draw(Graphics field)
        {
            Bitmap Bmp_Bullet = new Bitmap(Properties.Resources.Player_Projectile_Sheet);
            GraphicsUnit unit = GraphicsUnit.Pixel;
            Rectangle rect = new Rectangle(((tick / Globals.UPDATE_TIME) * 8) % 16, 0, 8, 8);
            field.DrawImage(Bmp_Bullet, (int)x, (int)y, rect, unit);
        }
        public override void Erase()
        {

        }
        protected override void OnProjectileDelete(Projectile projectile)
        {
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
            if (y <= -8)
                OnProjectileDelete(this);
        }
        public override void Init(double x, double y, double vx, double vy, int damage)
        {
            this.x = x + 28;
            this.y = y + 20;
            this.vx = vx;
            this.vy = vy - Globals.BULLET_SPEED_VY;
            this.damage = damage;
        }
        public override Rectangle Rectangle()
        {
            return new Rectangle((int)x, (int)y, 8, 8);
        }
    }
}
