using Game1.Mobs;
using Game1.MoveScripts.Formations;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1.MoveScripts
{
    class KeyboardMovement : MoveScript
    {
        public KeyboardMovement(List<MobileEntity> mobs, bool willFire) : base(mobs, willFire)
        {
            FrameCount = 0;
        }

        public override void Update()
        {
            string bulletType = "BulletTypeB";
            KeyboardState kstate = Keyboard.GetState();
            if (FrameCount == 0)
            {
                foreach (MobileEntity mob in Mobs)
                {
                    mob.Active = true;
                }
            }

            foreach (MobileEntity mob in Mobs)
            {
                if (FrameCount % 3 == 0)
                {
                    mob.UpdatePosition("down");

                }

                if (kstate.IsKeyDown(KeyBinds.Instance().Left) && mob.Position.X > Constants.BORDER + Constants.PLAYER_RADIUS)
                {
                    mob.UpdatePosition("left");
                }
                else if (kstate.IsKeyDown(KeyBinds.Instance().Right) && mob.Position.X < Constants.PLAYABLE_WIDTH - Constants.PLAYER_RADIUS)
                {
                    mob.UpdatePosition("right");
                }
                else if (kstate.IsKeyDown(KeyBinds.Instance().UpLeft))
                {
                    if (mob.Position.X > Constants.BORDER + Constants.PLAYER_RADIUS)
                    {
                        mob.UpdatePosition("left");
                    }
                }
                else if (kstate.IsKeyDown(KeyBinds.Instance().UpRight))
                {
                    if (mob.Position.X < Constants.PLAYABLE_WIDTH - Constants.PLAYER_RADIUS)
                    {
                        mob.UpdatePosition("right");
                    }
                }
                else if (kstate.IsKeyDown(KeyBinds.Instance().DownRight))
                {
                    if (mob.Position.X < Constants.PLAYABLE_WIDTH - Constants.PLAYER_RADIUS)
                    {
                        mob.UpdatePosition("right");
                    }
                }
                else if (kstate.IsKeyDown(KeyBinds.Instance().DownLeft))
                {
                    if (mob.Position.X > Constants.BORDER + Constants.PLAYER_RADIUS)
                    {
                        mob.UpdatePosition("left");
                    }
                }
            }
            if (FrameCount % 120 == 0 && Mobs[0].Active)
            {
                Formation arc = new ZigZagFormation(new BulletMaker(), Mobs[0].Position);
                Bullets.Add(MoveScriptMaker.CreateMoveScript("ZigZag", arc.SetFormation(bulletType), false));
            }
            foreach (MoveScript formation in Bullets)
            {
                formation.Update();
            }
            FrameCount++;
        }
    }
}
