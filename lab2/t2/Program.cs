using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace t2
{
    class Program {
        static bool Isprime(int n)
        {  // prime function test
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
            FileStream fs = new FileStream(@"C:\kokosnew\task2.txt", FileMode.Open, FileAccess.Read);    // open .txt file with numders
            StreamReader sr = new StreamReader(fs);                       

            string line = sr.ReadLine();          // rewrite array to new string
            sr.Close();
            fs.Close();
            string res = "";          // create empty string to write the result
            
            string[] num = line.Split();
            for (int i = 0; i < num.Length; ++i)
            {
                int x = int.Parse(num[i]);   //string -> int
               if (Isprime(x)==true)
                {
                    res = res + x + " ";
                }

            }
           
            FileStream fs2 = new FileStream(@"C:\kokosnew\task2res.txt", FileMode.OpenOrCreate, FileAccess.Write);   // crete (open) new .txt file to write result
            StreamWriter sw = new StreamWriter(fs2);
            sw.WriteLine(res);
            sw.Close();
            fs2.Close();

        }
    }
}
