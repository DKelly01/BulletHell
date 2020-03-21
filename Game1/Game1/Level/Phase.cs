﻿using System;
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
            StartTime = phaseBase.startTime;
            waves = Builder.GetWaves(phaseBase.name);
        }
      

        //void Grunts1()
        //{
        //    waves.Add(new Wave(mobMaker.CreateMobList(populateMobList(8,"TypeA")), "CanCan", (2 + startTime) * Constants.FPS, false));
        //    waves.Add(new Wave(mobMaker.CreateMobList(populateMobList(6, "TypeA")), "EllRight", (11 + startTime) * Constants.FPS, false));
        //    waves.Add(new Wave(mobMaker.CreateMobList(populateMobList(1, "TypeB")), "Solo_B_Right",(13 + startTime) * Constants.FPS, true));
        //    waves.Add(new Wave(mobMaker.CreateMobList(populateMobList(6, "TypeA")), "EllLeft",(14 + startTime) * Constants.FPS, false));
        //    waves.Add(new Wave(mobMaker.CreateMobList(populateMobList(1, "TypeB")), "Solo_B_Right", (17 + startTime) * Constants.FPS, true));
        //    waves.Add(new Wave(mobMaker.CreateMobList(populateMobList(8, "TypeA")), "CanCan", (20 + startTime) * Constants.FPS, true));
        //    waves.Add(new Wave(mobMaker.CreateMobList(populateMobList(6, "TypeA")), "EllLeft", (24 + startTime) * Constants.FPS, false));
        //    waves.Add(new Wave(mobMaker.CreateMobList(populateMobList(6, "TypeA")), "EllRight", (28 + startTime) * Constants.FPS, false));
        //    waves.Add(new Wave(mobMaker.CreateMobList(populateMobList(1, "TypeB")), "Solo_B_Right", (30 + startTime) * Constants.FPS, true));
        //    waves.Add(new Wave(mobMaker.CreateMobList(populateMobList(10, "TypeA")), "SinLeft", (33 + startTime) * Constants.FPS, false));
        //}

        //void Grunts2()
        //{
        //    waves.Add(new Wave(mobMaker.CreateMobList(populateMobList(10, "TypeA")), "DiagonalRight", (1 + startTime) * Constants.FPS, true));
        //    waves.Add(new Wave(mobMaker.CreateMobList(populateMobList(10, "TypeA")), "DiagonalLeft", (3 + startTime) * Constants.FPS, true));
        //    waves.Add(new Wave(mobMaker.CreateMobList(populateMobList(10, "TypeA")), "SinRight", (6 + startTime) * Constants.FPS, true));
        //    waves.Add(new Wave(mobMaker.CreateMobList(populateMobList(10, "TypeA")), "SinLeft", (8 + startTime) * Constants.FPS, false));
        //    waves.Add(new Wave(mobMaker.CreateMobList(populateMobList(8, "TypeA")), "ZigRight", (10 + startTime) * Constants.FPS, true));
        //    waves.Add(new Wave(mobMaker.CreateMobList(populateMobList(8, "TypeA")), "ZagLeft", (11 + startTime) * Constants.FPS, false));
        //}
        
        //void MidBoss()
        //{
        //    List<MobileEntity> midBoss = mobMaker.CreateMobList(populateMobList(1, "MidBoss"));
        //    waves.Add(new Wave(midBoss, "MidBoss", startTime * Constants.FPS, true));
        //}

        //void Boss()
        //{
        //    List<MobileEntity> boss = mobMaker.CreateMobList(populateMobList(1, "Boss"));
        //    waves.Add(new Wave(boss, "Boss1", startTime * Constants.FPS, true));
        //    waves.Add(new Wave(boss, "Boss2", (startTime +45) * Constants.FPS, true));
        //}

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