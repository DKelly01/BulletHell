using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game1.Mobs;
using Game1;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game1
{
    public class MobileEntity
    {
        public int HitRadius { get => this.mobBase.HitRadius; }
        public Vector2 Position { get; set; }
        public float MoveSpeed { get; set; }
        public string MobType { get=> this.mobBase.MobType;  }
        public bool Active {get;set;}
        public Color Color { get; set; }
        public int HP { get => this.mobBase.HP; }
        public int Damage { get=>this.mobBase.Damage; }
        public int pointValue { get; set; }
        internal MobBase mobBase;

        public MobileEntity(MobBase mobBase, Vector2 startingPosition)
        {
            this.mobBase = mobBase;
            this.MoveSpeed = mobBase.MoveSpeed;
            Position = startingPosition;
            Active = true;
            Color = Color.White;
            pointValue = mobBase.PointValue;
        }

        /// <summary>
        /// changes the position of a mobile entity
        /// possible directions: up, down, left, right
        /// upLeft, upRight, downLeft, downRight
        /// </summary>
        /// <param name="direction"></param>
        public void UpdatePosition(string direction)
        {
            Vector2 up = new Vector2(0 * MoveSpeed, -1 * MoveSpeed);
            Vector2 down = new Vector2(0 * MoveSpeed, 1* MoveSpeed);
            Vector2 right = new Vector2(1 * MoveSpeed, 0 * MoveSpeed);
            Vector2 left = new Vector2(-1 *MoveSpeed, 0 * MoveSpeed);
            if(direction == "up")
            {
                this.Position += up;
            }
            else if(direction == "down")
            {
                this.Position += down;
            }
            else if(direction == "right")
            {
                this.Position += right;
            }
            else if(direction == "left")
            {
                this.Position += left;
            }
            else if (direction == "downLeft")
            {
                this.Position += (left + down);
            }
            else if (direction == "downRight")
            {
                this.Position += (right + down);
            }
            else if (direction == "upLeft")
            {
                this.Position += (left + up);
            }
            else if (direction == "upRight")
            {
                this.Position += (up + right);
            }

        }

        public virtual void TakeDamage(int damage)
        {
            mobBase.HP -= damage;
            if (this.HP <= 0)
            {
                this.Active = false;
                Constants.playerPoints += pointValue;
            }
        }

        public virtual int DealDamage()
        {
            return this.Damage;
        }

    }
}
