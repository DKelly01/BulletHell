using Game1.Mobs;
using Game1.MoveScripts.Formations;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1.MoveScripts
{
    class SlowFall : MoveScript
    {
        public SlowFall(List<MobileEntity> mobs, bool willFire) : base(mobs, willFire)
        {
            foreach (MobileEntity mob in mobs)
            {
                mob.Active = true;
            }
        }

        public override void Update()
        {
            string bulletType = "BulletTypeA";

            if (FrameCount % 4 == 0)
            {
                foreach (MobileEntity mob in Mobs)
                {
                    mob.UpdatePosition("down");
                }
            }

            if (FrameCount % 180 == 0 && Mobs[0].Active)
            {
                Formation arc = new Arrowhead(new BulletMaker(), Mobs[0].Position);
                Bullets.Add(MoveScriptMaker.CreateMoveScript(default, arc.SetFormation(bulletType), false));
            }

            foreach (MoveScript formation in Bullets)
            {
                formation.Update();
            }
            FrameCount++;
        }
    }
}
