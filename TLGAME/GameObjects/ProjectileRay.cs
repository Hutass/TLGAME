using System.Drawing;

namespace TLGAME
{
    class ProjectileRay : Projectile
    {
        private int tick = 0, offset = 0;
        public ProjectileRay(double x = 0, double y = 0, double vx = 0, double vy = 0) : base(x, y, vx, vy)
        {

        }
        public override void Draw(Graphics field)
        {
            Bitmap Bmp_Ray = new Bitmap(Properties.Resources.Enemy_Sniper_Ray_Sheet);
            offset = -128;
            while (true)
            {
                GraphicsUnit unit = GraphicsUnit.Pixel;
                if (y + offset + 128 < 1080)
                {
                    offset += 128;
                    Rectangle rect = new Rectangle(((tick / Globals.UPDATE_TIME) * 12) % 36, 0, 12, 128);
                    field.DrawImage(Bmp_Ray, (int)x, (int)y + offset, rect, unit);
                }
                else
                {
                    Rectangle rect = new Rectangle(((tick / Globals.UPDATE_TIME) * 12) % 36, 0, 12, (int)y + offset + (1080 - (int)y - offset));
                    field.DrawImage(Bmp_Ray, (int)x, (int)y + offset, rect, unit);
                    offset = 0;
                    break;
                }

            }
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
            tick++;
        }
        public override void Behavior(Graphics field)
        {
            ObjectMove();
            Draw(field);
            if (tick / Globals.UPDATE_TIME == Globals.SNIPER_FIRE_TIME)
                OnProjectileDelete(this);
        }
        public override void Init(double x, double y, double vx, double vy, int damage)
        {
            this.x = x + 26;
            this.y = y + 64;
            /*this.vx = vx;
            this.vy = vy;*/
            this.damage = damage;
        }
        public override Rectangle Rectangle()
        {
            return new Rectangle((int)x, (int)y, 12, 1080 - (int)y);
        }
    }
}
