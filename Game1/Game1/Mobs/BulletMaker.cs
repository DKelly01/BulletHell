using Game1.MoveScripts;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1.Mobs
{
    class BulletMaker : MobMaker
    {
        public override MobileEntity CreateMob(string bulletType, Vector2 startingPosition)
        {
            return new Bullet(MobFromFile(bulletType), startingPosition);
        }
    }
}
