using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1.MoveScripts
{
    class EllLeft : MoveScript
    {
        public EllLeft(List<MobileEntity> mobs, bool willFire) : base(mobs, willFire)
        {
        }

        public override void Update()
        {
            //set up initial positioning
            if (FrameCount == 0)
            {
                foreach (MobileEntity mob in Mobs)
                {
                    mob.Position = new Vector2(Constants.D, -30 * (Mobs.IndexOf(mob) + 1));
                    mob.Active = true;
                }
            }
            foreach (MobileEntity mob in Mobs)
            {
                if (mob.Position.Y < Constants.G)
                {
                    mob.UpdatePosition("down");
                }
                else mob.UpdatePosition("right");
                if (mob.Position.X > Constants.PLAYABLE_WIDTH)
                {
                    mob.Active = false;
                }
            }
        }
    }
}
