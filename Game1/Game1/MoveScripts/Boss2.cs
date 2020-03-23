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
    class Boss2 : MoveScript
    {
        public Boss2(List<MobileEntity> mobs, bool willFire) : base(mobs, willFire)
        {
            FrameCount = 0;
            mobs[0].Position = new Vector2(-30, Constants.A);
            mobs[0].Active = true;
        }

        public override void Update()
        {
            MobileEntity mob = Mobs[0];
            string bulletType = "BulletTypeB";

            //start sin wave from top left
            if (FrameCount <= 11 * Constants.FPS)
            {
                if (FrameCount % 1 == 0)
                {
                    mob.UpdatePosition("right");
                }

                if (FrameCount % 1 == 0)
                {
                    mob.Position = new Vector2(mob.Position.X, Constants.E + (-(float)Math.Cos(mob.Position.X / 50) * 150));
                }
            }

            //sin wave back right
            else if (FrameCount <= 22 * Constants.FPS)
            {
                if (FrameCount % 1 == 0)
                {
                    mob.UpdatePosition("left");
                }

                if (FrameCount % 1 == 0)
                {
                    mob.Position = new Vector2(mob.Position.X, Constants.E + (-(float)Math.Cos(mob.Position.X / 50) * 150));
                }
            }

            //diagnal from top left
            else if (FrameCount <= 33 * Constants.FPS)
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
                }
            }

            //diagnal from top right
            else if (FrameCount <= 43 * Constants.FPS)
            {
                //mobs enter from top right corner of screen, move to center 
                if (mob.Position.X >= 327)
                {
                    mob.UpdatePosition("downLeft");
                }
                //after hitting center, mobs leave top left
                else if (mob.Position.X <= 327)
                {
                    mob.UpdatePosition("upLeft");
                }
            }

            //sin wave from left to offscreen right
            else if (FrameCount > 43 * Constants.FPS)
            {
                if (FrameCount % 1 == 0)
                {
                    mob.UpdatePosition("right");
                }

                if (FrameCount % 1 == 0)
                {
                    mob.Position = new Vector2(mob.Position.X, Constants.E + (-(float)Math.Sin(mob.Position.X / 10) * 150));
                }
            }

            //bullets shoot every second after 4 seconds have passed
            if (FrameCount % 60 == 0 && mob.Active && FrameCount > 4 * Constants.FPS)
            {
                Formation formation = new ZigZagFormation(new BulletMaker(), mob.Position);
                Bullets.Add(MoveScriptMaker.CreateMoveScript("ZigZag", formation.SetFormation(bulletType), false));
            }

            //changed the dead area outside the window so it wouldn't kill mobs when they spawn just off screen
            if (mob.Position.X < -60 || mob.Position.X > 670)
            {
                mob.Active = false;
            }
            if (mob.Position.X < -60 || mob.Position.X > 670)
            {
                mob.Color = Color.Red;
            }
            foreach (MoveScript formation in Bullets)
            {
                formation.Update();
            }
            FrameCount++;

        }
    }
}
