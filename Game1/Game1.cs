using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Game1
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    /// 
   
    public class Game1 : Game
    {

        Point mousecords;
        const int screen_resolution1 = 1366;
        const int screen_resolution2 = 768;
        const int MAX_TIME = 100;
        const float deceleration = 0.1f;
        const float acceleration = 0.1f;
        private Texture2D background;
        private Texture2D earth;
        private Texture2D fire;
        private Texture2D heart;
        menu menu1;
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        private SpriteFont font;//1366*768
        Class2 elements;
        private int score = 0;
        float rot =0;
        double coount1 = 0;
        double coount2 = 0;
        bool activgame = false;
        bool inmenu = true;
       


        Vector2 direction = new Vector2(1, 1);
        Vector2 direction2 = new Vector2(1, 1);

        Vector2 pos = new Vector2(683, 384);

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.IsFullScreen = true;//!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            graphics.PreferredBackBufferHeight = screen_resolution2;
            graphics.PreferredBackBufferWidth = screen_resolution1;
            graphics.ApplyChanges();
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {

            
            IsFixedTimeStep = false;
           //*************************************************************************************************
           // TODO: Add your initialization logic here
           elements = new Class2();
            base.Initialize();
            //*************************************************************************************************
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.

            
            spriteBatch = new SpriteBatch(GraphicsDevice);
         
            background = Content.Load<Texture2D>("images/space"); // change these names to the names of your images
            fire = Content.Load<Texture2D>("images/fire2");       // if you are using your own images.
            heart = Content.Load<Texture2D>("images/heart");
            earth = Content.Load<Texture2D>("images/ssssss");
            font = Content.Load<SpriteFont>("fonts/font2");
            menu1 = new menu(Content.Load<Texture2D>("images/button"), font);


            // TODO: use this.Content to load your game content here
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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                inmenu = true;
                activgame = false;
            }
            KeyboardState state = Keyboard.GetState();

            IsMouseVisible = true;
            mousecords = Mouse.GetState().Position;
            if(inmenu == true)
            if (Mouse.GetState().LeftButton == ButtonState.Pressed)
                {
                    Console.WriteLine("Button Pressed");
                    if (menu1.Update(mousecords) == 1)
                    {
                        elements.Restart(gameTime.TotalGameTime.TotalSeconds);
                        activgame = true;
                        inmenu = false;
                    }

                    if (menu1.Update(mousecords) == 2)
                    {
                        Console.WriteLine("Settings");
                    }

                    if (menu1.Update(mousecords) == 3)
                    {
                        Console.WriteLine("Record");
                    }

                    if (menu1.Update(mousecords) == 4)
                    {
                        Exit();
                    }
                }
               


          //  Console.WriteLine("Mousecords are {0}", mousecords);

            double ff = 0;

            bool leftArrowKeyDown = state.IsKeyDown(Keys.Left);

            //Ускорение*****************************************************************************************
            if (state.IsKeyDown(Keys.Up))
            {
                if (pos.X + direction.X * coount1 > 0 && pos.X + direction.X * coount1 < screen_resolution1)
                {
                    if (coount1 < 4)
                        coount1 += acceleration;
                    pos.X = (pos.X + direction.X * (float)(coount1 + ff));
           
                }

                if (pos.Y + direction.Y * coount1 > 0 && pos.Y + direction.Y * coount1 < screen_resolution2)
                {
                    if (coount1 < 4)
                        coount1 += acceleration;
                    pos.Y = (pos.Y + direction.Y * (float)(coount1 + ff));
                  
                }
            }
            //Ускорение*****************************************************************************************


            //Инерция*****************************************************************************************
            if (!state.IsKeyDown(Keys.Up))
            {
                if (pos.X + direction.X * coount1 > 0 && pos.X + direction.X * coount1 < screen_resolution1)
                {
                    if (coount1 > 0)
                        coount1 -= deceleration;

                    pos.X = (pos.X + direction.X * (float)(coount1 + ff));

                
                    if (coount1 < 0)
                        coount1 = 0;
                }

                if (pos.Y + direction.Y * ff > 0 && pos.Y + direction.Y * ff < screen_resolution2)
                {
                    if (coount1 > 0)
                        coount1 -= deceleration;

                    pos.Y = (pos.Y + direction.Y * (float)(coount1 + ff));

                    
                    if (coount1 < 0)
                        coount1 = 0;
                }
            }
            //Инерция*****************************************************************************************


            //Ускорение*****************************************************************************************
            if (state.IsKeyDown(Keys.Down))
            {
                if (pos.X + direction2.X * coount2 > 0 && pos.X + direction2.X * coount2 < screen_resolution1)
                {
                    if (coount2 < 4)
                        coount2 += acceleration;

                        pos.X = (pos.X - direction.X * (float)(coount2 + ff));
                }

                if (pos.Y + direction2.Y * coount2 > 0 && pos.Y + direction2.Y * coount2 < screen_resolution2)
                {
                    if (coount2 < 4)
                        coount2 += acceleration;

                        pos.Y = (pos.Y - direction.Y * (float)(coount2 + ff));                    
                }
            }
            //Ускорение*****************************************************************************************


            //Инерция*****************************************************************************************
            if (!state.IsKeyDown(Keys.Down))
            {
                if (pos.X + direction2.X * coount1 > 0 && pos.X + direction2.X * coount1 < screen_resolution1)
                {
                    if (coount2 > 0)
                        coount2 -= deceleration;

                    pos.X = (pos.X - direction.X * (float)(coount2 + ff));

                    if (coount1 < 0)
                        coount1 = 0;
                }

                if (pos.Y + direction2.Y * ff > 0 && pos.Y + direction2.Y * ff < screen_resolution2)
                {
                    if (coount2 > 0)
                        coount2 -= deceleration;

                    pos.Y = (pos.Y - direction.Y * (float)(coount2 + ff));

                    if (coount2 < 0)
                        coount2 = 0;
                }
            }
            //Инерция*****************************************************************************************
                     
                if (state.IsKeyDown(Keys.Right))            
                rot += 0.05f;           

            if (state.IsKeyDown(Keys.Left))
                rot -= 0.05f;                

            direction.X = (float)Math.Cos(rot);
            direction.Y = (float)Math.Sin(rot);

            direction2.X = (float)Math.Cos(rot + (float)Math.PI);
            direction2.Y = (float)Math.Sin(rot + (float)Math.PI);

            score++;

            if (elements.Max() == elements.GetScore())
            {
                activgame = false;
            }

            if (MAX_TIME ==  Math.Round(gameTime.TotalGameTime.TotalSeconds - elements.GetTime(), 1)|| elements.Get_HP()==0)
            {
                activgame = false;                              
            }

            if (state.IsKeyDown(Keys.Space) && activgame == false)
            {
                activgame = true;
                elements.Restart(gameTime.TotalGameTime.TotalSeconds);
                pos.X = 683;
                pos.Y = 384;
            }

            
            // TODO: Add your update logic here
                base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {            
                GraphicsDevice.Clear(Color.CornflowerBlue);

                spriteBatch.Begin();


                spriteBatch.Draw(background, new Rectangle(0, 0, screen_resolution1, screen_resolution2), Color.White);

            if (activgame == true)
            {
                spriteBatch.Draw(heart, new Rectangle(0, 60, 50, 50), Color.Red);
                spriteBatch.DrawString(font, "Batya TIME: " +(MAX_TIME- Math.Round(gameTime.TotalGameTime.TotalSeconds - elements.GetTime(),1)), new Vector2(0, 0), Color.White);
                spriteBatch.DrawString(font, "FPS: " + (int)(1 / gameTime.ElapsedGameTime.TotalSeconds), new Vector2(1240, 0), Color.White);
                
                spriteBatch.Draw(earth, pos, null, Color.AliceBlue, rot + (float)Math.PI / 2, earth.Bounds.Center.ToVector2(), 1, SpriteEffects.None, 1);
       

                elements.paint(fire, spriteBatch);
                elements.Update(pos);

                // elements.search();

                //spriteBatch.DrawString(font, "Batya TIME: " + score,new Vector2(0, 0), Color.White);
                spriteBatch.DrawString(font, "Point: " + elements.GetScore(), new Vector2(0, 30), Color.White);
                spriteBatch.DrawString(font, "    " + elements.Get_HP(), new Vector2(0, 70), Color.Red);

                //spriteBatch.DrawString(font, elements.GetttScore(), new Vector2(400, 400), Color.White);

            }
            else
            {
                if (inmenu == false)
                {
                    if (elements.Max() == elements.GetScore())
                    {
                        spriteBatch.DrawString(font, "YOU WIN ", new Vector2(680, 380), Color.White);
                    }

                    if ((MAX_TIME == Math.Round(gameTime.TotalGameTime.TotalSeconds - elements.GetTime(), 1)) || elements.Get_HP() == 0)
                    {

                        spriteBatch.DrawString(font, "GAME OVER ", new Vector2(680, 380), Color.White);
                    }
                }
                else
                {
                    menu1.Show(spriteBatch);

                }
            }
            spriteBatch.DrawString(font, "M: " + mousecords, new Vector2(900, 40), Color.White);

            spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}