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
                case "Arc":
                    return new Arc(mobs, willFire);
                case "ZigZag":
                    return new ZigZag(mobs, willFire);
                case "SoloBRight":
                    return new SoloBRight(mobs, willFire);
                case "Boss1":
                    return new Boss1(mobs, willFire);
                case "Boss2":
                    return new Boss2(mobs, willFire);
                case "EllLeft":
                    return new EllLeft(mobs, willFire);
                case "EllRight":
                    return new EllRight(mobs, willFire);
                case "MidBoss":
                    return new MidBoss(mobs, willFire);
                case "SinLeft":
                    return new SinLeft(mobs, willFire);
                case "ZagLeft":
                    return new ZagLeft(mobs, willFire);
                case "ZigRight":
                    return new ZigRight(mobs, willFire);

                default:
                    return new MoveScript(mobs, willFire);
            }

        }
    }
}
