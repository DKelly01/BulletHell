using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1.Mobs
{
    class MobBase
    {
        public int HitRadius { get; set; }
        public float MoveSpeed { get; set; }
        public string MobType { get; set; }
        public int HP { get; set; }
        public int Damage { get; set; }
    }
}
