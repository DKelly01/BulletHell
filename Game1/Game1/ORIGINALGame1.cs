using System;

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
        Texture2D targetSprite;
        Texture2D crosshairsSprite;
        Texture2D backgroundSprite;

        SpriteFont gameFont;

        Vector2 targetPosition = new Vector2(300,300);
        const int TARGET_RADIUS = 45;

        MouseState mstate;
        bool mReleased = true;

        int score = 0;
       
        float mouseTargetDist;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            IsMouseVisible = true;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

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
            targetSprite = Content.Load<Texture2D>("target");
            crosshairsSprite = Content.Load<Texture2D>("crosshairs");
            backgroundSprite = Content.Load<Texture2D>("sky");

            gameFont = Content.Load<SpriteFont>("galleryFont");
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
            mstate = Mouse.GetState();
            mouseTargetDist = Vector2.Distance(targetPosition, new Vector2(mstate.X, mstate.Y));

            if (mstate.LeftButton == ButtonState.Pressed && mReleased == true)
            {
                if (mouseTargetDist < TARGET_RADIUS)
                {
                    score++;
                    Random rand = new Random();
                    targetPosition.X = rand.Next(TARGET_RADIUS, graphics.PreferredBackBufferWidth - TARGET_RADIUS + 1);
                    targetPosition.Y = rand.Next(TARGET_RADIUS, graphics.PreferredBackBufferHeight - TARGET_RADIUS + 1);
                }
              
                mReleased = false;
            }

            if (mstate.LeftButton == ButtonState.Released)
            {
                mReleased = true;
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            //Add your drawing code here
            spriteBatch.Begin();
            
            spriteBatch.Draw(backgroundSprite, new Vector2(0,0), Color.White);
            spriteBatch.Draw(targetSprite, new Vector2(targetPosition.X - TARGET_RADIUS, targetPosition.Y - TARGET_RADIUS), Color.White);
            spriteBatch.DrawString(gameFont, score.ToString(), new Vector2(100, 100), Color.Chartreuse);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
