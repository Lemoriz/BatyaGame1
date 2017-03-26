using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Game1
{
    class Updater
    {
        private static IEnumerable<IUpdatableObject> _array;
        private int _width;
        private int _height;
        InputHandler _handler;

        public Updater(InputHandler handler, int width, int height, IEnumerable<IUpdatableObject> array)
        {
            _handler = handler;
            _width = width;
            _height = height;
            _array = array;
        }


        public void Update(GameTime dt)
        {

            foreach (var x in _array)
            {
               
                if (x is Player)
                {     
                    x.ChangeVelocity((Convert.ToSingle(_handler.right) - Convert.ToSingle(_handler.left)), 
                        x.GetVelocity().Y);
                    
                    x.ChangeVelocity(x.GetVelocity().X,
                        Convert.ToSingle(_handler.down) - Convert.ToSingle(_handler.up));

               
                    if (x.GetRect().X + x.GetVelocity().X > 0 && x.GetRect().X +
                        x.GetVelocity().X + x.GetRect().Width < _width)
                    {
                        x.ChangePosition(new Vector2(x.GetRect().Location.X
                            + x.GetVelocity().X*4, x.GetRect().Location.Y) );
                    }


                    if (x.GetRect().Y + x.GetVelocity().Y > 0 && x.GetRect().Y +
                        x.GetVelocity().Y + x.GetRect().Height < _height)
                     {
                        x.ChangePosition(new Vector2(x.GetRect().X, x.GetRect().Location.Y
                            + x.GetVelocity().Y*4));

                      }
                }
                else if (x is FireBall)
                {
                   
                    if (x.GetPos().X < 0 || (x.GetPos().X + x.GetRect().Width > _width))
                    {
                        x.InvertXVel();
                        
                    }
                    if (x.GetPos().Y < 0 || (x.GetPos().Y + x.GetRect().Height > _height))
                    {
                        x.InvertYVel();

                    }

                    x.ChangePosition(x.GetVelocity()+x.GetPos());

                }
            }
        }

    }
}
