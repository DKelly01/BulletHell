﻿using Microsoft.Xna.Framework;
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
        bool invincible;
        BulletMaker bulletMaker;
        Vector2 defaultStartPosition;

        public PlayerCharacter(MobBase mobBase, Vector2 startingPosition) : base(mobBase, startingPosition)
        {
            PrecisionSpeed = mobBase.MoveSpeed/2;
            Active = true;
            Position = startingPosition;
            Lives = 5;
            invincible = false;
            invincibleStartFrame = 0;
            bulletMaker = new BulletMaker();
            defaultStartPosition = startingPosition;
        }

        public void Update(Level level, KeyboardState kstate)
        {
            this.currentFrame = level.FrameCount;
            if (Active && currentFrame >= invincibleStartFrame + (Constants.FPS*Constants.INVINCIBLE_TIME))
            {
                invincible = false;
                this.Color = Color.White;
            }
            if (currentFrame == invincibleStartFrame)
            {
                List<MobileEntity> allMobs = level.GetPhaseMobs();
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
                    this.Position = defaultStartPosition;
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
            if (kstate.IsKeyDown(KeyBinds.Instance().Up) && Position.Y > Constants.BORDER + Constants.PLAYER_RADIUS)
            {
                UpdatePosition("up");
            }
            else if (kstate.IsKeyDown(KeyBinds.Instance().Down) && Position.Y < Constants.HEIGHT - Constants.BORDER - Constants.PLAYER_RADIUS)
            {
                UpdatePosition("down");
            }
            else if (kstate.IsKeyDown(KeyBinds.Instance().Left) && Position.X > Constants.BORDER + Constants.PLAYER_RADIUS) {
                UpdatePosition("left");
            }
            else if (kstate.IsKeyDown(KeyBinds.Instance().Right) && Position.X < Constants.PLAYABLE_WIDTH - Constants.PLAYER_RADIUS)
            {
                UpdatePosition("right");
            }
            else if (kstate.IsKeyDown(KeyBinds.Instance().UpLeft)) {
                if (Position.X > Constants.BORDER + Constants.PLAYER_RADIUS)
                {
                    UpdatePosition("left");
                }
                if (Position.Y > Constants.BORDER + Constants.PLAYER_RADIUS)
                {
                    UpdatePosition("up");
                }
            }
            else if (kstate.IsKeyDown(KeyBinds.Instance().UpRight))
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
            else if (kstate.IsKeyDown(KeyBinds.Instance().DownRight))
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
            else if (kstate.IsKeyDown(KeyBinds.Instance().DownLeft))
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
