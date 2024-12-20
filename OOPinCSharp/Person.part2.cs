using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPinCSharp
{
    public partial class Person
    {
        public int Age { get; set; }
        public Person(string fname, string lname, int age) {
        FirstName = fname; 
        LastName = lname;
        Age = age;
        }
        public void PrintName(int age)
        {
            PrintName();
            Age = age;
            Console.WriteLine($"Age: {Age}");
        }
        public static void xMain(string[] args)
        {
            Person person = new Person("Anwar", "Bilcha");
            person.PrintName(36);

        }
    }
}
