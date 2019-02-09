using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1
{
    class Program
    {
        static bool Isprime(int n)
        {
            if (n == 1 || n == 0)
            {
                return false;
            }
            int sqrt = (int)Math.Sqrt(n);
            for (int i = 2; i <= sqrt; i++) 
                if (n % i == 0)
                    return false;
            return true;
        }


        static void Main(string[] args)
        {
            string line1 = Console.ReadLine();
            string line2 = Console.ReadLine();

            int n = int.Parse(line1);
            string[] numsStr = line2.Split();
            string res = "";
            int cnt;
            cnt = 0;


            for (int i = 0; i < numsStr.Length; ++i)
            {
                int x = int.Parse(numsStr[i]);
                if (Isprime(x)==true)
                {
                    cnt++;
                    res = res + x + " ";
                }

            }
            
             Console.WriteLine(cnt);
            Console.WriteLine(res);



        }
    }
}
