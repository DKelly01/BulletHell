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
        bool menuOpen = true;

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
            Mobs.PlayerMaker playerMaker = new Mobs.PlayerMaker(keyBinds);
            Vector2 defaultStart = new Vector2(Constants.WIDTH / 2, (Constants.HEIGHT - 10) - Constants.PLAYER_RADIUS);
            player = (PlayerCharacter)playerMaker.CreateMob("Player",defaultStart);
            level = Builder.CreateLevel("Level1");
            base.Initialize();
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
                Menu.Display();
                if (kstate.IsKeyDown(Keys.Space))
                {
                    menuOpen = false;
                }
            }
            else
            {
                level.Update(player, kstate);
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
            spriteBatch.Draw(playerSprite, new Vector2(player.Position.X - Constants.PLAYER_RADIUS, player.Position.Y - Constants.PLAYER_RADIUS), player.Color);
            var kstate = Keyboard.GetState();
            if (kstate.IsKeyDown(keyBinds.Slow))
            {
                spriteBatch.Draw(hitboxSprite, new Vector2(player.Position.X - 6, player.Position.Y - 2), Color.Chartreuse);
            }
            
            //spriteBatch.DrawString(gameFont, (level.FrameCount/60).ToString(), new Vector2(780, 70), Color.Chartreuse);
            spriteBatch.DrawString(gameFont, $"Player Lives: {player.Lives}", new Vector2(725, 70), Color.Chartreuse);
            if (menuOpen)
            {
                spriteBatch.DrawString(gameFont, Menu.menuString1, new Vector2(100, 100), Color.Fuchsia);
                spriteBatch.DrawString(gameFont, Menu.menuString2, new Vector2(100, 150), Color.Fuchsia);
                spriteBatch.DrawString(gameFont, Menu.menuString3, new Vector2(100, 200), Color.Fuchsia);
            }
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
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
