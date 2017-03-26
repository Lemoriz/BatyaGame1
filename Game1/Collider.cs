using System;
using System.Collections.Generic;

namespace Game1
{
    class Collider
    {
        static List<GameObject> _array;

        public Collider(List<GameObject> array)
        {
            if (array == null)
                throw new NullReferenceException("array null");
            _array = array;
        }

        public void Update()
        {
           
            for (int i = 0; i < _array.Count; i++)
            {
                if(!_array[i].Collidable) continue;
                for (int j = i+1; j < _array.Count; j++)
                {
                    if (!_array[j].Collidable) continue;
                    if (Intersect(_array[i], _array[j]))
                    {
                        Console.WriteLine("Type {0} intersects with", _array[i].GetType(), _array[j].GetType());
                    }

                }
            }
        }

        bool Intersect(GameObject x, GameObject y)
        {
            
            double D = Math.Sqrt(Math.Pow(x.GetPos().X - y.GetPos().X, 2)
                                 + Math.Pow(x.GetPos().Y - y.GetPos().Y, 2));
            int r1 = x.GetRect().Width/2;
            int r2 = y.GetRect().Width / 2;

            if(D <= r1+r2 && D >= Math.Abs(r1-r2))
                return true;
            return false;

        }





    }
}
