using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1.CollisionManager
{
    class CollisionInvoker
    {
        public CollisionInvoker()
        {
        }

        public void detectCollision(ICollision collision)
        {
            collision.Collide();
        }
    }
}
