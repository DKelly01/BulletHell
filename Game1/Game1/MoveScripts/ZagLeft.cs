using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1.MoveScripts
{
    class ZagLeft : MoveScript
    {
        public ZagLeft(List<MobileEntity> mobs, bool willFire) : base(mobs, willFire)
        {
            FrameCount = 0;
        }

        public override void Update()
        {
            if (FrameCount == 0)
            {
                foreach (MobileEntity mob in Mobs)
                {
                    mob.Position = new Vector2((660 + 60 * Mobs.IndexOf(mob)), Constants.E);
                    //mob.Active = true;
                }
            }
            foreach (MobileEntity mob in Mobs)
            {

                if (mob.Position.X < Constants.PLAYABLE_WIDTH && mob.Position.X > 0)
                {
                    mob.Active = true;
                }
                //mobs enter from Left at E, then move upLeft between 0-C, G-K, O-S
                if (mob.Position.X >= 0 && mob.Position.X < Constants.C || mob.Position.X >= Constants.G && mob.Position.X < Constants.K || mob.Position.X >= Constants.O && mob.Position.X < Constants.S)
                {
                    mob.UpdatePosition("upLeft");
                }
                //the mobs move downLeft between C-G, K-O, S-V
                else if (mob.Position.X >= Constants.C && mob.Position.X < Constants.G || mob.Position.X >= Constants.K && mob.Position.X < Constants.O || mob.Position.X >= Constants.S && mob.Position.X < Constants.V)
                {
                    mob.UpdatePosition("downLeft");
                }
                // just go left if off the either side of the screen
                else
                {
                    mob.UpdatePosition("left");
                    if (mob.Position.X <= 0)
                    {
                        mob.Active = false;
                    }
                }
                foreach (MoveScript formation in Bullets)
                {
                    formation.Update();
                }
                FrameCount++;
            }
        }
    }
}
