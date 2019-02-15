using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace t4
{
    class Program
    {
        private static void PrintInfo(FileSystemInfo fsi, int k)
        {
            string line = new string(' ', k);    // k is equal the number of spaces
            line = line + fsi.Name;              
            Console.WriteLine(line);

            if (fsi.GetType() == typeof(DirectoryInfo))    
            {
                var items = (fsi as DirectoryInfo).GetFileSystemInfos();   // if item = directory then we open it
                foreach (var i in items)
                {
                    if (i.GetType() == typeof(DirectoryInfo))
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;  //if we have directory
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;   //if we have file
                    }
                    PrintInfo(i, k + 4);  //recursion
                }
            }
        }
        static void Main(string[] args)
        {
          
           DirectoryInfo dir = new DirectoryInfo(@"C:\kokosnew\lab1\task1");   //link to our directory
           PrintInfo(dir, 1);    // function
            

        }
    }
}
