using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1.MoveScripts
{
    class MoveScript
    {
        internal int FrameCount { get; set; }
        internal List<MobileEntity> Mobs { get; set; }
        //List<BulletFormation> bullets;
        internal List<MoveScript> Bullets;
        internal bool willFire;
        internal MobMaker MobMaker;
        public bool Active { get; set; }

        //internal List<BulletFormation> Bullets { get; set; }

        /// <summary>
        /// Available movement types: CanCan, EllLeft, EllRight
        /// Solo_B_Right,MidBoss,ZigRight,ZagLeft,SinRight
        /// SinLeft,DiagonalRight,DiagonalLeft
        /// </summary>
        /// <param name="type"></param>
        /// <param name="mobs"></param>
        public MoveScript(List<MobileEntity> mobs, bool willFire)
        {
            this.Name = name ?? throw new ArgumentNullException(nameof(name));
            this.Mobs = mobs ?? throw new ArgumentNullException(nameof(mobs));
            this.Bullets = new List<MoveScript>();
            this.willFire = willFire;
            this.FrameCount = 0;
            this.MobMaker = mobMaker;
        }

        public virtual void Update()
        {
            foreach (MobileEntity mob in Mobs)
            {
                mob.UpdatePosition("down");
                if (mob.Position.Y >= Constants.HEIGHT)
                {
                    mob.Active = false;
                }
            }
            //if (this.moveType == "CanCan")
            //{
            //    CanCan();
            //}
            //else if (this.moveType == "EllRight")
            //{
            //    EllRight();
            //}
            //else if (this.moveType == "EllLeft")
            //{
            //    EllLeft();
            //}
            //else if (this.moveType == "Solo_B_Right")
            //{
            //    Solo_B_Right();
            //}
            //else if (this.moveType == "MidBoss")
            //{
            //    MidBoss();
            //}
            //else if (this.moveType == "ZigRight")
            //{
            //    ZigRight();
            //}
            //else if (this.moveType == "ZagLeft")
            //{
            //    ZagLeft();
            //}
            //else if (this.moveType == "SinRight")
            //{
            //    SinRight();
            //}
            //else if (this.moveType == "SinLeft")
            //{
            //    SinLeft();
            //}
            //else if (this.moveType == "DiagonalRight")
            //{
            //    DiagonalRight();
            //}
            //else if (this.moveType == "DiagonalLeft")
            //{
            //    DiagonalLeft();
            //}
            //else if (this.moveType == "Boss1")
            //{
            //    Boss1();
            //}
            //else if (this.moveType == "Boss2")
            //{
            //    Boss2();
            //}
            foreach (MoveScript formation in Bullets)
            {
                formation.Update();
            }
            FrameCount++;
        }

        /// <summary>
        /// Movement pattern for entering top left and leaving top right
        /// </summary>
        /// <param name="type"></param>
        /// <param name="mobs"></param>
        private void DiagonalLeft()
        {
            int firingInterval = 3;
            int mobFiringInterval = 3;
            string pattern = "Arc";
            string trajectory = "Arrowhead";
            int numBullets = 1;
            string bulletType = "BulletTypeA";
            if (frameCount == 0)
            {
                foreach (MobileEntity mob in mobs)
                {
                    mob.Position = new Vector2((660 + 60 * mobs.IndexOf(mob)), (0 - 60 * mobs.IndexOf(mob)));  
                }
            }
            foreach (MobileEntity mob in mobs)
            {
                if (frameCount % (firingInterval * Constants.FPS) == 0 && frameCount > 0)
                {
                    if(mobs.IndexOf(mob)%mobFiringInterval==0)
                    fire(pattern, mob, bulletType, mob.Color, numBullets, trajectory);
                }
                //mobs enter from top right corner of screen, move to center 
                if (mob.Position.X >= 327)
                {
                    if (mob.Position.X<Constants.PLAYABLE_WIDTH)
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
        }

        /// <summary>
        /// Movement pattern for entering top right and leaving top left
        /// </summary>
        /// <param name="type"></param>
        /// <param name="mobs"></param>
        private void DiagonalRight()
        {
            if (frameCount == 0)
            {
                foreach (MobileEntity mob in mobs)
                {
                    mob.Position = new Vector2((0 - 60 * mobs.IndexOf(mob)), (0 - 60 * mobs.IndexOf(mob)));
                    mob.Active = true;
                }
            }
            foreach (MobileEntity mob in mobs)
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
                    if(mob.Position.X>Constants.PLAYABLE_WIDTH || mob.Position.Y <= 0)
                    {
                        mob.Active = false;
                    }
                }
            }
        }

        /// <summary>
        /// CanCan should take an even number of mobs to work out well
        /// </summary>
        private void CanCan()
        {
            
        }

        private void fire(string pattern, MobileEntity mob, string bulletType, Color color, int numBullets, string trajectory)
        {
            if (this.willFire && mob.Active)
            {
                Bullets.Add(new BulletFormationOLD(pattern, mob.Position, bulletType, Color.White, 10, trajectory));
            }
        }

        private void EllRight()
        {
            //set up initial positioning
            if (frameCount == 0)
            {
                foreach (MobileEntity mob in mobs)
                {
                    mob.Position = new Vector2(Constants.R, -30 * (mobs.IndexOf(mob) + 1));
                    mob.Active = true;
                }
            }
            foreach (MobileEntity mob in mobs)
            {
                if (mob.Position.Y < Constants.G)
                {
                    mob.UpdatePosition("down");
                }
                else mob.UpdatePosition("left");
                if (mob.Position.X < 0)
                {
                    mob.Active = false;
                }
            }
        }

        private void EllLeft()
        {
            //set up initial positioning
            if (frameCount == 0)
            {
                foreach (MobileEntity mob in mobs)
                {
                    mob.Position = new Vector2(Constants.D, -30 * (mobs.IndexOf(mob) + 1));
                    mob.Active = true;
                }
            }
            foreach (MobileEntity mob in mobs)
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

        private void Solo_B_Right()
        {
            string bulletType = "BulletTypeB";
            string trajectory = "Arrowhead";
            string pattern = "Arrowhead";
            int numBullets = 10;
            MobileEntity mob = mobs[0];
            if (frameCount == 0)
            {
                mob.Position = new Vector2(Constants.P, -30);
                mob.Active = true;
            }
            else if (mob.Position.Y < Constants.F)
            {
                mob.UpdatePosition("down");
            }
            else if (frameCount % 120 == 0 && mob.Active)
            {
                Bullets.Add(new BulletFormationOLD(pattern, mob.Position, bulletType, Color.White, 10, trajectory));
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

        private void MidBoss()
        {
            string bulletType = "BulletTypeA";
            int numBullets = 10;
            int timeCap = 26 * Constants.FPS;
            MobileEntity mob = mobs[0];
            if (frameCount == 0)
            {
                mob.Position = new Vector2(Constants.K, -30);
                mob.Active = true;
            }
            else if (mob.Position.Y < Constants.E && frameCount <= 100)
            {
                mob.UpdatePosition("down");
            }
            else if (frameCount > 200 && frameCount <= 260)
            {
                if (mob.Position.X < Constants.M)
                {
                    mob.UpdatePosition("upRight");
                }
                if (frameCount % 250 == 0)
                {
                    fire("Arc", mob, bulletType, Color.White, numBullets,"Arrowhead");
                    //Bullets.Add(new BulletFormation("Arc", mob.Position, bulletType, Color.White, 10, "Arrowhead"));
                }
            }
            else if (frameCount > 320 && frameCount <= 380)
            {
                if (mob.Position.X < Constants.P)
                {
                    mob.UpdatePosition("downRight");
                }
                if (frameCount % 370 == 0)
                {
                    fire("Arc", mob, bulletType, Color.White, numBullets, "Arc");
                    //Bullets.Add(new BulletFormation("Arc", mob.Position, bulletType, Color.White, 10, "Arc"));
                }
            }
            else if (frameCount > 440 && frameCount <= 500)
            {
                if (mob.Position.X > Constants.M)
                {
                    mob.UpdatePosition("left");
                }
                if (frameCount % 480 == 0)
                {
                    fire("Arc", mob, bulletType, Color.White, numBullets, "Arrowhead");
                    //Bullets.Add(new BulletFormation("Arc", mob.Position, bulletType, Color.White, 10, "Arrowhead"));
                }
            }
            else if (frameCount > 560 && frameCount <= 620)
            {

                if (mob.Position.Y > Constants.C)
                {
                    mob.UpdatePosition("up");
                }
                if (frameCount % 600 == 0)
                {
                    fire("Arc", mob, bulletType, Color.White, numBullets, "Arc");
                    //Bullets.Add(new BulletFormation("Arc", mob.Position, bulletType, Color.White, 10, "Arc"));
                }
            }
            else if (frameCount > 680 && frameCount <= 740)
            {
                if (mob.Position.X > Constants.J)
                {
                    mob.UpdatePosition("downLeft");
                }
                if (frameCount % 720 == 0)
                {
                    fire("Arc", mob, bulletType, Color.White, numBullets, "Arrowhead");
                    //Bullets.Add(new BulletFormation("Arc", mob.Position, bulletType, Color.White, 10, "Arrowhead"));
                }
            }
            else if (frameCount > 800 && frameCount <= 860)
            {
                if (mob.Position.X < Constants.M)
                {
                    mob.UpdatePosition("right");
                }
                if (frameCount % 840 == 0)
                {
                    fire("Arc", mob, bulletType, Color.White, numBullets, "Arc");
                    //Bullets.Add(new BulletFormation("Arc", mob.Position, bulletType, Color.White, 10, "Arc"));
                }
            }
            else if (frameCount > 920 && frameCount <= 980)
            {
                if (mob.Position.X > Constants.J)
                {
                    mob.UpdatePosition("upLeft");
                }
                if (frameCount % 960 == 0)
                {
                    fire("Arc", mob, bulletType, Color.White, numBullets, "Arrowhead");
                    //Bullets.Add(new BulletFormation("Arc", mob.Position, bulletType, Color.White, 10, "Arrowhead"));
                }
            }
            else if (frameCount > 1040 && frameCount <= 1100)
            {
                if (mob.Position.X > Constants.G)
                {
                    mob.UpdatePosition("left");
                }
                if (frameCount % 1080 == 0)
                {
                    fire("Arc", mob, bulletType, Color.White, numBullets, "Arc");
                    //Bullets.Add(new BulletFormation("Arc", mob.Position, bulletType, Color.White, 10, "Arc"));
                }
            }
            else if (frameCount > 1160 && frameCount <= 1220)
            {
                if (mob.Position.Y > Constants.B)
                {
                    mob.UpdatePosition("up");
                }
                if (frameCount % 1200 == 0)
                {
                    fire("Arc", mob, bulletType, Color.White, numBullets, "Arrowhead");
                    //Bullets.Add(new BulletFormation("Arc", mob.Position, bulletType, Color.White, 10, "Arrowhead"));
                }
            }
            else if (frameCount > 1280 && frameCount <= 1340)
            {
                if (mob.Position.Y < Constants.E)
                {
                    mob.UpdatePosition("downLeft");
                }
                if (frameCount % 1320 == 0)
                {
                    fire("Arc", mob, bulletType, Color.White, numBullets, "Arc");
                    //Bullets.Add(new BulletFormation("Arc", mob.Position, bulletType, Color.White, 10, "Arc"));
                }
            }
            else if (frameCount > 1440 && frameCount <= 1460)
            {
                if (mob.Position.X > Constants.H)
                {
                    mob.UpdatePosition("upLeft");
                }
                if (frameCount % 1440 == 0)
                {
                    fire("Arc", mob, bulletType, Color.White, numBullets, "Arrowhead");
                    //Bullets.Add(new BulletFormation("Arc", mob.Position, bulletType, Color.White, 6, "Arrowhead"));
                }
            }
            else if (frameCount > timeCap)
            {
                mob.UpdatePosition("up");
                if (mob.Position.Y <= 0)
                {
                    mob.Active = false;
                }
            }
        }
        
        /// <summary>
        /// Movement pattern for entering at E on the left and moving right in a zig zag
        /// </summary>
        /// <param name="type"></param>
        /// <param name="mobs"></param>
        private void ZigRight()
        {
            if (frameCount == 0)
            {
                foreach (MobileEntity mob in mobs)
                {
                    mob.Position = new Vector2((0 - 60 * mobs.IndexOf(mob)), Constants.E);
                    mob.Active = true;
                }
            }
            foreach (MobileEntity mob in mobs)
            {
                //mobs enter from right at E, then move upRight between 0-C, G-K, O-S
                if (mob.Position.X >= 0 && mob.Position.X < Constants.C || mob.Position.X >= Constants.G && mob.Position.X < Constants.K || mob.Position.X >= Constants.O && mob.Position.X < Constants.S)
                {
                    mob.UpdatePosition("upRight");
                }
                //the mobs move downRight between C-G, K-O, S-V
                else if (mob.Position.X >= Constants.C && mob.Position.X < Constants.G || mob.Position.X >= Constants.K && mob.Position.X < Constants.O || mob.Position.X >= Constants.S && mob.Position.X < Constants.V)
                {
                    mob.UpdatePosition("downRight");
                }
                // just go right if off the either side of the screen
                else
                {
                    mob.UpdatePosition("right");
                    if (mob.Position.X > Constants.PLAYABLE_WIDTH)
                    {
                        mob.Active = false;
                    }
                }
            }
        }
        
        /// <summary>
        /// Movement pattern for entering at E on the right and moving left in a zig zag
        /// </summary>
        /// <param name="type"></param>
        /// <param name="mobs"></param>
        private void ZagLeft()
        {
            if (frameCount == 0)
            {
                foreach (MobileEntity mob in mobs)
                {
                    mob.Position = new Vector2((660 + 60 * mobs.IndexOf(mob)), Constants.E);
                    //mob.Active = true;
                }
            }
            foreach (MobileEntity mob in mobs)
            {

                if (mob.Position.X < Constants.PLAYABLE_WIDTH && mob.Position.X>0)
                {
                    mob.Active = true;
                }
                //mobs enter from Left at E, then move upLeft between 0-C, G-K, O-S
                if (mob.Position.X >= 0 && mob.Position.X < Constants.C || mob.Position.X >= Constants.G && mob.Position.X < Constants.K || mob.Position.X >= Constants.O && mob.Position.X < Constants.S)
                {
                    mob.UpdatePosition("upLeft");
                }
                //the mobs move downLeft between C-G, K-O, S-V
                else if (mob.Position.X >= Constants.C && mob.Position.X < Constants.G || mob.Position.X >= Constants.K && mob.Position.X < Constants.O || mob.Position.X >= Constants.S && mob.Position.X < Constants.V)
                {
                    mob.UpdatePosition("downLeft");
                }
                // just go left if off the either side of the screen
                else
                {
                    mob.UpdatePosition("left");
                    if (mob.Position.X <= 0)
                    {
                        mob.Active = false;
                    }
                }
            }
        }

        /// <summary>
        /// Movement pattern for entering at E on the left and moving right in a sin wave accross the screen
        /// </summary>
        /// <param name="type"></param>
        /// <param name="mobs"></param>
        private void SinRight()
        {
            // start at E off screen
            if (frameCount == 0)
            {
                foreach (MobileEntity mob in mobs)
                {
                    mob.Position = new Vector2((0 - 60 * mobs.IndexOf(mob)), Constants.E);
                    mob.Active = true;
                }
            }

            // x and y are seporate so that the framecount mod can be changed seporately for more fine control
            foreach (MobileEntity mob in mobs)
            {
                if (frameCount % 1 == 0)
                {
                    mob.UpdatePosition("right");
                }

                if (frameCount % 1 == 0)
                {
                    mob.Position = new Vector2(mob.Position.X, Constants.E + (-(float)Math.Cos(mob.Position.X / 50) * 150));
                }
                if (mob.Position.X > Constants.PLAYABLE_WIDTH)
                {
                    mob.Active = false;
                }
            }
        }

        /// <summary>
        /// Movement pattern for entering at E on the right and moving left in a sin wave accross the screen
        /// </summary>
        /// <param name="type"></param>
        /// <param name="mobs"></param>
        private void SinLeft()
        {
            // start at E off screen
            if (frameCount == 0)
            {
                foreach (MobileEntity mob in mobs)
                {
                    mob.Position = new Vector2((660 + 60 * mobs.IndexOf(mob)), Constants.E);
                    //mob.Active = true;
                }
            }

            // x and y are seporate so that the framecount mod can be changed seporately for more fine control
            foreach (MobileEntity mob in mobs)
            {
                if (mob.Position.X < Constants.PLAYABLE_WIDTH && mob.Position.X > 0)
                {
                    mob.Active = true;
                }
                if (frameCount % 1 == 0)
                {
                    mob.UpdatePosition("left");
                }

                if (frameCount % 1 == 0)
                {
                    mob.Position = new Vector2(mob.Position.X, Constants.E + (-(float)Math.Cos(mob.Position.X / 50) * 150));
                }
                if (mob.Position.X <= 0)
                {
                    mob.Active = false;
                }
            }
        }

        private void Boss1()
        {
            MobileEntity mob = mobs[0];
            string bulletType = "BulletTypeB";
            int numBullets = 10;
            //Enter at P at top of screen
            if (frameCount == 0)
            {
                mob.Position = new Vector2(Constants.P, -30);
                mob.Active = true;
            }

            //ZigZag down for 4 seconds
            else if (frameCount <= 4 * Constants.FPS)
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
            else if (frameCount <= 10 * Constants.FPS)
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
            else if (frameCount <= 15 * Constants.FPS)
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
            else if (frameCount <= 22 * Constants.FPS)
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
            else if (frameCount <= 30 * Constants.FPS)
            {
                // mobs teleport down when on C,G,K,O, or S
                if ((frameCount / Constants.FPS) >= 23 && (frameCount / Constants.FPS) <= 23.5)
                {
                    mob.UpdatePosition("down");
                    mob.UpdatePosition("down");
                }
                else if ((frameCount / Constants.FPS) >= 25 && (frameCount / Constants.FPS) <= 25.5)
                {
                    mob.UpdatePosition("down");
                    mob.UpdatePosition("down");
                }
                else if ((frameCount / Constants.FPS) >= 27 && (frameCount / Constants.FPS) <= 27.5)
                {
                    mob.UpdatePosition("down");
                    mob.UpdatePosition("down");
                }
                else if ((frameCount / Constants.FPS) >= 29 && (frameCount / Constants.FPS) <= 29.5)
                {
                    mob.UpdatePosition("down");
                    mob.UpdatePosition("down");
                }

                //the mobs move upRight otherwise
                else
                {
                    mob.UpdatePosition("upRight");
                    mob.UpdatePosition("upRight");
                }
            }

            else if (frameCount <= 38 * Constants.FPS)
            {
                // mobs teleport down when on C,G,K,O, or S
                if ((frameCount / Constants.FPS) >= 31 && (frameCount / Constants.FPS) <= 31.5)
                {
                    mob.UpdatePosition("down");
                    mob.UpdatePosition("down");
                }
                else if ((frameCount / Constants.FPS) >= 33 && (frameCount / Constants.FPS) <= 33.5)
                {
                    mob.UpdatePosition("down");
                    mob.UpdatePosition("down");
                }
                else if ((frameCount / Constants.FPS) >= 35 && (frameCount / Constants.FPS) <= 35.5)
                {
                    mob.UpdatePosition("down");
                    mob.UpdatePosition("down");
                }
                else if ((frameCount / Constants.FPS) >= 37 && (frameCount / Constants.FPS) <= 37.5)
                {
                    mob.UpdatePosition("down");
                    mob.UpdatePosition("down");
                }

                //the mobs move upRight otherwise
                else
                {
                    mob.UpdatePosition("upLeft");
                    mob.UpdatePosition("upLeft");
                }
            }

            //small arc arcoss screen to exit
            else if (frameCount > 38 * Constants.FPS && frameCount < 45 * Constants.FPS)
            {
                if (frameCount % 1 == 0)
                {
                    mob.UpdatePosition("right");
                }

                if (frameCount % 1 == 0)
                {
                    mob.Position = new Vector2(mob.Position.X, Constants.H + (-(float)Math.Sin(mob.Position.X / 200) * 100));
                }
            }

            //bullets shoot every second after 4 seconds have passed
            if (frameCount % 60 == 0 && mob.Active && frameCount > 4 * Constants.FPS)
            {
                fire("ZigZag", mob, bulletType, Color.White, 3, "ZigZag");
                //Bullets.Add(new BulletFormation("Arrowhead", mob.Position, bulletType, Color.White, numBullets, "ZigZag"));
            }

            //changed the dead area outside the window so it wouldn't kill mobs when they spawn just off screen
            if (mob.Position.X < -60 || mob.Position.X > 670)
            {
                mob.Color = Color.Red;
                //this.Active = false;
            }
            
            //if(frameCount>45*Constants.FPS)
            //{
            //    this.Active = false;
            //}

        }

        private void Boss2()
        {
            MobileEntity mob = mobs[0];
            string bulletType = "BulletTypeB";
            int numBullets = 10;
            if (frameCount == 0)
            {
                mob.Position = new Vector2(-30, Constants.A);
                mob.Active = true;
            }

            //start sin wave from top left
            else if (frameCount <= 11 * Constants.FPS)
            {
                if (frameCount % 1 == 0)
                {
                    mob.UpdatePosition("right");
                }

                if (frameCount % 1 == 0)
                {
                    mob.Position = new Vector2(mob.Position.X, Constants.E + (-(float)Math.Cos(mob.Position.X / 50) * 150));
                }
            }

            //sin wave back right
            else if (frameCount <= 22 * Constants.FPS)
            {
                if (frameCount % 1 == 0)
                {
                    mob.UpdatePosition("left");
                }

                if (frameCount % 1 == 0)
                {
                    mob.Position = new Vector2(mob.Position.X, Constants.E + (-(float)Math.Cos(mob.Position.X / 50) * 150));
                }
            }

            //diagnal from top left
            else if (frameCount <= 33 * Constants.FPS)
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
            else if (frameCount <= 43 * Constants.FPS)
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
            else if (frameCount > 43 * Constants.FPS)
            {
                if (frameCount % 1 == 0)
                {
                    mob.UpdatePosition("right");
                }

                if (frameCount % 1 == 0)
                {
                    mob.Position = new Vector2(mob.Position.X, Constants.E + (-(float)Math.Sin(mob.Position.X / 10) * 150));
                }
            }

            //bullets shoot every second after 4 seconds have passed
            if (frameCount % 60 == 0 && mob.Active && frameCount > 4 * Constants.FPS)
            {
                fire("ZigZag", mob, bulletType, Color.White, 3, "ZigZag");
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

        }
    }
}

