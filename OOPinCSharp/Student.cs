using OOPinCSharps;
using StockManagement;
//using OOPinCSharps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPinCSharp
{
    public class Student
    {
        public int studentId { get; set; }
        public int studentAge { get; set; }
        public string studentName { get; set; }
        public string studentEmail { get; set; }
        public string studentPhone { get; set; }
        public string studentDepartment { get; set; }

        public Student()
        {

            this.studentAge = 23;
        }
        public void DisplayStudentDetail()
        {
            Console.WriteLine($"Student Name: {this.studentName} Id: {this.studentId} Age: {this.studentAge}");
        }
        public static void Main7()
        {
            Student student1= new();
            student1.studentId = 13;
            //student1.studentAge = 32;
            student1.studentName = "Ahmed";
            student1.DisplayStudentDetail();
            //student1.Description = "aaaaaaaaaaaaaaaaaa";
            //Product product1 = new ("Laptop", 1234);
            //product1.Name = "Laptop";
            //product1.Price = 100;
            //OOPinCSharps.Product product2 = new OOPinCSharps.Product(123, "Bed", "1.80 or Kingsize bed ", 23000, 5);
            //Product product3 = product1;
            //Console.WriteLine($"Product Name: {product3.Name} Price {product3.Price}"); // Laptop 1234
            //product1.Price = 20000;
            //Console.WriteLine($"Product Name: {product3.Name} Price {product3.Price}"); // Laptop 20000

            Order order1 = new Order();
            Console.WriteLine($"Order Id: {order1.Id} Order Name: {order1.Name}");
        }


    }
}
