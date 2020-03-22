using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1.MoveScripts.Formations
{
    class ArcFormation : Formation
    {
        public ArcFormation(MobMaker mobMaker, Vector2 startingPosition) : base(mobMaker, startingPosition)
        {
        }

        public override List<MobileEntity> SetFormation(string entityType, int numBullets)
        {
            Vector2 shift = new Vector2(0, 0);
            List<MobileEntity> arc = new List<MobileEntity>();
            while (numBullets % 2 == 1 || numBullets < 4)
            {
                numBullets++;
            }
            for (int i = 0; i < numBullets; i++)
            {
                arc.Add(MobMaker.CreateMob(entityType, StartingPosition + shift));
                arc[i].Active = true;
                if (i < (numBullets / 2) - 1)
                {
                    shift += new Vector2(Constants.BULLET_SPACING * 2, Constants.BULLET_SPACING * 2);
                }
                else if (i == (numBullets / 2) - 1)
                {
                    shift += new Vector2(Constants.BULLET_SPACING * 2, 0);
                }
                else shift += new Vector2(Constants.BULLET_SPACING * 2, -Constants.BULLET_SPACING * 2);
            }
            return arc;
        }
    }
}
