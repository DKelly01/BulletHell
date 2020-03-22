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
            //return new MoveScript(scriptName, mobs, willFire);
            switch (scriptName)
            {
                case "CanCan":
                    return new CanCan(mobs, willFire);
                    break;
                case "Arc":
                    return new Arc(mobs, willFire);
                    break;
                case "ZigZag":
                    return new ZigZag(mobs, willFire);
                    break;
                case "SoloBRight":
                    return new SoloBRight(mobs, willFire);

                default:
                    return new MoveScript(mobs, willFire);


            }

        }
    }
}
