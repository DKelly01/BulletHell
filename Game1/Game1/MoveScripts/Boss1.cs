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
    class Boss1 : MoveScript
    {
        public Boss1(List<MobileEntity> mobs, bool willFire) : base(mobs, willFire)
        {
            FrameCount = 0;
        }

        public override void Update()
        {
            MobileEntity mob = Mobs[0];
            string bulletType = "BulletTypeB";
            
            if (FrameCount == 0)
            {
                mob.Position = new Vector2(Constants.P, -70);
                mob.Active = true;
                mob.Color = Color.HotPink;
            }

            //ZigZag down for 4 seconds
            if (FrameCount <= 4 * Constants.FPS)
            {
                if (mob.Position.Y < Constants.A || mob.Position.Y >= Constants.D)
                {
                    mob.UpdatePosition("downRight");
                }
                else
                {
                    mob.UpdatePosition("downLeft");
                }
            }

            //zigzag left for 6 seconds
            else if (FrameCount <= 10 * Constants.FPS)
            {
                if (mob.Position.X >= 0 && mob.Position.X < Constants.C || mob.Position.X >= Constants.G && mob.Position.X < Constants.K || mob.Position.X >= Constants.O && mob.Position.X < Constants.S)
                {
                    mob.UpdatePosition("upLeft");
                }
                //the mobs move downLeft between C-G, K-O, S-V
                else if (mob.Position.X >= Constants.C && mob.Position.X < Constants.G || mob.Position.X >= Constants.K && mob.Position.X < Constants.O || mob.Position.X >= Constants.S && mob.Position.X < Constants.V)
                {
                    mob.UpdatePosition("downLeft");
                }
            }

            //zigzag right for 5 seconds
            else if (FrameCount <= 15 * Constants.FPS)
            {
                if (mob.Position.X >= 0 && mob.Position.X < Constants.C || mob.Position.X >= Constants.G && mob.Position.X < Constants.K || mob.Position.X >= Constants.O && mob.Position.X < Constants.S)
                {
                    mob.UpdatePosition("upRight");
                }
                //the mobs move downRight between C-G, K-O, S-V
                else if (mob.Position.X >= Constants.C && mob.Position.X < Constants.G || mob.Position.X >= Constants.K && mob.Position.X < Constants.O || mob.Position.X >= Constants.S && mob.Position.X < Constants.V)
                {
                    mob.UpdatePosition("downRight");
                }
            }
            //zigzag left for 7 seconds
            else if (FrameCount <= 22 * Constants.FPS)
            {
                if (mob.Position.X >= 0 && mob.Position.X < Constants.C || mob.Position.X >= Constants.G && mob.Position.X < Constants.K || mob.Position.X >= Constants.O && mob.Position.X < Constants.S)
                {
                    mob.UpdatePosition("upLeft");
                }
                //the mobs move downLeft between C-G, K-O, S-V
                else if (mob.Position.X >= Constants.C && mob.Position.X < Constants.G || mob.Position.X >= Constants.K && mob.Position.X < Constants.O || mob.Position.X >= Constants.S && mob.Position.X < Constants.V)
                {
                    mob.UpdatePosition("downLeft");
                }
            }

            //Sawtooth right
            else if (FrameCount <= 30 * Constants.FPS)
            {
                // mobs teleport down when on C,G,K,O, or S
                if ((FrameCount / Constants.FPS) >= 23 && (FrameCount / Constants.FPS) <= 23.5)
                {
                    if (!Constants.invincible)
                    {
                        Constants.playerColor = Color.Yellow;
                        Constants.invertX = false;
                        Constants.invertY = true;
                    }
                    mob.UpdatePosition("down");
                    mob.UpdatePosition("down");
                }
                else if ((FrameCount / Constants.FPS) >= 25 && (FrameCount / Constants.FPS) <= 25.5)
                {
                    if (!Constants.invincible)
                    {
                        Constants.playerColor = Color.Yellow;
                        Constants.invertX = false;
                        Constants.invertY = true;
                    }
                    mob.UpdatePosition("down");
                    mob.UpdatePosition("down");
                }
                else if ((FrameCount / Constants.FPS) >= 27 && (FrameCount / Constants.FPS) <= 27.5)
                {
                    if (!Constants.invincible)
                    {
                        Constants.playerColor = Color.Yellow;
                        Constants.invertX = false;
                        Constants.invertY = true;
                    }
                    mob.UpdatePosition("down");
                    mob.UpdatePosition("down");
                }
                else if ((FrameCount / Constants.FPS) >= 29 && (FrameCount / Constants.FPS) <= 29.5)
                {
                    if (!Constants.invincible)
                    {
                        Constants.playerColor = Color.Yellow;
                        Constants.invertX = false;
                        Constants.invertY = true;
                    }
                    mob.UpdatePosition("down");
                    mob.UpdatePosition("down");
                }

                //the mobs move upRight otherwise
                else
                {
                    if (!Constants.invincible)
                    {
                        Constants.playerColor = Color.White;
                        Constants.invertX = false;
                        Constants.invertY = false;
                    }
                    mob.UpdatePosition("upRight");
                    mob.UpdatePosition("upRight");
                }
            }

            else if (FrameCount <= 38 * Constants.FPS)
            {
                // mobs teleport down when on C,G,K,O, or S
                if ((FrameCount / Constants.FPS) >= 31 && (FrameCount / Constants.FPS) <= 31.5)
                {
                    if (!Constants.invincible)
                    {
                        Constants.playerColor = Color.Aqua;
                        Constants.invertX = true;
                        Constants.invertY = false;
                    }
                    mob.UpdatePosition("down");
                    mob.UpdatePosition("down");
                }
                else if ((FrameCount / Constants.FPS) >= 33 && (FrameCount / Constants.FPS) <= 33.5)
                {
                    if (!Constants.invincible)
                    {
                        Constants.playerColor = Color.Aqua;
                        Constants.invertX = true;
                        Constants.invertY = false;
                    }
                    mob.UpdatePosition("down");
                    mob.UpdatePosition("down");
                }
                else if ((FrameCount / Constants.FPS) >= 35 && (FrameCount / Constants.FPS) <= 35.5)
                {
                    if (!Constants.invincible)
                    {
                        Constants.playerColor = Color.Aqua;
                        Constants.invertX = true;
                        Constants.invertY = false;
                    }
                    mob.UpdatePosition("down");
                    mob.UpdatePosition("down");
                }
                else if ((FrameCount / Constants.FPS) >= 37 && (FrameCount / Constants.FPS) <= 37.5)
                {
                    if (!Constants.invincible)
                    {
                        Constants.playerColor = Color.Aqua;
                        Constants.invertX = true;
                        Constants.invertY = false;
                    }
                    mob.UpdatePosition("down");
                    mob.UpdatePosition("down");
                }

                //the mobs move upRight otherwise
                else
                {
                    if (!Constants.invincible)
                    {
                        Constants.playerColor = Color.White;
                        Constants.invertX = false;
                        Constants.invertY = false;
                    }
                    mob.UpdatePosition("upLeft");
                    mob.UpdatePosition("upLeft");
                }
            }

            //small arc arcoss screen to exit
            else if (FrameCount > 38 * Constants.FPS )
            {
                if (!Constants.invincible)
                {
                    Constants.playerColor = Color.Lime;
                    Constants.invertX = true;
                    Constants.invertY = true;
                }
                if (FrameCount % 1 == 0)
                {
                    mob.UpdatePosition("right");
                }

                if (FrameCount % 1 == 0)
                {
                    mob.Position = new Vector2(mob.Position.X, Constants.H - 40 + (-(float)Math.Sin(mob.Position.X / 200) * 100));
                }
            }

            //bullets shoot every second after 4 seconds have passed
            if (FrameCount % 60 == 0 && mob.Active && FrameCount > 4 * Constants.FPS && mob.Position.X < 670)
            {
                Formation formation = new ZigZagFormation(new BulletMaker(), mob.Position);
                Bullets.Add(MoveScriptMaker.CreateMoveScript("ZigZag", formation.SetFormation(bulletType), false));
            }

            //changed the dead area outside the window so it wouldn't kill mobs when they spawn just off screen
            if (mob.Position.X < -60 || mob.Position.X > 670)
            {
                if (!Constants.invincible)
                {
                    Constants.playerColor = Color.White;
                    Constants.invertX = false;
                    Constants.invertY = false;
                }
                mob.Color = Color.TransparentBlack;
                //this.Active = false;
            }

            //if(frameCount>45*Constants.FPS)
            //{
            //    this.Active = false;
            //}
            foreach (MoveScript formation in Bullets)
            {
                formation.Update();
            }
            FrameCount++;
        }
    }
}
