using Game1.Mobs;
using Game1.Utilities;
using Microsoft.Xna.Framework;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    public class MobMaker
    {
        public MobMaker()
        {
        }

        public virtual MobileEntity CreateMob(string mobType, Vector2 startingPosition)
        {
            return new MobileEntity(MobFromFile(mobType), startingPosition);
        }

        internal MobBase MobFromFile(string mobType)
        {
            return JsonConvert.DeserializeObject<MobBase>(FileReader.GetDataFromFile(mobType));

        }
    }
}
