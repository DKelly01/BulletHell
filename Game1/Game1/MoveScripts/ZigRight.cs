using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1.MoveScripts
{
    class ZigRight : MoveScript
    {
        public ZigRight(List<MobileEntity> mobs, bool willFire) : base(mobs, willFire)
        {
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
            foreach (MobileEntity mob in Mobs)
            {
                //mobs enter from right at E, then move upRight between 0-C, G-K, O-S
                if (mob.Position.X >= 0 && mob.Position.X < Constants.C || mob.Position.X >= Constants.G && mob.Position.X < Constants.K || mob.Position.X >= Constants.O && mob.Position.X < Constants.S)
                {
                    mob.UpdatePosition("upRight");
                }
                //the mobs move downRight between C-G, K-O, S-V
                else if (mob.Position.X >= Constants.C && mob.Position.X < Constants.G || mob.Position.X >= Constants.K && mob.Position.X < Constants.O || mob.Position.X >= Constants.S && mob.Position.X < Constants.V)
                {
                    mob.UpdatePosition("downRight");
                }
                // just go right if off the either side of the screen
                else
                {
                    mob.UpdatePosition("right");
                    if (mob.Position.X > Constants.PLAYABLE_WIDTH)
                    {
                        mob.Active = false;
                    }
                }
            }
        }
    }
}
