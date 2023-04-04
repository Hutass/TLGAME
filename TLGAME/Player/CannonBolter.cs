using System;

namespace TLGAME
{
    [Serializable]
    class CannonBolter : Cannon
    {
        public CannonBolter() : base()
        {
            vx = Globals.CANNON_BOLTER_VX;
            vy = Globals.CANNON_BOLTER_VY;
            damage = Globals.CANNON_BOLTER_DAMAGE;
            reload = Globals.CANNON_BOLTER_RELOAD;
            accuracy = Globals.CANNON_BOLTER_ACCURACY;
        }
        protected override void OnCannonFire(Cannon cannon)
        {
            // Safely raise the event for all subscribers
            base.OnCannonFire(cannon);
            fireTick++;
        }
        public override void Fire()
        {
            vx = Globals.CANNON_BOLTER_VX + (rand.NextDouble() / accuracy - 1 / (2 * accuracy));
            OnCannonFire(this);
            vx = Globals.CANNON_BOLTER_VX;
        }
    }
}
