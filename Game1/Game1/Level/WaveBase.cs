using System.Collections.Generic;

namespace Game1.Level
{
    public class WaveBase
    {
        public WaveBase(WaveDetails waveDetails, int startTime)
        {
            Mobs = waveDetails.mobs;
            Movescript = waveDetails.movescript;
            StartTime = startTime;
            WillFire = waveDetails.willFire;
        }

        public List<string> Mobs { get; set; }
        public string Movescript { get; set; }
        public int StartTime { get; set; }
        public bool WillFire { get; set; }
    }
}
