using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game1
{
    class button
    {

        string caption;
        public int type;
        Rectangle button_rect;

        public void new_function()
        {
            //asdasdas
        }


        public button(string caption, Point location, int type)
        {
            this.type = type;
            this.caption = caption;
            button_rect.Location = location;
            button_rect.Width = 300;
            button_rect.Height = 50;

        }
        public Rectangle GetRect()
        {
            return button_rect;
        }

        public bool isOnButton(Point q)
        {
            if(q.X < button_rect.X+button_rect.Width && q.X > button_rect.X)
                if (q.Y < button_rect.Y + button_rect.Height && q.Y > button_rect.Y)
                    return true;
                
            return false;
        }

        public string GetCaption()
        {
            return caption;
        }

    }

    class menu
    {
        Texture2D text;
        SpriteFont font;

        List<button> button_array = new List<button>();

        public menu(Texture2D texture, SpriteFont f)
        {
            //this.number = number;
            text = texture;
            font = f;
            button_array.Add(new button("New game", new Point(600, 300), 1));
            button_array.Add(new button("Settings", new Point(600, 360), 2));
            button_array.Add(new button("Records", new Point(600, 420), 3));
            button_array.Add(new button("Exit", new Point(600, 480), 4));
        }

        public int Update(Point f)
        {
            foreach (var x in button_array)
            {
                if (x.isOnButton(f))
                {
                    Console.WriteLine("dsadsad");
                    switch (x.type)
                    {
                        case 1:
                            return 1;
                        case 2:
                            return 2;
                        case 3:
                            return 3;
                        case 4:
                            return 4;
                    }
                }
            }
            return 0;
        }

        public void Show(SpriteBatch s)
        {
            foreach (var x in button_array)
            {
                var z = x.GetRect();

                s.Draw(text, x.GetRect(), Color.White);
                s.DrawString(font, x.GetCaption(), x.GetRect().Location.ToVector2(), Color.Red);
            }
        }
    }
}
