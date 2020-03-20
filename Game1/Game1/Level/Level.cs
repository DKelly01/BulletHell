using Game1.CollisionManager;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1.Level
{
    class Level
    {
        List<Phase> Phases;
        public List<MobileEntity> playerBullets { get; internal set; }
        public int FrameCount { get; internal set; }
        public Level(string level)
        {
            FrameCount = 0;
            playerBullets = new List<MobileEntity>();
            Phases = Builder.GetPhases(level);
        }
        
        /// <summary>
        /// gets a list of all mobile entities (bullets and enemies) currently active
        /// </summary>
        /// <returns></returns>
        public List<MobileEntity> GetMobs()
        {
            List<MobileEntity> mobs = new List<MobileEntity>();
            mobs.AddRange(playerBullets);
            mobs.AddRange(GetPhaseMobs());  
            return mobs;
        }     

        List<MobileEntity> GetPhaseMobs()
        {
            List<MobileEntity> mobs = new List<MobileEntity>();
            foreach (Phase phase in Phases)
            {
                if (phase.Active == true)
                {
                    mobs.AddRange(phase.GetMobs());   
                }
            }
            return mobs;
        }
        void DetectCollision(PlayerCharacter player)
        {
            List<MobileEntity> mobs = this.GetPhaseMobs();
            CollisionDetector collisionDetector = new CollisionDetector(mobs, player);
            foreach (MobileEntity mob in mobs)
            {
                collisionDetector = new CollisionDetector(this.playerBullets, mob);   
            }
            
        }

        public void Update(PlayerCharacter player, KeyboardState kstate)
        {
            FrameCount++;
            foreach(Phase phase in Phases)
            {
                if (phase.StartTime <= FrameCount)
                {
                    phase.Active = true;
                }
                if (phase.Active == true)
                {
                    phase.Update(FrameCount);
                }
            }
            foreach(MobileEntity bullet in playerBullets)
            {
                if (bullet.Position.Y > 0)
                {
                    bullet.UpdatePosition("up");
                }
                else bullet.Active = false;
            }
            this.DetectCollision(player);
            player.Update(this, kstate);
        }

        
    }
}
