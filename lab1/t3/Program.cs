using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace t3
{
    class Program
    {
        static void Main(string[] args)
        {
            string line = Console.ReadLine();
            int n = int.Parse(line);
            for (int i = 0; i < n; ++i)
            {
                for (int j = n-1-i; j < n; ++j)
                {
                    Console.Write("[*]");
                }
                Console.WriteLine(" ");
            }
        }
    }
}
