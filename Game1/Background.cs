using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game1
{
    class Background : GameObject, IDrawableObject
    {
        static Texture2D _texture;
        public Background(int width, int height)
        {
            Collidable = false;
            Velocity = Vector2.Zero;
            Rect = new Rectangle(0, 0, width, height);
        }

        public bool Visible { get; set; } = true;
        public Texture2D GetTexture()
        {
            return _texture;

        }

        public void LoadTexture(Texture2D texture)
        {
            _texture = texture;

        }

        public Rectangle GetRect()
        {
            return Rect;

        }

        public Color GetColor()
        {
            return Color.AliceBlue;
        }
    }

}
