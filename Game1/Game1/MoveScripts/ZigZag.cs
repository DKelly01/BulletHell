using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1.MoveScripts
{
    class ZigZag : MoveScript
    {
        public ZigZag(List<MobileEntity> mobs, bool willFire) : base(mobs, willFire)
        {
        }

        public override void Update()
        {
            Random rand = new Random();
            //outside bullets drift farther out, change the % 4 to change how far out the side ones move
            if ((((Mobs[0].Position.Y % 100) - (Mobs[0].Position.Y % 10)) / 10) % 4 == 0)
            {
                Mobs[0].UpdatePosition("downRight");
                Mobs[2].UpdatePosition("downLeft");
                Mobs[0].Color = new Color(rand.Next(256), rand.Next(256), rand.Next(256));
                Mobs[2].Color = new Color(rand.Next(256), rand.Next(256), rand.Next(256));
            }
            else
            {
                Mobs[0].UpdatePosition("downLeft");
                Mobs[2].UpdatePosition("downRight");
                Mobs[0].Color = new Color(rand.Next(256), rand.Next(256), rand.Next(256));
                Mobs[2].Color = new Color(rand.Next(256), rand.Next(256), rand.Next(256));
            }

            if (Mobs[0].Position.Y >= Constants.HEIGHT)
            {
                Mobs[0].Active = false;
                Mobs[2].Active = false;
            }

            //middle bullet wiggles and goes down
            if ((((Mobs[1].Position.Y % 100) - (Mobs[1].Position.Y % 10)) / 10) % 2 == 0)
            {
                Mobs[1].UpdatePosition("downRight");
                Mobs[1].Color = new Color(rand.Next(256), rand.Next(256), rand.Next(256));
            }
            else
            {
                Mobs[1].UpdatePosition("downLeft");
                Mobs[1].Color = new Color(rand.Next(256), rand.Next(256), rand.Next(256));
            }

            if (Mobs[1].Position.Y >= Constants.HEIGHT)
            {
                Mobs[0].Active = false;
            }
        }
    }
}
