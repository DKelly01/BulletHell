using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1.MoveScripts
{
    class Arc : MoveScript
    {
        public Arc(List<MobileEntity> mobs, bool willFire) : base(mobs, willFire)
        {
        }

        public override void Update()
        {
            for (int i = 0; i < Mobs.Count; i++)
            {
                if (i == 0)
                {
                    Mobs[i].UpdatePosition("left");
                    if (Mobs[i].Position.X <= 0)
                    {
                        Mobs[i].Active = false;
                    }
                }
                else if (i == Mobs.Count - 1)
                {
                    Mobs[i].UpdatePosition("right");
                    if (Mobs[i].Position.X >= Constants.PLAYABLE_WIDTH)
                    {
                        Mobs[i].Active = false;
                    }
                }
                else if (i == Mobs.Count / 2 || i == (Mobs.Count / 2) - 1)
                {
                    Mobs[i].UpdatePosition("down");
                    if (Mobs[i].Position.Y >= Constants.HEIGHT)
                    {
                        Mobs[i].Active = false;
                    }
                }
                else if (i != 0 && i < (Mobs.Count / 2) - 1)
                {
                    Mobs[i].UpdatePosition("downLeft");
                    if (Mobs[i].Position.Y >= Constants.HEIGHT)
                    {
                        Mobs[i].Active = false;
                    }
                    if (Mobs[i].Position.X <= 0)
                    {
                        Mobs[i].Active = false;
                    }
                }
                else if (i > (Mobs.Count / 2) - 1 && i < Mobs.Count - 1)
                {
                    Mobs[i].UpdatePosition("downRight");
                    if (Mobs[i].Position.Y >= Constants.HEIGHT)
                    {
                        Mobs[i].Active = false;
                    }
                    if (Mobs[i].Position.X >= Constants.PLAYABLE_WIDTH)
                    {
                        Mobs[i].Active = false;
                    }
                }
            }
        }
    }
}
