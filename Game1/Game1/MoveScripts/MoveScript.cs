using Game1.Mobs;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1.MoveScripts
{
    class MoveScript
    {
        internal int FrameCount { get; set; }
        internal List<MobileEntity> Mobs { get; set; }
        internal List<MoveScript> Bullets;
        internal bool willFire;
        internal MobMaker MobMaker;
        public bool Active { get; set; }

        public MoveScript(List<MobileEntity> mobs, bool willFire)
        {
            this.Mobs = mobs ?? throw new ArgumentNullException(nameof(mobs));
            this.Bullets = new List<MoveScript>();
            this.willFire = willFire;
            this.FrameCount = 0;
            this.MobMaker = new BulletMaker();
            this.Active = true;
        }

        public virtual void Update()
        {
            foreach (MobileEntity mob in Mobs)
            {
                mob.UpdatePosition("down");
                if (mob.Position.Y >= Constants.HEIGHT)
                {
                    mob.Active = false;
                }
            }
            foreach (MoveScript formation in Bullets)
            {
                formation.Update();
            }
            FrameCount++;
        }

    }
}

