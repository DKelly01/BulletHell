using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1.Level.Wave
{
    class Wave
    {
        List<MobileEntity> mobs = new List<MobileEntity>();
        MoveScript script;
        int startTime;
        bool active = true;

        public Wave(List<MobileEntity> mobs, string moveType, int startTime, bool willFire)
        {
            this.mobs = mobs;
            script = new MoveScript(moveType, mobs, willFire);
            StartTime = startTime;
        }

        public int StartTime { get => startTime; set => startTime = value; }
        public bool Active { get => active; set => active = value; }
        internal List<MobileEntity> Mobs { get => mobs; set => mobs = value; }

        public List<MobileEntity> Bullets()
        {
            List<BulletFormation> formations = script.Bullets;
            List<MobileEntity> bullets = new List<MobileEntity>();
            foreach (BulletFormation formation in formations)
            {
                List<MobileEntity> bulletSet = formation.Bullets;
                foreach (MobileEntity bullet in bulletSet)
                {
                    bullets.Add(bullet);
                }
            }
            return bullets;
        }

        public void update()
        {
            //this section can be modified to update the active status of mobs
            script.update();
            if (!script.Active)
            {
                active = false;
            }
        }
    }
}
