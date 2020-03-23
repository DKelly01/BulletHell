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
    class DiagonalLeft : MoveScript
    {
        public DiagonalLeft(List<MobileEntity> mobs, bool willFire) : base(mobs, willFire)
        {
            FrameCount = 0;
            foreach (MobileEntity mob in Mobs)
            {
                mob.Position = new Vector2((660 + 60 * Mobs.IndexOf(mob)), (0 - 60 * Mobs.IndexOf(mob)));
                mob.Active = true;
            }
        }
        public override void Update()
        {
            int firingInterval = 3;
            int mobFiringInterval = 3;
            string bulletType = "BulletTypeA";
            foreach (MobileEntity mob in Mobs)
            {
                if (FrameCount % (firingInterval * Constants.FPS) == 0 && FrameCount > 0)
                {
                    if (Mobs.IndexOf(mob) % mobFiringInterval == 0)
                    {
                        Solo formation = new Solo(new BulletMaker(), mob.Position);
                        Bullets.Add(MoveScriptMaker.CreateMoveScript(default, formation.SetFormation(bulletType), false));
                    }
                        
                }
                //mobs enter from top right corner of screen, move to center 
                if (mob.Position.X >= 327)
                {
                    if (mob.Position.X < Constants.PLAYABLE_WIDTH)
                    {
                        mob.Active = true;
                    }
                    mob.UpdatePosition("downLeft");

                }
                //after hitting center, mobs leave top
                else if (mob.Position.X <= 327)
                {
                    mob.UpdatePosition("upLeft");
                    if (mob.Position.X <= 0 || mob.Position.Y <= 0)
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
