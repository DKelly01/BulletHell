using Game1.Mobs;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1.MoveScripts
{
    class Arrowhead : Formation
    {
        public Arrowhead(MobMaker mobMaker, Vector2 startingPosition) : base(mobMaker, startingPosition)
        {
        }

        public override List<MobileEntity> SetFormation(string entityType, int numBullet=10)
        {
            List<MobileEntity> Entities = new List<MobileEntity>();
            Vector2 shift = new Vector2(-Constants.BULLET_SPACING * 2, 0);
            Entities.Add(MobMaker.CreateMob(entityType, StartingPosition));
            Entities.Add(MobMaker.CreateMob(entityType, StartingPosition + shift));
            shift = new Vector2(Constants.BULLET_SPACING * 2, 0);
            Entities.Add(MobMaker.CreateMob(entityType, StartingPosition + shift));
            shift = new Vector2(Constants.BULLET_SPACING, Constants.BULLET_SPACING);
            Entities.Add(MobMaker.CreateMob(entityType, StartingPosition + shift));
            shift = new Vector2(-Constants.BULLET_SPACING, Constants.BULLET_SPACING);
            Entities.Add(MobMaker.CreateMob(entityType, StartingPosition + shift));
            shift = new Vector2(0, Constants.BULLET_SPACING * 2);
            Entities.Add(MobMaker.CreateMob(entityType, StartingPosition + shift));

            foreach (MobileEntity entity in Entities)
            {
                entity.Active = true;
            }
            return Entities;
        }
    }
}
