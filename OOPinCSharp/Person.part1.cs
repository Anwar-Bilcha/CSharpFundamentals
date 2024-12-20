using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPinCSharp
{
    public partial class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Person(string fname, string lname)
        {
            FirstName = fname;
            LastName = lname;
        }
        public void PrintName()
        {
            Console.WriteLine($"{FirstName} {LastName}");
        }
    }
}
