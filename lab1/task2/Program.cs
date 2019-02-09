using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example4
{
    class Student
    {
        public string name;
        public string year;
        public string id;
        public Student(string n, string y, string i)
        {
            name = n;
            year = y;
            id = i;
        }
        public void PrintInfo()
        {
            Console.WriteLine(name + " " + id);
        }
        public void PrintInfo2()
        {
            int x = int.Parse(year);
            Console.WriteLine(x+1);
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            Student s = new Student("Naruto", "1","1106");
            Student s2 = new Student("Sasuke", "2","1105");
            s.PrintInfo();
            s2.PrintInfo();
            s.PrintInfo2();
            s2.PrintInfo2();
        }
    }
}