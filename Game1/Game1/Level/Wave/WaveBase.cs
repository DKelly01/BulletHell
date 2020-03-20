using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1.Level.Wave
{
    public class WaveBase
    {
        public List<string> mobs { get; set; }
        public string movescript { get; set; }
        public bool willFire { get; set; }
    }
}
