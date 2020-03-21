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
            return new MoveScript(scriptName, mobs, willFire);
        }
    }
}
