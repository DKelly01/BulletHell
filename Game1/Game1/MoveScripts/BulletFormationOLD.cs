﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1.MoveScripts
{
    class BulletFormation
    {
        
        string pattern;
        string trajectory;
        internal List<MobileEntity> Bullets { get; set; }

        public BulletFormation(string pattern, Vector2 startingPosition, string bulletType, Color color, int numBullets, string trajectory)
        {
            this.pattern = pattern;
            this.trajectory = trajectory;
            if (pattern == "Arrowhead")
            {
                Bullets = BulletMakerOLD.CreateBulletFormation(numBullets, bulletType, startingPosition, "Arrowhead", color);
            }
            if (pattern == "Arc")
            {
                Bullets = BulletMakerOLD.CreateBulletFormation(numBullets, bulletType, startingPosition, "Arc", color);
            }
            if (pattern == "ZigZag")
            {
                Bullets = BulletMakerOLD.CreateBulletFormation(3, bulletType, startingPosition, "ZigZag", color);
            }
        }

        void UpdateArrowhead()
        {
            foreach (MobileEntity bullet in Bullets)
            {
                bullet.UpdatePosition("down");
                if (bullet.Position.Y >= Constants.HEIGHT)
                {
                    bullet.Active = false;
                }
            }
        }

        void UpdateArc()
        {
            for (int i =0; i<bullets.Count;i++)
            {
                if (i == 0)
                {
                    bullets[i].UpdatePosition("left");
                    if (bullets[i].Position.X <= 0)
                    {
                        bullets[i].Active = false;
                    }
                }
                else if (i == bullets.Count - 1)
                {
                    bullets[i].UpdatePosition("right");
                    if (bullets[i].Position.X >= Constants.PLAYABLE_WIDTH)
                    {
                        bullets[i].Active = false;
                    }
                }
                else if (i == bullets.Count / 2 || i == (bullets.Count / 2) -1)
                {
                    bullets[i].UpdatePosition("down");
                    if (bullets[i].Position.Y >= Constants.HEIGHT)
                    {
                        bullets[i].Active = false;
                    }
                }
                else if (i!=0 && i < (bullets.Count / 2)-1)
                {
                    bullets[i].UpdatePosition("downLeft");
                    if (bullets[i].Position.Y >= Constants.HEIGHT)
                    {
                        bullets[i].Active = false;
                    }
                    if (bullets[i].Position.X <= 0)
                    {
                        bullets[i].Active = false;
                    }
                }
                else if (i> (bullets.Count / 2) - 1 && i< bullets.Count-1)
                {
                    bullets[i].UpdatePosition("downRight");
                    if (bullets[i].Position.Y >= Constants.HEIGHT)
                    {
                        bullets[i].Active = false;
                    }
                    if (bullets[i].Position.X >= Constants.PLAYABLE_WIDTH)
                    {
                        bullets[i].Active = false;
                    }
                }
            }
        }

        void UpdateZigZag()
        {
            Random rand = new Random();
            //outside bullets drift farther out, change the % 4 to change how far out the side ones move
            if ((((Bullets[0].Position.Y % 100) - (Bullets[0].Position.Y % 10)) / 10) % 4 == 0)
            {
                Bullets[0].UpdatePosition("downRight");
                Bullets[2].UpdatePosition("downLeft");
                Bullets[0].Color = new Color(rand.Next(256), rand.Next(256), rand.Next(256));
                Bullets[2].Color = new Color(rand.Next(256), rand.Next(256), rand.Next(256));
            }
            else
            {
                Bullets[0].UpdatePosition("downLeft");
                Bullets[2].UpdatePosition("downRight");
                Bullets[0].Color = new Color(rand.Next(256), rand.Next(256), rand.Next(256));
                Bullets[2].Color = new Color(rand.Next(256), rand.Next(256), rand.Next(256));
            }

            if (Bullets[0].Position.Y >= Constants.HEIGHT)
            {
                Bullets[0].Active = false;
                Bullets[2].Active = false;
            }

            //middle bullet wiggles and goes down
            if ((((Bullets[1].Position.Y % 100) - (Bullets[1].Position.Y % 10)) / 10) % 2 == 0)
            {
                Bullets[1].UpdatePosition("downRight");
                Bullets[1].Color = new Color(rand.Next(256), rand.Next(256), rand.Next(256));
            }
            else
            {
                Bullets[1].UpdatePosition("downLeft");
                Bullets[1].Color = new Color(rand.Next(256), rand.Next(256), rand.Next(256));
            }

            if (Bullets[1].Position.Y >= Constants.HEIGHT)
            {
                Bullets[0].Active = false;
            }
        }
        public void Update()
        {
            if (trajectory == "Arrowhead")
            {
                UpdateArrowhead();
            }
            else if (trajectory == "Arc")
            {
                UpdateArc();
            }
            else if (trajectory == "ZigZag")
            {
                UpdateZigZag();
            }
        }
    }
}