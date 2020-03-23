using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    class Menu
    {

        KeyBinds keyBinds;
        public static string menuString1 = "Press SPACE to start, ESC to quit";
        public static string menuString2 = "Press m to return to menu any time";
        public static string menuString3 = "Press k to set keybinds";
        public static string keySetPrompt1 = $"Current keybinds: ";
        public string Down;
        public string Up;
        public string Right;
        public string Left;
        public string UpRight;
        public string UpLeft;
        public string DownRight;
        public string DownLeft;
        public string Slow;
        public string Fire;

        public Menu(KeyBinds keyBinds)
        {
            this.keyBinds = keyBinds;
            this.Up = keyBinds.Up.ToString();
            this.Down = keyBinds.Down.ToString();
            this.Right = keyBinds.Right.ToString();
            this.Left = keyBinds.Left.ToString();
            this.UpLeft = keyBinds.UpLeft.ToString();
            this.DownLeft = keyBinds.DownLeft.ToString();
            this.UpRight = keyBinds.UpRight.ToString();
            this.DownRight = keyBinds.DownRight.ToString();
            this.Slow = keyBinds.Slow.ToString();
            this.Fire = keyBinds.Fire.ToString();
        }

        internal void SetKeyBinds()
        {
            
        }
    }
}
