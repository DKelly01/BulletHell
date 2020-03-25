using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    class Menu
    {
        public static string menuString1 = "Press SPACE to play, ESC to quit";
        public static string menuString2 = "Press m to return to menu any time";
        public static string menuString3 = "Press k to set keybinds";
        public static string keySetPrompt1 = $"Current keybinds: ";
        public string KeySetPrompt2 = "Press the key you would like to reset";
     
        public Menu()
        {
            
        }

        internal void SetKeyBinds()
        {
            KeyboardState kstate = Keyboard.GetState();
            for (int i = 0; i < kstate.GetPressedKeys().Length; i++)
            {
                KeySetPrompt2 = " " + kstate.GetPressedKeys()[i].ToString();
            }
            if (kstate.IsKeyDown(KeyBinds.Instance().Up))
            {
                KeySetPrompt2 = "UP ";
                bool released = false;
                while (!released)
                {
                    KeySetPrompt2 = "Original key down";
                    kstate = Keyboard.GetState();
                    if (kstate.IsKeyUp(KeyBinds.Instance().Up)){
                        KeySetPrompt2 = "Released";
                        released = true;
                    }
                }
               

            }
        }      
    }
}
