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
        public int year;        // objects
        public string id;
        public Student(string n, int y, string i)
        {
            name = n; 
            year = y;         // constructor
            id = i;
        }
        public void PrintInfo()
        {
            Console.WriteLine(name + " " + year);   // method
        }
        public void Increment()
        {
            year = year + 1;    // method of increment
 
            Console.WriteLine();
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            Student s = new Student("Naruto", 1,"1106");    
            Student s2 = new Student("Sasuke",2,"1105");   
            s.PrintInfo();
            s2.PrintInfo();
            s.Increment();
            s2.Increment();
            s.PrintInfo();
            s2.PrintInfo();
        }
    }
}