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
        MobMaker mobMaker= new MobMaker();

        public Wave(WaveBase waveBase)
        {
            Mobs = new List<MobileEntity>();
            foreach(string mob in waveBase.Mobs)
            {
                Mobs.Add(mobMaker.CreateMob(mob, new Vector2(0, -100)));
            }
            script = MoveScriptMaker.CreateMoveScript(waveBase.Movescript, Mobs, waveBase.WillFire);
            StartTime = waveBase.StartTime * Constants.FPS;
            Active = true;
        }

        public List<MobileEntity> Bullets()
        {
            List<MoveScript> formations = script.Bullets;
            List<MobileEntity> bullets = new List<MobileEntity>();
            foreach (MoveScript formation in formations)
            {
                List<MobileEntity> bulletSet = formation.Mobs;
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
            script.Update();
            if (!script.Active)
            {
                Active = false;
            }
        }
    }
}
