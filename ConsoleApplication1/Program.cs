using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            float f = -1f;
            Console.WriteLine("{0}", Convert.ToInt32(Math.Floor((double)f)));
            Console.ReadKey();
        }
    }
}
