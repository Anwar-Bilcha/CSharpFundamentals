using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace StockManagement
{
    public class Student
    {

    }
   class Product
    {
        protected string Description {  get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public Product(string name, double price)
        {
            Name = name; Price = price;
        }
        // Virtual method for calculating discount
        public virtual double CalculateDiscount()
        {
            // Default discount is 5%
            return Price * 0.05;
        }
        public void DisplayDetails()
        {
            Console.WriteLine($"Product: {Name}, Price: {Price:C}, Discount: {CalculateDiscount():C}");
        }
        // Derived Class: Electronic
        class Electronic : Product
        {
            public Electronic(string name, double price) : base(name, price) { }
            // Override the CalculateDiscount method
            public override double CalculateDiscount() // Electronics have a 10% discount
            {
                return Price * 0.10;
            }
        }
        class Cloth : Product  // Derived Class: Clothing
        {
            public Cloth(string name, double price) : base(name, price) { }
            public override double CalculateDiscount() // Override the CalculateDiscount method
            {
                return Price * 0.15; // Clothing has a 15% discount
            }
        }


        public static void Main1(string[] args)
        {
            // Create instances of different products
            Product genericProduct = new Product("Generic Item", 100);
            Product laptop = new Electronic("Laptop", 1000);
            Product shirt = new Cloth("Shirt", 50);

            // Display details
            genericProduct.DisplayDetails(); // Output: Product: Generic Item, Price: $100.00, Discount: $5.00
            laptop.DisplayDetails();         // Output: Product: Laptop, Price: $1,000.00, Discount: $100.00
            shirt.DisplayDetails();          // Output: Product: Shirt, Price: $50.00, Discount: $7.50
        }
    }


}