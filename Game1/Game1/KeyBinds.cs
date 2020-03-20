using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;

namespace Game1
{
    class KeyBinds
    {
        public KeyBinds()
        {
            Up = Keys.W;
            Down = Keys.S;
            Right = Keys.D;
            Left = Keys.A;
            UpLeft = Keys.Q;
            UpRight = Keys.E;
            DownLeft = Keys.Z;
            DownRight = Keys.C;
            Slow = Keys.Space;
            Fire = Keys.Up;
        }

        public Keys Up { get; set; }
        public Keys Down { get; set; }
        public Keys Right { get; set; }
        public Keys Left { get; set; }
        public Keys UpRight { get; set; }
        public Keys UpLeft { get; set; }
        public Keys DownRight { get; set; }
        public Keys DownLeft { get; set; }
        public Keys Fire { get; set; }
        public Keys Slow { get; set; }
    }
}
