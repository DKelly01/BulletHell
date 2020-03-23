using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1.MoveScripts.Formations
{
    class Solo : Formation
    {
        public Solo(MobMaker mobMaker, Vector2 startingPosition) : base(mobMaker, startingPosition)
        {
        }

        public override List<MobileEntity> SetFormation(string entityType, int numEntity = 1)
        {
            return new List<MobileEntity>() { MobMaker.CreateMob(entityType, StartingPosition) };

        }
    }
}
