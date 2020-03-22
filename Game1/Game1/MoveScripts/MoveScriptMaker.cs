using Game1.Mobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1.MoveScripts
{
    class MoveScriptMaker
    {
        public static MoveScript CreateMoveScript(string scriptName, List<MobileEntity>mobs, bool willFire)
        {
            MobMaker bulletMaker = new BulletMaker();
            //return new MoveScript(scriptName, mobs, willFire);
            switch (scriptName)
            {
                case "CanCan":
                    return new CanCan(mobs, willFire,bulletMaker);
                    break;
                case "Arc":
                    return new Arc(mobs, false, bullet);
                default:
                    return new CanCan(mobs, willFire, mobMaker);


            }

        }
    }
}
