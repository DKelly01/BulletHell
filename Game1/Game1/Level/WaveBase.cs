using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1.Level
{
    public class WaveBase
    {
        public List<string> Mobs { get; set; }
        public string Movescript { get; set; }
        public int StartTime { get; set; }
        public bool WillFire { get; set; }
    }
}
