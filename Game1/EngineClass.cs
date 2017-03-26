
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static System.Random;



//GAME LOGIK
namespace Game1
{

    class GameEngine
    {
 
        List<GameObject> _array;

        RenderEngine _render;
        Updater _updater;
        Collider _collider;
        InputHandler _inputHandler;
        TextureHandler _textureHandler;
        SpriteBatch _spriteBatch;
        FireballEmiter _emiter;
        Player _player;
        Background _background;
        LoadConfig configuration;

        List<Texture2D> textures; 

        public GameEngine(SpriteBatch spr, List<Texture2D> txlst, LoadConfig config)
        {
            textures = txlst;
            configuration = config;
            _array = new List<GameObject>();

            _emiter = new FireballEmiter();
            _spriteBatch = spr;
            _inputHandler = new InputHandler();
            _collider = new Collider(_array);
            _render = new RenderEngine(_spriteBatch,_array);
            _textureHandler = new TextureHandler(txlst);
            _updater = new Updater(_inputHandler,  config.ScreenW,config.ScreenH,_array );

        }


       public void Refresh()
        {
            _array.Clear();
            _background = new Background(configuration.ScreenW, configuration.ScreenH);
            _background.LoadTexture(textures[2]);
            _array.Add(_background);

            _array.AddRange(_emiter.Emit(textures[0]));
        
          
            _player = new Player(Vector2.Zero, new Rectangle(10, 10, 20, 20), 0, true, _inputHandler);
            _player.LoadTexture(textures[1]);
            _array.Add(_player);

        }

        public void Update(GameTime dt)
        {
            _inputHandler.Update();
            _updater.Update(dt);
            _collider.Update();
        }

        public void Draw()
        {
            _render.Update();
        }


    }



}
