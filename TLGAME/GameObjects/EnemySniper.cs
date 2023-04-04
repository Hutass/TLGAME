using System;
using System.Drawing;

namespace TLGAME
{
    [Serializable]
    class EnemySniper : Enemy
    {
        private int tick = 0, fireTick = 0;
        private bool fireTrig = false;
        public EnemySniper(double x = 0, double y = 0, double vx = 0, double vy = 0) : base(x, y, vx, vy)
        {
        }
        public override void Behavior(Graphics field)
        {
            OnEnemyColide(this);
            if (fireTrig == true)
                Fire(field);
            else
            {
                ObjectMove();
                Draw(field);
            }
            if (tick / Globals.UPDATE_TIME > 10)
            {
                fireTrig = true;
                tick = 0;
            }
            if (health <= 0)
                OnEnemyDeath(this);
        }
        public override void Draw(Graphics field)
        {
            Bitmap Bmp_Sniper = new Bitmap(Properties.Resources.Enemy_Sniper_Sheet);
            Rectangle rect = new Rectangle(((tick / Globals.UPDATE_TIME) * 64) % 256, 64, 64, 64);
            GraphicsUnit unit = GraphicsUnit.Pixel;
            field.DrawImage(Bmp_Sniper, (int)x, (int)y, rect, unit);
        }
        public override void Erase()
        {
            OnEnemyColide(this);
        }
        public override void GetTargetCoords(Player target)
        {
            target_x = target.X;
            target_y = target.Y;
        }
        public override void ObjectMove()
        {
            if(target_y < y-32)
            {
                double vector_size = Math.Sqrt((target_x - x) * (target_x - x) + (target_y - y) * (target_y - y));
                if (vector_size < Globals.SNIPER_CONVERGENCE)
                {
                    x += (vel) * (target_x - x) / vector_size;
                    y += (vel) * (target_y - y) / vector_size;
                }
                else
                {
                    x -= (vel) * (target_x - x) / vector_size;
                }
                tick = 0;
            }
            else
            if(stopTrig == false)
                if (x < target_x && target_x - x > vx)
                    x += vx;
                else
                    if (x - target_x > vx)
                    x -= vx;
            StopTrig = false;
            tick++;
        }
        public override void SetRandomSeed(Random rand)
        {
            x = rand.NextDouble() * 700;
            y = rand.NextDouble() * 300;
            vx = Globals.SNIPER_SPEED;
            vel = Globals.SNIPER_SPEED;
            health = Globals.SNIPER_MAX_HEALTH;
            score = 30;
        }
        protected override void OnEnemyFire(Enemy enemy)
        {
            // Safely raise the event for all subscribers
            base.OnEnemyFire(enemy);
        }
        protected override void OnEnemyDeath(Enemy enemy)
        {
            // Safely raise the event for all subscribers
            base.OnEnemyDeath(enemy);
        }
        protected override void OnEnemyColide(Enemy enemy)
        {
            // Safely raise the event for all subscribers
            base.OnEnemyColide(enemy);
        }
        public override void Fire(Graphics field)
        {
            Bitmap Bmp_Sniper = new Bitmap(Properties.Resources.Enemy_Sniper_Sheet);
            GraphicsUnit unit = GraphicsUnit.Pixel;
            if (fireTick < 5 * Globals.UPDATE_TIME)
            {
                Rectangle rect = new Rectangle(((fireTick / Globals.UPDATE_TIME) * 64), 128, 64, 64);
                field.DrawImage(Bmp_Sniper, (int)x, (int)y, rect, unit);
                Bitmap Bmp_Ray = new Bitmap(Properties.Resources.Enemy_Sniper_Mark_Sheet);
                int offset = -128;
                while (true)
                {
                    if (y + offset + 128 < 1080)
                    {
                        offset += 128;
                        rect = new Rectangle(((fireTick / Globals.UPDATE_TIME) * 12) % 36, 0, 12, 128);
                        field.DrawImage(Bmp_Ray, (int)x + 26, (int)y + 64 + offset, rect, unit);
                    }
                    else
                    {
                        rect = new Rectangle(((fireTick / Globals.UPDATE_TIME) * 12) % 36, 0, 12, (int)y + 64 + offset + (1080 - (int)y - 64 - offset));
                        field.DrawImage(Bmp_Ray, (int)x + 26, (int)y + 64 + offset, rect, unit);
                        break;
                    }

                }
                fireTick++;
            }
            else
            {
                if (fireTick < (5 + Globals.SNIPER_FIRE_TIME) * Globals.UPDATE_TIME)
                {
                    Rectangle rect = new Rectangle(((fireTick / Globals.UPDATE_TIME - 1) * 64) % 128, 192, 64, 64);
                    field.DrawImage(Bmp_Sniper, (int)x, (int)y, rect, unit);
                    if (fireTick == 5 * Globals.UPDATE_TIME)
                        OnEnemyFire(this);
                    fireTick++;
                }
                else
                if (fireTick < (8 + Globals.SNIPER_FIRE_TIME) * Globals.UPDATE_TIME)
                {
                    Rectangle rect = new Rectangle(((fireTick / Globals.UPDATE_TIME) * 64) % 320, 256, 64, 64);
                    field.DrawImage(Bmp_Sniper, (int)x, (int)y, rect, unit);
                    fireTick++;
                }
                else
                {
                    Rectangle rect = new Rectangle(0, 0, 64, 64);
                    field.DrawImage(Bmp_Sniper, (int)x, (int)y, rect, unit);
                    fireTick = 0;
                    fireTrig = false;
                }
            }

        }
        public override Rectangle Rectangle()
        {
            return new Rectangle((int)x, (int)y, 64, 64);
        }

    }
}
