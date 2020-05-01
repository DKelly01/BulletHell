using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Game1
{
    class Constants
    {
        //SCREEN AND PLAYABLE AREA VALUES
        public static readonly int BORDER = 10;
        public static readonly int HEIGHT = 540;
        public static readonly int WIDTH = 960;
        public static readonly int MENU_WIDTH = 285;
        public static readonly int PLAYABLE_WIDTH = WIDTH - MENU_WIDTH;
        
        //HITBOX AND SPRITE VALUES
        public static readonly int PLAYER_RADIUS = 15;
        public static readonly int BULLET_SPACING = 9;
        public static readonly int MIDBOSS_RADIUS = 22;
        public static readonly int BOSS_RADIUS = 15;

        public static readonly int BULLET_TYPE_A_RADIUS = 9; 
        public static readonly int BULLET_TYPE_B_RADIUS = 9;

        //SPEED VALUES
        public static readonly int BULLET_SPEED = 2;
        public static readonly int TYPE_A_SPEED = 3;
        public static readonly int TYPE_B_SPEED = 1;
        public static readonly int MIDBOSS_SPEED = 2;
        public static readonly int BOSS_SPEED = 1;

        public static readonly int DEFAULT_SPEED = 90;

        //TIME VALUES
        public static readonly int FPS = 60;
        public static readonly int INVINCIBLE_TIME = 3;
        public static readonly double FIRE_RATE = .5;
        //GRID VALUES
        public static readonly int A = 30;
        public static readonly int B = 60;
        public static readonly int C = 90;
        public static readonly int D = 120;
        public static readonly int E = 150;
        public static readonly int F = 180;
        public static readonly int G = 210;
        public static readonly int H = 240;
        public static readonly int I = 270;
        public static readonly int J = 300;
        public static readonly int K = 330;
        public static readonly int L = 360;
        public static readonly int M = 390;
        public static readonly int N = 420;
        public static readonly int O = 450;
        public static readonly int P = 480;
        public static readonly int Q = 510;
        public static readonly int R = 540;
        public static readonly int S = 570;
        public static readonly int T = 600;
        public static readonly int U = 630;
        public static readonly int V = 660;

        public static bool invertX { get; set; }
        public static bool invertY { get; set; }

        public static Color playerColor { get; set; }
        public static bool invincible { get; set; }
        public static int playerPoints { get; set; }
    }
}
