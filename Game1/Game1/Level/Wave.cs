using Game1.MoveScripts;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1.Level
{
    class Wave
    {
        public List<MobileEntity> Mobs { get; set; }
        MoveScript script;
        public int StartTime { get; set; }
        public bool Active { get; set; }

        public Wave(WaveBase waveBase)
        {
            mobs = MobMaker.GetMobs(waveBase.Mobs);
            script = new MoveScript(waveBase.Movescript, mobs, waveBase.WillFire);
            StartTime = waveBase.StartTime;
            Active = true;
        }

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
                Active = false;
            }
        }
    }
}
