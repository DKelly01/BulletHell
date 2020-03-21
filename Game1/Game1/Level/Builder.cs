using Game1.Utilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game1.Level;

namespace Game1.Level
{
    partial class Builder
    {

        public static Level CreateLevel(string level)
        {
            return new Level(level);
        }
        static List<PhaseBase> PhasesFromFile(string level)
        {
            LevelBase levelBase = JsonConvert.DeserializeObject<LevelBase>(FileReader.GetDataFromFile(level));

            return levelBase.Phases;
        }
        internal static List<Wave> GetWaves(PhaseBase phaseBase)
        {
            WaveList waveList = JsonConvert.DeserializeObject<WaveList>(FileReader.GetDataFromFile(phaseBase.Name));
            List<Wave> waves = new List<Wave>();
            foreach(WaveInfo waveInfo in waveList.Waves)
            {
                WaveDetails waveDetails = JsonConvert.DeserializeObject<WaveDetails>(FileReader.GetDataFromFile(waveInfo.Name));
                WaveBase waveBase = new WaveBase(waveDetails,waveInfo.StartTime+phaseBase.StartTime);
                waves.Add(CreateWave(waveBase));
            }
            return waves;
        }
        public static List<Phase> GetPhases(string level)
        {
            List<Phase> phases = new List<Phase>();
            foreach (PhaseBase phaseBase in PhasesFromFile(level))
            {
                phases.Add(CreatePhase(phaseBase));
            }
            return phases;
        }
        static Phase CreatePhase(PhaseBase phaseBase)
        {
            return new Phase(phaseBase);
        }

        internal static Wave CreateWave(WaveBase waveBase)
        {
            return new Wave(waveBase);
        }
    }
}
