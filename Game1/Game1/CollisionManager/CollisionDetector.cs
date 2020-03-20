using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1.CollisionManager
{
    class CollisionDetector
    {
        public CollisionDetector(List<MobileEntity> damagingEntities, MobileEntity damagedEntity)
        {
            CollisionInvoker invoker = new CollisionInvoker();
            foreach (MobileEntity damagingEntity in damagingEntities) {
                invoker.detectCollision( new DetectCollision(damagingEntity, damagedEntity));
            } 
        }
    }
}
