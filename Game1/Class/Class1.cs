using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game1
{
    class Ball
    {
        public Point point = new Point();

        Color color;

        public Vector2 velocity;

        public Ball(int x, int y, Color color, Vector2 vel)
        {
            velocity = vel;
            point.X = x;
            point.Y = y;
            this.color = color;
        }
        public Color GetColor()
        {
            return color;
        }
        public Point reter()
        {
            return point;
        }
    }

    class Class2
    {
        const int BALL_MAX_SPEED = 5;
        int Health_points = 3;
        int max_num = 20;
        int green_count;
        List<Ball> array;
        int count = 0;

        int point = 0;
        double start_time = 0;

        public Class2()
        {
            Restart(0);
        }

        public double GetTime()
        {
            return start_time;
        }

        public void Restart(double f)
        {
            start_time = f;
            Random rand = new Random();
            List<Color> color = new List<Color>();
            color.Add(Color.Red);
            color.Add(Color.Green);
           
            array = new List<Ball>();
            count = 0;
            green_count = 0;
            for (int i = 0; i < max_num; i++)
            {
                var x = rand.Next(10, 1305);
                var y = rand.Next(10, 700);
               

                Console.WriteLine("Random == {0} ", rand.Next(1, 6));
                Vector2 vec = new Vector2(((float)rand.NextDouble()+1) * BALL_MAX_SPEED - 4, ((float)rand.NextDouble()+1) * BALL_MAX_SPEED -4);
                Ball name_color = new Ball(x, y, rand.Next(0,100) < 20 ? Color.Green : Color.Red, vec);
                if (name_color.GetColor() == Color.Green)
                    green_count++;
                array.Add(name_color);

                count++;
                point = 0;
                Health_points = 3;             
            }
            
        }
        public int restartTime(int X)
        {            
            return 0;
        }

        public int GetScore()
        {
            return point;
        }

        public int Get_HP()
        {
            return Health_points;  
        }

        public int Max()
        {
            return green_count;
        }

        public void Update(Vector2 ship_x_y)
        {
            for (int i = 0; i < count; i++)
            {

                if ((array[i].reter().X + array[i].velocity.X > 1366) || array[i].reter().X + array[i].velocity.X < 0)
                    array[i].velocity.X *= -1;
                if ((array[i].reter().Y + array[i].velocity.Y > 768) || array[i].reter().Y + array[i].velocity.Y < 0)
                    array[i].velocity.Y *= -1;

                array[i].point.X += (int)array[i].velocity.X;
                array[i].point.Y += (int)array[i].velocity.Y;


                var fire_x_y = array[i].reter();
                var Color_ball = array[i].GetColor();
                
               //Коллизии 
                if (fire_x_y.X + 40 > ship_x_y.X && fire_x_y.X - 40 < ship_x_y.X && fire_x_y.Y + 40 > ship_x_y.Y && fire_x_y.Y - 40 < ship_x_y.Y)
                {
                    if (Color_ball == Color.Red)
                    {
                        array.RemoveAt(i);
                        count--;     
                        Health_points--;
                        
                    }
                    if (Color_ball == Color.Green)
                    {
                        array.RemoveAt(i);
                        count--;
                        point++;
                    }
                }
            }
        }        

        public void paint(Texture2D qqq, SpriteBatch spr)
        {
            for (int i = 0; i < count; i++)
            {
                    spr.Draw(qqq, array[i].reter().ToVector2(), array[i].GetColor());
            } 
        } 
    }
}
