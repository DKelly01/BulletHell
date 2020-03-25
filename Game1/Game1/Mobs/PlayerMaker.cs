using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1.Mobs
{
    public class PlayerMaker : MobMaker
    {
        public PlayerMaker()
        {
        }

        public override MobileEntity CreateMob(string mobType, Vector2 startingPosition)
        {
            return new Level.PlayerCharacter(MobFromFile("Player"), startingPosition);
        }
    }
}
