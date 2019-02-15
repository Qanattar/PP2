using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace t1
{
    class Program
    {
        static bool pal(string s)
        {
            // palindrom function test
            int length = s.Length;
            for (int i = 0; i < length / 2; i++)
            {
                if (s[i] != s[length - i - 1])    // first <-----> last
                    return false;       
            }
            return true;
        }
        static void Main(string[] args)
        {
            FileStream fs = new FileStream(@"C:\kokosnew\task1.txt", FileMode.Open, FileAccess.Read);    // open .txt file with word
            StreamReader sr = new StreamReader(fs); 
            string line = sr.ReadLine();                    // rewrite word to new string
            if (pal(line)==true)
            {
                Console.Write("Yes");
            }
            else
            {
                Console.WriteLine("No");
            }
            sr.Close();
            fs.Close();

        }
    }
}
