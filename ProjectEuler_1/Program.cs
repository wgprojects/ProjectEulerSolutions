using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace ProjectEuler_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            
            Solved.Problem66();

            sw.Stop();
            Console.WriteLine("Done in {0:0.000}s", sw.ElapsedMilliseconds / 1000f);
            Console.ReadKey();
        }

        

        


        
    }

    
}
