
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game1
{
    class Player : GameObject, IDrawableObject
    {
        private readonly InputHandler _handler;
        static Texture2D _texture;
        public const float speed = 4f;
        public bool Visible { get; set; }
        public Player(Vector2 vel, Rectangle rect, float rotSpeed, bool visible, InputHandler handler) : base(vel, rect, rotSpeed,true)
        {
            Visible = visible;
            _handler = handler;
        }
        

        public Texture2D GetTexture()
        {

            return _texture;
        }

        public void LoadTexture(Texture2D texture)
        {
            if(texture == null)
                throw new NullReferenceException("Texture null");
            _texture = texture;

        }


        public Color GetColor()
        {
            return Color.AliceBlue;
        }
    }

}
