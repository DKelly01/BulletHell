using Game1.Mobs;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1.MoveScripts
{
    class Formation
    {
        internal MobMaker MobMaker;
        internal Vector2 StartingPosition;
        public Formation(MobMaker mobMaker, Vector2 startingPosition)
        {
            this.MobMaker = mobMaker;
            this.StartingPosition = startingPosition;
        }

        public virtual List<MobileEntity> SetFormation(string entityType, int numEntity=10)
        {
            return new List<MobileEntity>();
        }
    }
}
