using System;
using System.Collections.Generic;
using Game1.Level;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game1
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        // including the sprite assets; values set in LoadContent
        Texture2D backgroundSprite;
        Texture2D playerSprite;
        Texture2D typeASprite;
        Texture2D typeBSprite;
        Texture2D midBossSprite;
        Texture2D bossSprite;
        Texture2D backgroundGrid;
        Texture2D hitboxSprite;
        Texture2D bulletTypeASprite;
        Texture2D bulletTypeBSprite;


        SpriteFont gameFont;
        PlayerCharacter player;
        Level.Level level;
        KeyBinds keyBinds = new KeyBinds();
        Menu menu;
        bool menuOpen = true;
        bool keySet = false;
        bool gameOver = false;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferWidth = 960;
            graphics.PreferredBackBufferHeight = 540;
            IsMouseVisible = false;
            graphics.IsFullScreen = false;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            this.LevelStart("Level1");
            base.Initialize();
        }

        void LevelStart(string level)
        {
            Mobs.PlayerMaker playerMaker = new Mobs.PlayerMaker(keyBinds);
            Vector2 defaultStart = new Vector2(Constants.WIDTH / 2, (Constants.HEIGHT - 10) - Constants.PLAYER_RADIUS);
            player = (PlayerCharacter)playerMaker.CreateMob("Player", defaultStart);
            this.level = Builder.CreateLevel(level);
            menu = new Menu(keyBinds);
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // use this.Content to load your game content here
            backgroundSprite = Content.Load<Texture2D>("background_clean");
            playerSprite = Content.Load<Texture2D>("player_sprite");
            typeASprite = Content.Load<Texture2D>("typeA_sprite");
            typeBSprite = Content.Load<Texture2D>("typeB_sprite");
            midBossSprite = Content.Load<Texture2D>("midBoss1_sprite");
            bossSprite = Content.Load<Texture2D>("boss1_sprite");
            backgroundGrid = Content.Load<Texture2D>("bg_grid");
            gameFont = Content.Load<SpriteFont>("galleryFont");
            hitboxSprite = Content.Load<Texture2D>("hitbox");
            bulletTypeASprite = Content.Load<Texture2D>("bullet1_sprite");
            bulletTypeBSprite = Content.Load<Texture2D>("bullet2_sprite");
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            //Add your update logic here
            KeyboardState kstate = Keyboard.GetState();
            if (kstate.IsKeyDown(Keys.M))
            {
                menuOpen = true;
            }
            if (menuOpen)
            {
                if (kstate.IsKeyDown(Keys.Space))
                {
                    menuOpen = false;
                }
                else if (kstate.IsKeyDown(Keys.K))
                {
                    keySet = true;
                }
                else if (kstate.IsKeyDown(Keys.M))
                {
                    keySet = false;
                }
            }
            else 
            {
                if (!gameOver)
                {
                    gameOver = level.Update(player, kstate);
                }
                else
                {
                    if (kstate.IsKeyDown(Keys.R))
                    {
                        this.LevelStart("Level1");
                        this.gameOver = false;
                        this.menuOpen = true;
                    }
                }
            }
            
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            //Add your drawing code here
            spriteBatch.Begin();
            
            spriteBatch.Draw(backgroundSprite, new Vector2(0,0), Color.White);
            //spriteBatch.Draw(backgroundGrid, new Vector2(0, 0), Color.White);
            if (menuOpen)
            {
                if (keySet)
                {
                    spriteBatch.DrawString(gameFont, Menu.keySetPrompt1, new Vector2(100, 100), Color.Aqua);
                    spriteBatch.DrawString(gameFont, $"Up:{menu.Up}  Down:{menu.Down}  Right:{menu.Right}  Left:{menu.Left}", new Vector2(100, 150), Color.Aquamarine);
                    spriteBatch.DrawString(gameFont, $"UpLeft:{menu.UpLeft}  DownLeft:{menu.DownLeft}  UpRight:{menu.UpRight}  DownRight:{menu.DownRight}", new Vector2(100, 200), Color.Aquamarine);
                    spriteBatch.DrawString(gameFont, $"Slow:{menu.Slow}  Fire:{menu.Fire}", new Vector2(100, 250), Color.Aquamarine);
                    spriteBatch.DrawString(gameFont, "Press SPACE to return to game M to return to menu", new Vector2(100, 300), Color.Aqua);
                }
                else
                {
                    spriteBatch.DrawString(gameFont, Menu.menuString1, new Vector2(100, 100), Color.Fuchsia);
                    spriteBatch.DrawString(gameFont, Menu.menuString2, new Vector2(100, 150), Color.Fuchsia);
                    spriteBatch.DrawString(gameFont, Menu.menuString3, new Vector2(100, 200), Color.Fuchsia);
                }
            }
            else if (gameOver)
            {
                spriteBatch.DrawString(gameFont, "Game Over!", new Vector2(300, 100), Color.Red);
                spriteBatch.DrawString(gameFont, "Press ESC to quit R to reload", new Vector2(200, 150), Color.Red);
            }
            else
            {
                spriteBatch.Draw(playerSprite, new Vector2(player.Position.X - Constants.PLAYER_RADIUS, player.Position.Y - Constants.PLAYER_RADIUS), player.Color);
                var kstate = Keyboard.GetState();
                if (kstate.IsKeyDown(keyBinds.Slow))
                {
                    spriteBatch.Draw(hitboxSprite, new Vector2(player.Position.X - 6, player.Position.Y - 2), Color.Chartreuse);
                }

                //spriteBatch.DrawString(gameFont, (level.FrameCount/60).ToString(), new Vector2(780, 70), Color.Chartreuse);
                spriteBatch.DrawString(gameFont, $"Player Lives: {player.Lives}", new Vector2(725, 70), Color.Chartreuse);
                foreach (MobileEntity mob in level.GetMobs())
                {
                    if (mob.Active)
                    {
                        if (mob.MobType == "BulletTypeA")
                        {
                            spriteBatch.Draw(bulletTypeASprite, mob.Position, mob.Color);
                        }
                        if (mob.MobType == "BulletTypeB")
                        {
                            spriteBatch.Draw(bulletTypeBSprite, mob.Position, mob.Color);
                        }
                        if (mob.MobType == "TypeA")
                        {
                            spriteBatch.Draw(typeASprite, mob.Position, mob.Color);
                        }
                        if (mob.MobType == "TypeB")
                        {
                            spriteBatch.Draw(typeBSprite, mob.Position, mob.Color);
                        }
                        if (mob.MobType == "MidBoss")
                        {
                            spriteBatch.Draw(midBossSprite, mob.Position, Color.Orange);
                        }
                        if (mob.MobType == "Boss")
                        {
                            spriteBatch.Draw(bossSprite, mob.Position, Color.HotPink);
                        }
                    }
                }
            }
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
