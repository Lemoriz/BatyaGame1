using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game1
{

    enum FireBallType
    {
        RedFire = 0, GreenFire
    }

    class FireBall : GameObject, IDrawableObject
    {
        /// <summary>
        /// Fireball type
        /// </summary>
        private FireBallType _type;

        private Color color { get; set; }
        private static Texture2D _texture { get; set; }
        public bool Visible { get; set; }

        public FireBall(Vector2 vel, Rectangle rect, float rotSpeed, bool visible, FireBallType type) : base(vel, rect, rotSpeed, true)
        {
            _type = type;
            Visible = visible;
            switch (type)
            {
                case FireBallType.RedFire:
                    color = Color.Red;
                    break;
                case FireBallType.GreenFire:
                    color = Color.Green;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }


        public Texture2D GetTexture()
        {
            return _texture;
        }

        public Color GetColor()
        {
            return color;
        }

        /// <summary>
        /// Load on game initializing loading content
        /// </summary>
        /// <param name="texture"></param>
        public void LoadTexture(Texture2D texture)
        {
            _texture = texture;
        }
    }
}
