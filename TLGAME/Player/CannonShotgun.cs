using System;

namespace TLGAME
{
    [Serializable]
    class CannonShotgun : Cannon
    {
        public CannonShotgun() : base()
        {
            vx = Globals.CANNON_SHOTGUN_VX;
            vy = Globals.CANNON_SHOTGUN_VY;
            damage = Globals.CANNON_SHOTGUN_DAMAGE;
            reload = Globals.CANNON_SHOTGUN_RELOAD;
            accuracy = Globals.CANNON_SHOTGUN_ACCURACY;
        }
        protected override void OnCannonFire(Cannon cannon)
        {
            // Safely raise the event for all subscribers
            base.OnCannonFire(cannon);
            fireTick++;
        }
        public override void Fire()
        {
            for (int i = 0; i < rand.Next(9) + 2; i++)
            {
                vx = Globals.CANNON_SHOTGUN_VX + (rand.NextDouble() / accuracy - 1 / (2 * accuracy));
                OnCannonFire(this);
            }
            vx = Globals.CANNON_SHOTGUN_VX;
        }
    }
}
