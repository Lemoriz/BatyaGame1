using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework.Graphics;

namespace Game1
{
    internal class TextureHandler
    {
        List<Texture2D> _array;

        public TextureHandler(List<Texture2D> list)
        {
            _array = list;

        }

        public void LoadTexture()
        {


        }

        //TODO NEED TO REWRITE GET TEXTURE ALGORITHM
        /// <summary>
        /// Get Texture
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Texture2D GetTexture(string name)
        {
            return _array.FirstOrDefault(texture2D => texture2D.Name == name);
        }

    }
}