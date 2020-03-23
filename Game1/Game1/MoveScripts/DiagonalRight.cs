using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1.MoveScripts
{
    class DiagonalRight : MoveScript
    {
        public DiagonalRight(List<MobileEntity> mobs, bool willFire) : base(mobs, willFire)
        {
            FrameCount = 0;
            foreach (MobileEntity mob in Mobs)
            {
                mob.Position = new Vector2((0 - 60 * Mobs.IndexOf(mob)), (0 - 60 * Mobs.IndexOf(mob)));
                mob.Active = true;
            }
        }

        public override void Update()
        {
            foreach (MobileEntity mob in Mobs)
            {
                //mobs enter from top left corner of screen, move to center 
                if (mob.Position.X <= 327)
                {
                    mob.UpdatePosition("downRight");
                }
                //after hitting center, mobs leave top right
                else if (mob.Position.X >= 327)
                {
                    mob.UpdatePosition("upRight");
                    if (mob.Position.X > Constants.PLAYABLE_WIDTH || mob.Position.Y <= 0)
                    {
                        mob.Active = false;
                    }
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
