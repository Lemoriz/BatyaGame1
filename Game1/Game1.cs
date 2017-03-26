using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Configuration;
using Microsoft.Xna.Framework.Content;

namespace Game1
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    /// 
   
    public class Game1 : Game
    {

       
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        private SpriteFont font;
        LoadConfig config;
        GameEngine MainGameEngine;

        public Game1()
        {
            config = new LoadConfig();

            graphics = new GraphicsDeviceManager(this)
            {
                IsFullScreen = config.FullScreen,
                PreferredBackBufferHeight = config.ScreenH,
                PreferredBackBufferWidth = config.ScreenW
            };
            
            graphics.ApplyChanges();
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        /// 

        protected override void Initialize()
        {

          
          IsFixedTimeStep = false;
           //*************************************************************************************************
           // TODO: Add your initialization logic here
            base.Initialize();
            //*************************************************************************************************
        }
        List<Texture2D> textarray; 


        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {   
            //TEXTARRAY
            //TODO NEED TEXTURE AND CONTENT MANAGER
         

            textarray = new List<Texture2D>();
            textarray.Add(Content.Load<Texture2D>("images/fire2"));
            
            textarray.Add(Content.Load<Texture2D>("images/ssssss"));
            textarray.Add(Content.Load<Texture2D>("images/space"));
            spriteBatch = new SpriteBatch(GraphicsDevice);

            MainGameEngine = new GameEngine(spriteBatch, textarray, config);
            MainGameEngine.Refresh();

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
        /// 


        protected override void Update(GameTime gameTime)
        {
            
            MainGameEngine.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {            
                GraphicsDevice.Clear(Color.CornflowerBlue);

                spriteBatch.Begin();

                MainGameEngine.Draw();
            
                spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}