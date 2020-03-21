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
    class Builder
    {
        public static Level CreateLevel(string level)
        {
            return new Level(level);
        }
        static List<PhaseBase> PhasesFromFile(string level)
        {
            return JsonConvert.DeserializeObject<List<PhaseBase>>(FileReader.GetDataFromFile(level));
        }
        internal static List<Wave> GetWaves(PhaseBase phaseBase)
        {
            List<WaveBase> waveBases = JsonConvert.DeserializeObject<List<WaveBase>>(FileReader.GetDataFromFile(phaseBase.name));
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
    }
}
