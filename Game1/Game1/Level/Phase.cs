using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1.Level
{
    class Phase
    {
        List<Wave> waves = new List<Wave>();
        public bool Active { get; set; }
        public int StartTime { get; }

        public Phase(PhaseBase phaseBase)
        {
            StartTime = phaseBase.StartTime;
            waves = Builder.GetWaves(phaseBase);
            Active = false;
        }

        /// <summary>
            /// Phase update function
            /// </summary>
            /// <param name="frameCount"></param>
        public void Update(int frameCount)
        {
            
            foreach (Wave wave in waves)
            {
                if (wave.StartTime < frameCount && wave.Active)
                {
                    wave.update();
                }
            }
        }

        //returns all active mobs and bullets in the phase
        public List<MobileEntity> GetMobs()
        {
            List<MobileEntity> mobs = new List<MobileEntity>();
            foreach (Wave wave in waves)
            {
                List<MobileEntity> waveMobs = wave.Mobs;
                foreach (MobileEntity mob in waveMobs)
                {
                    if (mob.Active)
                    {
                        mobs.Add(mob);
                    }
                }
                List<MobileEntity> waveBullets = wave.Bullets();
                foreach (MobileEntity bullet in waveBullets)
                {
                    if (bullet.Active)
                    {
                        mobs.Add(bullet);
                    }
                }
            }
            return mobs;
        }
    }
}
