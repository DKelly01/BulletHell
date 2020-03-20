using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1.CollisionManager
{
    class DetectCollision : ICollision
    {
        public DetectCollision(MobileEntity damagingEntity, MobileEntity damagedEntity)
        {
            DamagingEntity = damagingEntity ?? throw new ArgumentNullException(nameof(damagedEntity)); 
            DamagedEntity = damagedEntity ?? throw new ArgumentNullException(nameof(damagedEntity));
        }

        public MobileEntity DamagingEntity { get; }
        public MobileEntity DamagedEntity { get; }

        public void Collide()
        {
            float distance = Vector2.Distance(DamagedEntity.Position, DamagingEntity.Position);
            if (distance <= DamagedEntity.HitRadius + DamagingEntity.HitRadius)
            {
                DamagedEntity.TakeDamage(DamagingEntity.Damage);
            }
            
        }
    }
}
