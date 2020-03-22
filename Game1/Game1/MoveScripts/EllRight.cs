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
        }

        public override void Update()
        {
            //set up initial positioning
            if (frameCount == 0)
            {
                foreach (MobileEntity mob in mobs)
                {
                    mob.Position = new Vector2(Constants.R, -30 * (mobs.IndexOf(mob) + 1));
                    mob.Active = true;
                }
            }
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
        }
    }
}
