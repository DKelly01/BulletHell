using Game1.Mobs;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1.MoveScripts
{
    class SoloBRight : MoveScript
    {
        public SoloBRight(List<MobileEntity> mobs, bool willFire) : base(mobs, willFire)
        {
        }

        public override void Update()
        {
            MobileEntity mob = Mobs[0];
            if (FrameCount == 0)
            {
                mob.Position = new Vector2(Constants.P, -30);
                mob.Active = true;
            }
            else if (mob.Position.Y < Constants.F)
            {
                mob.UpdatePosition("down");
            }
            else if (FrameCount % 120 == 0 && mob.Active)
            {
                Arrowhead arrowhead = new Arrowhead(new BulletMaker(), mob.Position);
                Bullets.Add(MoveScriptMaker.CreateMoveScript(default, arrowhead.SetFormation("BulletTypeB", 10), false));
            }
            else
            {
                mob.UpdatePosition("left");
                if (mob.Position.X < 0)
                {
                    mob.Active = false;
                }
            }
        }
    }
}
