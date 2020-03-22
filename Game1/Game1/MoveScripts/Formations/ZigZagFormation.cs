using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1.MoveScripts.Formations
{
    class ZigZagFormation : Formation
    {
        public ZigZagFormation(MobMaker mobMaker, Vector2 startingPosition) : base(mobMaker, startingPosition)
        {
        }

        public override List<MobileEntity> SetFormation(string entityType, int numBullets = 3)
        {
            List<MobileEntity> Zig = new List<MobileEntity>();

            Zig.Add(MobMaker.CreateMob(entityType, StartingPosition));
            Zig.Add(MobMaker.CreateMob(entityType, StartingPosition));
            Zig.Add(MobMaker.CreateMob(entityType, StartingPosition));

            Zig[0].Active = true;
            Zig[1].Active = true;
            Zig[2].Active = true;

            return Zig;
        }
    }

    
}
