using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1.MoveScripts
{
    class SinRight : MoveScript
    {
        public SinRight(List<MobileEntity> mobs, bool willFire) : base(mobs, willFire)
        {
            FrameCount = 0;
        }

        public override void Update()
        {
            if (FrameCount == 0)
            {
                foreach (MobileEntity mob in Mobs)
                {
                    mob.Position = new Vector2((0 - 60 * Mobs.IndexOf(mob)), Constants.E);
                    mob.Active = true;
                }
            }
            // x and y are seporate so that the framecount mod can be changed seporately for more fine control
            foreach (MobileEntity mob in Mobs)
            {
                if (FrameCount % 1 == 0)
                {
                    mob.UpdatePosition("right");
                }

                if (FrameCount % 1 == 0)
                {
                    mob.Position = new Vector2(mob.Position.X, Constants.E + (-(float)Math.Cos(mob.Position.X / 50) * 150));
                }
                if (mob.Position.X > Constants.PLAYABLE_WIDTH)
                {
                    mob.Active = false;
                }
                foreach (MoveScript formation in Bullets)
                {
                    formation.Update();
                }
                FrameCount++;
            }
            foreach (MoveScript formation in Bullets)
            {
                formation.Update();
            }
            FrameCount++;
        }
    }
}
