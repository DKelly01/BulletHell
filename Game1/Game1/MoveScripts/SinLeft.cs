using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1.MoveScripts
{
    class SinLeft : MoveScript
    {
        public SinLeft(List<MobileEntity> mobs, bool willFire) : base(mobs, willFire)
        {
        }

        public override void Update()
        {
            // start at E off screen
            if (FrameCount == 0)
            {
                foreach (MobileEntity mob in Mobs)
                {
                    mob.Position = new Vector2((660 + 60 * Mobs.IndexOf(mob)), Constants.E);
                    //mob.Active = true;
                }
            }

            // x and y are seporate so that the framecount mod can be changed seporately for more fine control
            foreach (MobileEntity mob in Mobs)
            {
                if (mob.Position.X < Constants.PLAYABLE_WIDTH && mob.Position.X > 0)
                {
                    mob.Active = true;
                }
                if (FrameCount % 1 == 0)
                {
                    mob.UpdatePosition("left");
                }

                if (FrameCount % 1 == 0)
                {
                    mob.Position = new Vector2(mob.Position.X, Constants.E + (-(float)Math.Cos(mob.Position.X / 50) * 150));
                }
                if (mob.Position.X <= 0)
                {
                    mob.Active = false;
                }
            }
        }
    }
}
