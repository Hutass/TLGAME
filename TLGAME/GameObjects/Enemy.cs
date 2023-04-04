using System;
using System.Drawing;

namespace TLGAME
{
    public delegate void EnemyEvents(Enemy enemy);
    [Serializable]
    public abstract class Enemy : GhostObject
    {
        protected int health, score, coin;
        protected double target_x, target_y, vel;
        protected bool stopTrig = false;
        public virtual event EnemyEvents EnemyFire;
        public virtual event EnemyEvents EnemyDeath;
        public virtual event EnemyEvents EnemyColide;

        public Enemy(double x, double y, double vx, double vy) : base(x, y, vx, vy)
        {
        }
        public int Health { get => health; set => health = Convert.ToInt32(value); }
        public int Score { get => score; set => score = Convert.ToInt32(value); }
        public int Coin { get => coin; set => coin = Convert.ToInt32(value); }
        public double Vel { get => vel; set => vel = value; }
        public bool StopTrig { get => stopTrig; set => stopTrig = value; }

        public void Init(double x, double y, double vx, double vy, int health, int score, int coin)
        {
            this.x = x;
            this.y = y;
            this.vx = vx;
            this.vy = vy;
            this.health = health;
            this.score = score;
            this.coin = coin;
        }
        protected virtual void OnEnemyFire(Enemy enemy)
        {
            // Safely raise the event for all subscribers
            EnemyFire?.Invoke(enemy);
        }
        protected virtual void OnEnemyDeath(Enemy enemy)
        {
            // Safely raise the event for all subscribers
            EnemyDeath?.Invoke(enemy);
        }
        protected virtual void OnEnemyColide(Enemy enemy)
        {
            // Safely raise the event for all subscribers
            EnemyColide?.Invoke(enemy);
        }
        public abstract void GetTargetCoords(Player target);
        public abstract void Behavior(Graphics field);
        public abstract void Fire(Graphics field);
        public abstract void SetRandomSeed(Random rand);
        public abstract Rectangle Rectangle();
    }
}
