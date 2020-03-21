using Game1.Mobs;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1.MoveScripts
{
    class BulletMaker
    {
        static int spacing = Constants.BULLET_SPACING;

        public static List<MobileEntity> CreateBulletFormation(int numBullets, string bulletType, Vector2 startingPosition, string formationType, Color color)
        {

            if (formationType == "Arc")
            {
                return Arc(startingPosition, bulletType, color, numBullets);
            }
            //highly suspect, needs debugging, use a single bullet in arc for now
            else if (formationType == "Single")
            {
                return Single(startingPosition, bulletType, color, numBullets);
            }
            else if (formationType == "Arrowhead")
            {
                return Arrowhead(startingPosition, bulletType, color);
            }
            else if (formationType == "ZigZag")
            {
                return ZigZag(startingPosition, bulletType, color);
            }
            else return new List<MobileEntity>();
        }



        static List<MobileEntity> Arc(Vector2 startingPosition, string bulletType, Color color, int numBullets)
        {
            Vector2 shift = new Vector2(0, 0);
            List<MobileEntity> arc = new List<MobileEntity>();
            while (numBullets % 2 == 1 || numBullets < 4)
            {
                numBullets++;
            }
            for (int i = 0; i < numBullets; i++)
            {
                arc.Add(MobMaker.CreateMob(bulletType, startingPosition + shift));
                arc[i].Active = true;
                if (i < (numBullets / 2) - 1)
                {
                    shift += new Vector2(spacing * 2, spacing * 2);
                }
                else if (i == (numBullets / 2) - 1)
                {
                    shift += new Vector2(spacing * 2, 0);
                }
                else shift += new Vector2(spacing * 2, -spacing * 2);
            }
            return arc;
        }

        static List<MobileEntity> Single(Vector2 startingPosition, string bulletType, Color color, int numBullets)
        {

            List<MobileEntity> single = new List<MobileEntity>();
            single.Add((Bullet)MobMaker.CreateMob(bulletType, startingPosition));
            return single;
        }

        static List<MobileEntity> Arrowhead(Vector2 startingPosition, string bulletType, Color color)
        {
            List<MobileEntity> arrowhead = new List<MobileEntity>();
            Vector2 shift = new Vector2(-Constants.BULLET_SPACING * 2, 0);
            arrowhead.Add(MobMaker.CreateBullet(bulletType, startingPosition));
            arrowhead.Add(MobMaker.CreateBullet(bulletType, startingPosition + shift));
            shift = new Vector2(Constants.BULLET_SPACING * 2, 0);
            arrowhead.Add(MobMaker.CreateBullet(bulletType, startingPosition + shift));
            shift = new Vector2(Constants.BULLET_SPACING, Constants.BULLET_SPACING);
            arrowhead.Add(MobMaker.CreateBullet(bulletType, startingPosition + shift));
            shift = new Vector2(-Constants.BULLET_SPACING, Constants.BULLET_SPACING);
            arrowhead.Add(MobMaker.CreateBullet(bulletType, startingPosition + shift));
            shift = new Vector2(0, Constants.BULLET_SPACING * 2);
            arrowhead.Add(MobMaker.CreateBullet(bulletType, startingPosition + shift));

            foreach (MobileEntity bullet in arrowhead)
            {
                bullet.Active = true;
            }

            return arrowhead;
        }

        static List<MobileEntity> ZigZag(Vector2 startingPosition, string bulletType, Color color)
        {
            List<MobileEntity> Zig = new List<MobileEntity>();

            Zig.Add(MobMaker.CreateBullet(bulletType, startingPosition));
            Zig.Add(MobMaker.CreateBullet(bulletType, startingPosition));
            Zig.Add(MobMaker.CreateBullet(bulletType, startingPosition));

            Zig[0].Active = true;
            Zig[1].Active = true;
            Zig[2].Active = true;

            return Zig;
        }
    }
}
