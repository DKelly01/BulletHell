using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1.MoveScripts
{
    class EllRight : MoveScript
    {
        public EllRight(List<MobileEntity> mobs, bool willFire) : base(mobs, willFire)
        {
            //set up initial positioning
            FrameCount = 0;      
            foreach (MobileEntity mob in mobs)
            {
                mob.Position = new Vector2(Constants.R, -30 * (mobs.IndexOf(mob) + 1));
                mob.Active = true;
            }
        
        }

        public override void Update()
        {
            foreach (MobileEntity mob in Mobs)
            {
                if (mob.Position.Y < Constants.G)
                {
                    mob.UpdatePosition("down");
                }
                else mob.UpdatePosition("left");
                if (mob.Position.X < 0)
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
