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
        public static string menuString1 = "Press ENTER to play, ESC to quit";
        public static string menuString2 = "Press m to return to menu any time";
        public static string menuString3 = "Press k to set keybinds";
        public static string keySetPrompt1 = $"Current keybinds: ";
        public string KeySetPrompt2 = "Press the key you would like to reset";
        public string KeySetPrompt3 = string.Empty;
     
        public Menu()
        {
            
        }

        internal string SelectKeyBinds()
        {
            KeyboardState kstate = Keyboard.GetState();
 
            if (kstate.IsKeyDown(KeyBinds.Instance().Up))
            {
                return "UP"; 
            }
            else if (kstate.IsKeyDown(KeyBinds.Instance().UpRight))
            {
                return "UPRIGHT";
            }
            else if (kstate.IsKeyDown(KeyBinds.Instance().UpLeft))
            {
                return "UPLEFT";
            }
            else if (kstate.IsKeyDown(KeyBinds.Instance().Down))
            {
                return "DOWN";
            }
            else if (kstate.IsKeyDown(KeyBinds.Instance().DownRight))
            {
                return "DOWNRIGHT";
            }
            else if (kstate.IsKeyDown(KeyBinds.Instance().DownLeft))
            {
                return "DOWNLEFT";
            }
            else if (kstate.IsKeyDown(KeyBinds.Instance().Right))
            {
                return "RIGHT";
            }
            else if (kstate.IsKeyDown(KeyBinds.Instance().Left))
            {
                return "LEFT";
            }
            else if (kstate.IsKeyDown(KeyBinds.Instance().Slow))
            {
                return "SLOW";
            }
            else if (kstate.IsKeyDown(KeyBinds.Instance().Fire))
            {
                return "FIRE";
            }
            else return string.Empty;
        }

        internal bool SetKeyBind(string keybindSelect)
        {
            KeyboardState kstate = Keyboard.GetState();
            KeySetPrompt2 = KeySetPrompt2 = $"You have chosen to rebind {keybindSelect}";
            KeySetPrompt3 = "Press the currently bound key and the key to rebind";               
            switch (keybindSelect)
            {

                case "UP":
                    if (kstate.GetPressedKeys().Length >= 1)
                    {
                        foreach (Keys key in kstate.GetPressedKeys())
                        {
                            if (key != KeyBinds.Instance().Up)
                            {
                                KeyBinds.Instance().Up = kstate.GetPressedKeys()[0];
                                return true;
                            }
                        }
                        return false;
                    }
                    else return false;
                case "UPLEFT":
                    if (kstate.GetPressedKeys().Length >= 1)
                    {
                        foreach (Keys key in kstate.GetPressedKeys())
                        {
                            if (key != KeyBinds.Instance().UpLeft)
                            {
                                KeyBinds.Instance().UpLeft = kstate.GetPressedKeys()[0];
                                return true;
                            }
                        }
                        return false;
                    }
                    else return false;
                case "UPRIGHT":
                    if (kstate.GetPressedKeys().Length >= 1)
                    {
                        foreach (Keys key in kstate.GetPressedKeys())
                        {
                            if (key != KeyBinds.Instance().UpRight)
                            {
                                KeyBinds.Instance().UpRight = kstate.GetPressedKeys()[0];
                                return true;
                            }
                        }
                        return false;
                    }
                    else return false;
                case "DOWN":
                    if (kstate.GetPressedKeys().Length >= 1)
                    {
                        foreach (Keys key in kstate.GetPressedKeys())
                        {
                            if (key != KeyBinds.Instance().Down)
                            {
                                KeyBinds.Instance().Down = kstate.GetPressedKeys()[0];
                                return true;
                            }
                        }
                        return false;
                    }
                    else return false;
                case "DOWNLEFT":
                    if (kstate.GetPressedKeys().Length >= 1)
                    {
                        foreach (Keys key in kstate.GetPressedKeys())
                        {
                            if (key != KeyBinds.Instance().DownLeft)
                            {
                                KeyBinds.Instance().DownLeft = kstate.GetPressedKeys()[0];
                                return true;
                            }
                        }
                        return false;
                    }
                    else return false;
                case "DOWNRIGHT":
                    if (kstate.GetPressedKeys().Length >= 1)
                    {
                        foreach (Keys key in kstate.GetPressedKeys())
                        {
                            if (key != KeyBinds.Instance().DownRight)
                            {
                                KeyBinds.Instance().DownRight = kstate.GetPressedKeys()[0];
                                return true;
                            }
                        }
                        return false;
                    }
                    else return false;
                case "RIGHT":
                    if (kstate.GetPressedKeys().Length >= 1)
                    {
                        foreach (Keys key in kstate.GetPressedKeys())
                        {
                            if (key != KeyBinds.Instance().Right)
                            {
                                KeyBinds.Instance().Right = kstate.GetPressedKeys()[0];
                                return true;
                            }
                        }
                        return false;
                    }
                    else return false;
                case "LEFT":
                    if (kstate.GetPressedKeys().Length >= 1)
                    {
                        foreach (Keys key in kstate.GetPressedKeys())
                        {
                            if (key != KeyBinds.Instance().Left)
                            {
                                KeyBinds.Instance().Left = kstate.GetPressedKeys()[0];
                                return true;
                            }
                        }
                        return false;
                    }
                    else return false;
                case "SLOW":
                    if (kstate.GetPressedKeys().Length >= 1)
                    {
                        foreach (Keys key in kstate.GetPressedKeys())
                        {
                            if (key != KeyBinds.Instance().Slow)
                            {
                                KeyBinds.Instance().Slow = kstate.GetPressedKeys()[0];
                                return true;
                            }
                        }
                        return false;
                    }
                    else return false;
                case "FIRE":
                    if (kstate.GetPressedKeys().Length >= 1)
                    {
                        foreach (Keys key in kstate.GetPressedKeys())
                        {
                            if (key != KeyBinds.Instance().Fire)
                            {
                                KeyBinds.Instance().Fire = kstate.GetPressedKeys()[0];
                                return true;
                            }
                        }
                        return false;
                    }
                    else return false;
                default:
                    return false;
            }
        }
    }
}
