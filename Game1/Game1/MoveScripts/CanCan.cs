using Game1.Mobs;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1.MoveScripts
{
    class CanCan : MoveScript
    {
        MobMaker bulletMaker = new BulletMaker();
        public CanCan(List<MobileEntity> mobs, bool willFire) : base(mobs, willFire)
        {
            FrameCount = 0;
        }

        public override void Update()
        {
            //string pattern = "Arrowhead";
            //string trajectory = "Arc";
            //int numBullets = 10;
            //string bulletType = "BulletTypeA";
            int initialXPosition = Constants.K - (30 * ((Mobs.Count / 2) - 1));
            if (FrameCount == 0)
            {
                foreach (MobileEntity mob in Mobs)
                {
                    mob.Position = new Vector2((initialXPosition + 30 * Mobs.IndexOf(mob)), -30 * (Mobs.IndexOf(mob) + 1));
                    mob.Active = true;
                }
            }
            foreach (MobileEntity mob in Mobs)
            {
                //mobs enter from top of screen for 5 seconds
                if (FrameCount < 5 * Constants.FPS)
                {
                    if (mob.Position.Y < Constants.F)
                    {
                        mob.UpdatePosition("down");
                    }
                    else if (mob.Position.Y < Constants.F + mob.MoveSpeed)
                    {
                        //fire(pattern, mob, bulletType, mob.Color, numBullets, trajectory);
                        if (this.willFire && mob.Active)
                        {
                            //List<MobileEntity>bullets = formation.SetFormation("BulletTypeA", mob.Position);
                            Formation formation = new Arrowhead(bulletMaker,mob.Position);
                            //List<MobileEntity> bulletFormation = BulletMaker.CreateBulletList("BulletTypeA", new Arrowhead(mob.Position));
                            Bullets.Add(MoveScriptMaker.CreateMoveScript("Arc",formation.SetFormation("BulletTypeA"), false));
                        }
                            mob.UpdatePosition("down");
                    }
                }
                else //mobs begin exiting one by one
                {
                    if (FrameCount > (5 + Mobs.IndexOf(mob)) * Constants.FPS)
                        mob.UpdatePosition("up");
                    if (mob.Position.Y < 0)
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
