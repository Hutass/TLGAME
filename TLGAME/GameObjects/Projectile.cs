using System.Drawing;

namespace TLGAME
{
    public delegate void ProjectileEvents(Projectile projectile);
    public abstract class Projectile : GhostObject
    {
        protected int damage;
        public virtual event ProjectileEvents ProjectileDelete;
        public Projectile(double x = 0, double y = 0, double vx = 0, double vy = 0) : base(x, y, vx, vy)
        {
        }
        public int Damage { get => damage; set => damage = (int)value; }
        protected virtual void OnProjectileDelete(Projectile projectile)
        {
            ProjectileDelete?.Invoke(projectile);
        }
        public abstract void Behavior(Graphics field);
        public abstract void Init(double x, double y, double vx, double vy, int damage);
        public abstract Rectangle Rectangle();

    }
}
