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
           
            for (int i = 2; i <= Math.Sqrt(n); i++)  // taking square root  of n using Math
                if (n % i == 0)
                    return false;
            return true;
        }


        static void Main(string[] args)
        {
            string line1 = Console.ReadLine();  // amount of number in the array
            string line2 = Console.ReadLine();  // array

            int n = int.Parse(line1);   
            string[] numsStr = line2.Split();   // array -> mini arrays
            string res = "";   // create empty string 
            int cnt;     // counter
            cnt = 0;


            for (int i = 0; i < numsStr.Length; ++i)
            {
                int x = int.Parse(numsStr[i]);   // string -> int
                if (Isprime(x)==true) 
                {
                    cnt++; 
                    res = res + x + " ";        // prime function test
                }

            }
            
             Console.WriteLine(cnt);
            Console.WriteLine(res);



        }
    }
}
