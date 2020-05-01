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
    class DiagonalRight : MoveScript
    {
        public DiagonalRight(List<MobileEntity> mobs, bool willFire) : base(mobs, willFire)
        {
            FrameCount = 0;
        }

        public override void Update()
        {
            int firingInterval = 2;
            int mobFiringInterval = 2;
            string bulletType = "BulletTypeA";

            if (FrameCount == 0)
            {
                foreach (MobileEntity mob in Mobs)
                {
                    mob.Position = new Vector2((-30 - 60 * Mobs.IndexOf(mob)), (-30 - 60 * Mobs.IndexOf(mob)));
                    mob.Active = true;
                }
            }

            foreach (MobileEntity mob in Mobs)
            {
                if (FrameCount % (firingInterval * Constants.FPS) == 0)
                {
                    if (Mobs.IndexOf(mob) % mobFiringInterval == 0)
                    {
                        Formation formation = new Solo(new BulletMaker(), mob.Position);
                        Bullets.Add(MoveScriptMaker.CreateMoveScript(default, formation.SetFormation(bulletType), false));
                    }

                }
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
