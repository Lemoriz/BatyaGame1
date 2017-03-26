
using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework.Graphics;

namespace Game1
{
    class RenderEngine
    {
        private readonly SpriteBatch _spriteBatch;
        private readonly List<GameObject> _array;


        /// <summary>
        /// Initialize renderer
        /// </summary>
        /// <param name="spr">Sprite batch</param>
        /// <param name="array">IDrawableObject Collection</param>
        public RenderEngine(SpriteBatch spr, List<GameObject> array)
        {
            _array = array;
            _spriteBatch = spr;
        }

        public void Update()
        {
            foreach (var _object in _array)
            {
                //TODO
                //Allow rotation
                if(_object is IDrawableObject)
                if ((_object as IDrawableObject).Visible)
                    _spriteBatch.Draw((_object as IDrawableObject).GetTexture(), 
                        _object.GetRect(), (_object as IDrawableObject).GetColor());
            }
        }
    }

}
