﻿using System;
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

            string line1 = Console.ReadLine();
            string line2 = Console.ReadLine();

            
            string[] numsStr = line2.Split();

            for (int i = 0; i < numsStr.Length; ++i)
            {
                int x = int.Parse(numsStr[i]);
               
                    Console.Write(x + " " + x + " ");
                

            }
        }
    }
}
