using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Game1.Mobs
{
    class Bullet : MobileEntity
    {
        public Bullet(MobBase mobBase, Vector2 startingPosition) : base(mobBase, startingPosition)
        {
            Active = true;
        }

        public override void TakeDamage(int damage)
        {
            base.TakeDamage(0);
        }
    }
}
