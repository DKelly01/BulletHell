using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1.Level
{
    public class PhaseBase
    {
        public string Name { get; set; }
        public int StartTime { get; set; }
    }

    public class LevelBase
    {
        public List<PhaseBase> Phases { get; set; }
    }

    public class WaveInfo
    {
        public string Name { get; set; }
        public int StartTime { get; set; }
    }

    public class WaveList
    {
        public List<WaveInfo> Waves { get; set; }
    }
    public class WaveDetails
    {
        public List<string> mobs { get; set; }
        public string movescript { get; set; }
        public bool willFire { get; set; }
    }
}
