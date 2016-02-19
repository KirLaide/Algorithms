using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fibonachy
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] values = Console.ReadLine().Split(new[] { ' ' });
            long n = long.Parse(values[0]);
            int m = int.Parse(values[1]);
            
            long fibPrev = 0;
            long fib = 1;
            long fibOld = 0;

            List<long> cached = new List<long>() { fibPrev, fib };
            
            if (n >= 1 && n <= Math.Pow(10, 18) && m >= 2 && m <= Math.Pow(10, 5))
            {
                for(long i = 2; i<= n; i++)
                {
                    fibOld = fib;
                    fib = (fib + fibPrev) % m;
                    fibPrev = fibOld;

                    if(fibPrev == 0 && fib == 1)
                    {
                        cached.RemoveAt(cached.Count - 1);
                        break;
                    }
                    else
                    {
                       cached.Add(fib);
                    }
                }
                int offset = (int)(n % cached.ToArray().Length);

                Console.WriteLine(cached[offset].ToString());
                Console.ReadLine();
            }
            
        }
    }
}
