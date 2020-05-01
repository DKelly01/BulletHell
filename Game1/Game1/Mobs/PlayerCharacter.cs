using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;
using Game1.Mobs;

namespace Game1.Level
{
    class PlayerCharacter : MobileEntity
    {
        public float PrecisionSpeed { get; set; }
        public int Lives { get; set; }
        int invincibleStartFrame;
        int fireFrame;
        int currentFrame;
        BulletMaker bulletMaker;
        Vector2 defaultStartPosition;

        public PlayerCharacter(MobBase mobBase, Vector2 startingPosition) : base(mobBase, startingPosition)
        {
            PrecisionSpeed = mobBase.MoveSpeed/2;
            Active = true;
            Position = startingPosition;
            Lives = 5;
            Constants.invincible = false;
            invincibleStartFrame = 0;
            bulletMaker = new BulletMaker();
            defaultStartPosition = startingPosition;
            Constants.playerColor = Color.White;
            Constants.playerPoints = mobBase.PointValue;
            Constants.invertX = false;
            Constants.invertY = false;
        }

        public void Update(Level level, KeyboardState kstate)
        {
            this.currentFrame = level.FrameCount;
            this.Color = Constants.playerColor;
            if (Active && currentFrame >= invincibleStartFrame + (Constants.FPS*Constants.INVINCIBLE_TIME))
            {
                Constants.invincible = false;
                Constants.playerColor = Color.White;
            }
            if (currentFrame == invincibleStartFrame)
            {
                Constants.playerColor = Color.Red;
                Constants.invertX = false;
                Constants.invertY = false;
            }
            readKeyBoardInput(kstate, level);     
        }
        public override void TakeDamage(int damage)
        {
            if (!Constants.invincible)
            {
                this.Lives -= 1;
                if (this.Lives > 0)
                {
                    Constants.invincible = true;
                    this.invincibleStartFrame = this.currentFrame;
                    this.Position = defaultStartPosition;
                    Constants.playerColor = Color.Red;
                    Constants.invertX = false;
                    Constants.invertY = false;
                }
                else
                {
                    this.Active = false;
                    this.Color = Color.Black;
                }
                

            }
            
        }

        void readKeyBoardInput(KeyboardState kstate, Level level)
        {
            if (kstate.IsKeyDown(KeyBinds.Instance().Slow))
            {
                this.MoveSpeed = PrecisionSpeed;
            }
            else {
                this.MoveSpeed = this.mobBase.MoveSpeed;
            }
            if (kstate.IsKeyDown(KeyBinds.Instance().Fire)){
                Fire(level);
            }
            if (kstate.IsKeyDown(KeyBinds.Instance().Up))
            {
                if (Constants.invertY && Position.Y < Constants.HEIGHT - Constants.BORDER - Constants.PLAYER_RADIUS)
                {
                    UpdatePosition("down");
                }
                else if (!Constants.invertY && Position.Y > Constants.BORDER + Constants.PLAYER_RADIUS)
                {
                    UpdatePosition("up");
                }
            }
            else if (kstate.IsKeyDown(KeyBinds.Instance().Down))
            {
                if (Constants.invertY && Position.Y > Constants.BORDER + Constants.PLAYER_RADIUS)
                {
                    UpdatePosition("up");
                }
                else if(!Constants.invertY && Position.Y < Constants.HEIGHT - Constants.BORDER - Constants.PLAYER_RADIUS)
                {
                    UpdatePosition("down");
                }
            }
            else if (kstate.IsKeyDown(KeyBinds.Instance().Left))
            {
                if (Constants.invertX && Position.X < Constants.PLAYABLE_WIDTH - Constants.PLAYER_RADIUS)
                {
                    UpdatePosition("right");
                }
                else if (!Constants.invertX && Position.X > Constants.BORDER + Constants.PLAYER_RADIUS)
                {
                    UpdatePosition("left");
                }
            }
            else if (kstate.IsKeyDown(KeyBinds.Instance().Right))
            {
                if (Constants.invertX && Position.X > Constants.BORDER + Constants.PLAYER_RADIUS)
                {
                    UpdatePosition("left");
                }
                else if (!Constants.invertX && Position.X < Constants.PLAYABLE_WIDTH - Constants.PLAYER_RADIUS)
                {
                    UpdatePosition("right");
                }
            }
            else if (kstate.IsKeyDown(KeyBinds.Instance().UpLeft)) {
                if (Constants.invertX && Position.X < Constants.PLAYABLE_WIDTH - Constants.PLAYER_RADIUS)
                {
                    UpdatePosition("right");
                }
                else if (!Constants.invertX && Position.X > Constants.BORDER + Constants.PLAYER_RADIUS)
                {
                    UpdatePosition("left");
                }
                if (Constants.invertY && Position.Y < Constants.HEIGHT - Constants.BORDER - Constants.PLAYER_RADIUS)
                {
                    UpdatePosition("down");
                }
                else if (!Constants.invertY && Position.Y > Constants.BORDER + Constants.PLAYER_RADIUS)
                {
                    UpdatePosition("up");
                }
            
            }
            else if (kstate.IsKeyDown(KeyBinds.Instance().UpRight))
            {
                if (Constants.invertX && Position.X > Constants.BORDER + Constants.PLAYER_RADIUS)
                {
                    UpdatePosition("left");
                }
                else if (!Constants.invertX && Position.X < Constants.PLAYABLE_WIDTH - Constants.PLAYER_RADIUS)
                {
                    UpdatePosition("right");
                }
                if (Constants.invertY && Position.Y < Constants.HEIGHT - Constants.BORDER - Constants.PLAYER_RADIUS)
                {
                    UpdatePosition("down");
                }
                else if (!Constants.invertY && Position.Y > Constants.BORDER + Constants.PLAYER_RADIUS)
                {
                    UpdatePosition("up");
                }
            }
            else if (kstate.IsKeyDown(KeyBinds.Instance().DownRight))
            {
                if (Constants.invertX && Position.X > Constants.BORDER + Constants.PLAYER_RADIUS)
                {
                    UpdatePosition("left");
                }
                else if (!Constants.invertX && Position.X < Constants.PLAYABLE_WIDTH - Constants.PLAYER_RADIUS)
                {
                    UpdatePosition("right");
                }
                if (Constants.invertY && Position.Y > Constants.BORDER + Constants.PLAYER_RADIUS)
                {
                    UpdatePosition("up");
                }
                else if (!Constants.invertY && Position.Y < Constants.HEIGHT - Constants.BORDER - Constants.PLAYER_RADIUS)
                {
                    UpdatePosition("down");
                }
            }
            else if (kstate.IsKeyDown(KeyBinds.Instance().DownLeft))
            {
                if (Constants.invertX && Position.X < Constants.PLAYABLE_WIDTH - Constants.PLAYER_RADIUS)
                {
                    UpdatePosition("right");
                }
                else if (!Constants.invertX && Position.X > Constants.BORDER + Constants.PLAYER_RADIUS)
                {
                    UpdatePosition("left");
                }
                if (Constants.invertY && Position.Y > Constants.BORDER + Constants.PLAYER_RADIUS)
                {
                    UpdatePosition("up");
                }
                else if (!Constants.invertY && Position.Y < Constants.HEIGHT - Constants.BORDER - Constants.PLAYER_RADIUS)
                {
                    UpdatePosition("down");
                }
            
            }
        }

        private void Fire(Level level)
        {
            if (fireFrame <= currentFrame - (Constants.FPS * Constants.FIRE_RATE))
            {
                fireFrame = currentFrame;
                level.playerBullets.Add(bulletMaker.CreateMob("BulletTypeA", Position));
            }   
        }
    }
}
