using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace t2
{
    class Program
    {
        static void Main(string[] args)
        {

            string line1 = Console.ReadLine(); // количество чисел в входном массиве
            string line2 = Console.ReadLine(); // массив

            
            string[] numsStr = line2.Split(); 
            List<int> s = new List<int>(); // создаем list
            for (int i = 0; i < numsStr.Length; ++i)
            {
                int x = int.Parse(numsStr[i]); // string -> int 
                s.Add(x);
                s.Add(x);
            }
            for (int i =0;i<s.Count;i++)
            {
                Console.Write(s[i]);
            }
        }
    }
}
