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
    class MidBoss : MoveScript
    {
        public MidBoss(List<MobileEntity> mobs, bool willFire) : base(mobs, willFire)
        {
            FrameCount = 0;
            foreach(MobileEntity mob in mobs)
            {
                mob.Position = new Vector2(Constants.K, -30);
                mob.Active = true;
            }
        }

        public override void Update()
        {
            string bulletType = "BulletTypeA";
            int numBullets = 10;
            int timeCap = 26 * Constants.FPS;
            MobileEntity mob = Mobs[0];
            
            if (mob.Position.Y < Constants.E && FrameCount <= 100)
            {
                mob.UpdatePosition("down");
            }
            else if (FrameCount > 200 && FrameCount <= 260)
            {
                if (mob.Position.X < Constants.M)
                {
                    mob.UpdatePosition("upRight");
                }
                if (FrameCount % 250 == 0)
                {
                    ArcFormation arc = new ArcFormation(new BulletMaker(), mob.Position);
                    Bullets.Add(MoveScriptMaker.CreateMoveScript(default, arc.SetFormation(bulletType, numBullets), false));
                }
            }
            else if (FrameCount > 320 && FrameCount <= 380)
            {
                if (mob.Position.X < Constants.P)
                {
                    mob.UpdatePosition("downRight");
                }
                if (FrameCount % 370 == 0)
                {
                    ArcFormation arc = new ArcFormation(new BulletMaker(), mob.Position);
                    Bullets.Add(MoveScriptMaker.CreateMoveScript("Arc", arc.SetFormation(bulletType, numBullets), false));
                }
            }
            else if (FrameCount > 440 && FrameCount <= 500)
            {
                if (mob.Position.X > Constants.M)
                {
                    mob.UpdatePosition("left");
                }
                if (FrameCount % 480 == 0)
                {
                    ArcFormation arc = new ArcFormation(new BulletMaker(), mob.Position);
                    Bullets.Add(MoveScriptMaker.CreateMoveScript(default, arc.SetFormation(bulletType, numBullets), false));
                }
            }
            else if (FrameCount > 560 && FrameCount <= 620)
            {

                if (mob.Position.Y > Constants.C)
                {
                    mob.UpdatePosition("up");
                }
                if (FrameCount % 600 == 0)
                {
                    ArcFormation arc = new ArcFormation(new BulletMaker(), mob.Position);
                    Bullets.Add(MoveScriptMaker.CreateMoveScript("Arc", arc.SetFormation(bulletType, numBullets), false));
                }
            }
            else if (FrameCount > 680 && FrameCount <= 740)
            {
                if (mob.Position.X > Constants.J)
                {
                    mob.UpdatePosition("downLeft");
                }
                if (FrameCount % 720 == 0)
                {
                    ArcFormation arc = new ArcFormation(new BulletMaker(), mob.Position);
                    Bullets.Add(MoveScriptMaker.CreateMoveScript(default, arc.SetFormation(bulletType, numBullets), false));
                }
                else if (FrameCount > 800 && FrameCount <= 860)
                {
                    if (mob.Position.X < Constants.M)
                    {
                        mob.UpdatePosition("right");
                    }
                    if (FrameCount % 840 == 0)
                    {
                        ArcFormation arc = new ArcFormation(new BulletMaker(), mob.Position);
                        Bullets.Add(MoveScriptMaker.CreateMoveScript("Arc", arc.SetFormation(bulletType, numBullets), false));
                    }
                }
                else if (FrameCount > 920 && FrameCount <= 980)
                {
                    if (mob.Position.X > Constants.J)
                    {
                        mob.UpdatePosition("upLeft");
                    }
                    if (FrameCount % 960 == 0)
                    {
                        ArcFormation arc = new ArcFormation(new BulletMaker(), mob.Position);
                        Bullets.Add(MoveScriptMaker.CreateMoveScript(default, arc.SetFormation(bulletType, numBullets), false));
                    }
                }
                else if (FrameCount > 1040 && FrameCount <= 1100)
                {
                    if (mob.Position.X > Constants.G)
                    {
                        mob.UpdatePosition("left");
                    }
                    if (FrameCount % 1080 == 0)
                    {
                        ArcFormation arc = new ArcFormation(new BulletMaker(), mob.Position);
                        Bullets.Add(MoveScriptMaker.CreateMoveScript("Arc", arc.SetFormation(bulletType, numBullets), false));
                    }
                }
                else if (FrameCount > 1160 && FrameCount <= 1220)
                {
                    if (mob.Position.Y > Constants.B)
                    {
                        mob.UpdatePosition("up");
                    }
                    if (FrameCount % 1200 == 0)
                    {
                        ArcFormation arc = new ArcFormation(new BulletMaker(), mob.Position);
                        Bullets.Add(MoveScriptMaker.CreateMoveScript(default, arc.SetFormation(bulletType, numBullets), false));
                    }
                }
                else if (FrameCount > 1280 && FrameCount <= 1340)
                {
                    if (mob.Position.Y < Constants.E)
                    {
                        mob.UpdatePosition("downLeft");
                    }
                    if (FrameCount % 1320 == 0)
                    {
                        ArcFormation arc = new ArcFormation(new BulletMaker(), mob.Position);
                        Bullets.Add(MoveScriptMaker.CreateMoveScript("Arc", arc.SetFormation(bulletType, numBullets), false));
                    }
                }
                else if (FrameCount > 1440 && FrameCount <= 1460)
                {
                    if (mob.Position.X > Constants.H)
                    {
                        mob.UpdatePosition("upLeft");
                    }
                    if (FrameCount % 1440 == 0)
                    {
                        ArcFormation arc = new ArcFormation(new BulletMaker(), mob.Position);
                        Bullets.Add(MoveScriptMaker.CreateMoveScript(default, arc.SetFormation(bulletType, numBullets), false));
                    }
                }
                if (FrameCount > timeCap)
                {
                    mob.UpdatePosition("up");
                    if (mob.Position.Y <= 0)
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
