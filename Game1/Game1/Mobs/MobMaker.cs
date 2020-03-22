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

        //public static Level.PlayerCharacter CreatePlayer(KeyBinds keyBinds)
        //{
        //    return new Level.PlayerCharacter(MobFromFile("Player"), new Vector2(Constants.WIDTH / 2, (Constants.HEIGHT - 10) - Constants.PLAYER_RADIUS), keyBinds);
        //}

        //internal static List<MobileEntity> GetMobs(List<string> mobTypes)
        //{
        //    List<MobileEntity> mobs = new List<MobileEntity>();
        //    foreach (string mob in mobTypes)
        //    {
        //        mobs.Add(CreateMob(mob, new Vector2(-100, 100)));
        //    }
        //    return mobs;
        //}

        public virtual MobileEntity CreateMob(string mobType, Vector2 startingPosition)
        {
            return new MobileEntity(MobFromFile(mobType), startingPosition);
        }

        //public static Bullet CreateBullet(string bulletType, Vector2 startingPosition)
        //{
        //    return new Bullet(MobFromFile(bulletType), startingPosition);
        //}

        internal MobBase MobFromFile(string mobType)
        {
            return JsonConvert.DeserializeObject<MobBase>(FileReader.GetDataFromFile(mobType));
        }
    }
}
