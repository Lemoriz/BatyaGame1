using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game1
{
    class FireballEmiter
    {
        List<FireBall> _array;
        int max_num = 10; // CHANGE IT
        int BALL_MAX_SPEED = 5;
        public List<FireBall> Emit(Texture2D texture)
        {
            _array = new List<FireBall>();
            var rand = new Random();
            

            for (int i = 0; i < max_num; i++)
            {
                FireBall fb;

                var x = rand.Next(10, 20);
                var y = rand.Next(10, 700);

                Vector2 vec = new Vector2(((float)rand.NextDouble() + 1) * BALL_MAX_SPEED - 4, ((float)rand.NextDouble() + 1) * BALL_MAX_SPEED - 4);

                Ball nameColor = new Ball(x, y, rand.Next(0, 100) < 20 ? Color.Green : Color.Red, vec);


                if (nameColor.GetColor() == Color.Green)
                {
                    fb = new FireBall(vec, new Rectangle(x, y, 20, 20), 0, true, FireBallType.GreenFire);
                    fb.LoadTexture(texture);

                }
                else
                {
                    fb = new FireBall(vec, new Rectangle(x, y, 20, 20), 0, true, FireBallType.RedFire);
                    fb.LoadTexture(texture);
                }
                _array.Add(fb);

            }
            return _array;
        }
    }
}
