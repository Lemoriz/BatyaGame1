using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{


    

    class Program
    {

        public static void MyFunc(int x, int y )
        {
            Console.WriteLine("X = {0}, Y = {1}", x, y);
        }

        public static void MyFunc2(int x, int y)
        {
            Console.WriteLine("Second Func: X = {0}, Y = {1}", x*6,y*6);
        }


        public static void Delegatefunc(FunctionDelegate f)
        {
            int q = 5;
            f(q,q);
            
        }

        public delegate void FunctionDelegate(int x, int y);
    
        static void Main(string[] args)
        {

            FunctionDelegate f = MyFunc;
            FunctionDelegate q = MyFunc2;

            Delegatefunc(f);
            Delegatefunc(q);


            Console.ReadKey();

        }
    }
}
