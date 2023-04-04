using System.Drawing;

namespace TLGAME
{
    class ProjectileWave : Projectile
    {
        private int tick = 0;
        public ProjectileWave(double x = 0, double y = 0, double vx = 0, double vy = 0) : base(x, y, vx, vy)
        {

        }
        public override void Draw(Graphics field)
        {
            Bitmap Bmp_Wave = new Bitmap(Properties.Resources.Waves_sprite_Sheet);
            GraphicsUnit unit = GraphicsUnit.Pixel;
            Rectangle rect = new Rectangle(((tick / Globals.UPDATE_TIME) * 20) % 60, 0, 20, 12);
            field.DrawImage(Bmp_Wave, (int)x, (int)y, rect, unit);
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
            if (y >= 1080)
                OnProjectileDelete(this);
        }
        public override void Init(double x, double y, double vx, double vy, int damage)
        {
            this.x = x;
            this.y = y;
            this.vx = vx;
            this.vy = vy + Globals.BULLET_SPEED_VY;
            this.damage = damage;
        }
        public override Rectangle Rectangle()
        {
            return new Rectangle((int)x, (int)y, 20, 12);
        }
    }
}
