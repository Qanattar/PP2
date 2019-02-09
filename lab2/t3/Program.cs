using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace t3
{
    class Program
    {
        static void Main(string[] args)
        {
            FileStream fs2 = new FileStream(@"C:\kokosnew\lab2\first\task3orig.txt", FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs2);
            sw.WriteLine("Qanat");
            sw.Close();
            fs2.Close();
            DirectoryInfo source = new DirectoryInfo(@"C:\kokosnew\lab2\first\");
            DirectoryInfo copy = new DirectoryInfo(@"C:\kokosnew\lab2\second\");

            foreach (var item in source.GetFiles())
            {
                item.CopyTo(copy + item.Name, true);
            }

            DirectoryInfo dirInfo = new DirectoryInfo(@"C:\kokosnew\lab2\first\");
            var file = dirInfo.GetFiles();
            foreach (var i in file)
            {
                i.Delete();
            }
        }
    }
}
