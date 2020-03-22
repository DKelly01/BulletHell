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
        int Lives { get; set; }
        int invincibleStartFrame;
        int fireFrame;
        int currentFrame;
        bool invincible;
        KeyBinds KeyBinds;
        BulletMaker bulletMaker;

        public PlayerCharacter(MobBase mobBase, Vector2 startingPosition, KeyBinds keybinds) : base(mobBase, startingPosition)
        {
            PrecisionSpeed = mobBase.MoveSpeed/2;
            Active = true;
            Position = startingPosition;
            Lives = 5;
            invincible = false;
            invincibleStartFrame = 0;
            KeyBinds = keybinds;
            bulletMaker = new BulletMaker();
        }

        public void Update(Level level, KeyboardState kstate)
        {
            this.currentFrame = level.FrameCount;
            if (Active && currentFrame >= invincibleStartFrame + (Constants.FPS*Constants.INVINCIBLE_TIME))
            {
                invincible = false;
                this.Color = Color.White;
            }
            readKeyBoardInput(kstate, level);     
        }
        public override void TakeDamage(int damage)
        {
            if (!this.invincible)
            {
                this.Lives -= 1;
                if (this.Lives > 0)
                {
                    this.invincible = true;
                    this.Color = Color.Red;
                    this.invincibleStartFrame = this.currentFrame;
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
            if (kstate.IsKeyDown(KeyBinds.Slow))
            {
                this.MoveSpeed = PrecisionSpeed;
            }
            else {
                this.MoveSpeed = this.mobBase.MoveSpeed;
            }
            if (kstate.IsKeyDown(KeyBinds.Fire)){
                Fire(level);
            }
            if (kstate.IsKeyDown(KeyBinds.Up) && Position.Y > Constants.BORDER + Constants.PLAYER_RADIUS)
            {
                UpdatePosition("up");
            }
            else if (kstate.IsKeyDown(KeyBinds.Down) && Position.Y < Constants.HEIGHT - Constants.BORDER - Constants.PLAYER_RADIUS)
            {
                UpdatePosition("down");
            }
            else if (kstate.IsKeyDown(KeyBinds.Left) && Position.X > Constants.BORDER + Constants.PLAYER_RADIUS) {
                UpdatePosition("left");
            }
            else if (kstate.IsKeyDown(KeyBinds.Right) && Position.X < Constants.PLAYABLE_WIDTH - Constants.PLAYER_RADIUS)
            {
                UpdatePosition("right");
            }
            else if (kstate.IsKeyDown(KeyBinds.UpLeft)) {
                if (Position.X > Constants.BORDER + Constants.PLAYER_RADIUS)
                {
                    UpdatePosition("left");
                }
                if (Position.Y > Constants.BORDER + Constants.PLAYER_RADIUS)
                {
                    UpdatePosition("up");
                }
            }
            else if (kstate.IsKeyDown(KeyBinds.UpRight))
            {
                if (Position.X < Constants.PLAYABLE_WIDTH - Constants.PLAYER_RADIUS)
                {
                    UpdatePosition("right");
                }
                if (Position.Y > Constants.BORDER + Constants.PLAYER_RADIUS)
                {
                    UpdatePosition("up");
                }
            }
            else if (kstate.IsKeyDown(KeyBinds.DownRight))
            {
                if (Position.X < Constants.PLAYABLE_WIDTH - Constants.PLAYER_RADIUS)
                {
                    UpdatePosition("right");
                }
                if (Position.Y < 500)
                {
                    UpdatePosition("down");
                }
            }
            else if (kstate.IsKeyDown(KeyBinds.DownLeft))
            {
                if (Position.X > Constants.BORDER + Constants.PLAYER_RADIUS)
                {
                    UpdatePosition("left");
                }
                if (Position.Y < 500)
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
