using Microsoft.Identity.Client.Cache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPinCSharp
{
    public class DiscountCalCulator
    {
        public double Price { get; set; }
        public string Name { get; set; }
        public DiscountCalCulator(string name, double price)
        {
            Price = price;
            Name = name;
        }
        public virtual double calculateDiscount()
        {
            return Price * 0.05;
        }
    }
    public class ElectrinicsCalculator: DiscountCalCulator
    {
        public ElectrinicsCalculator(string name, double price): base(name, price)
        {
            
        }
        public override double calculateDiscount()
        {
            return Price * .10;
        }
    }
    public class Furniturecalculator : DiscountCalCulator
    {
        public Furniturecalculator(string name, double price) : base(name, price)
        {

        }
        public override double calculateDiscount()
        {
            return Price * .15;
        }
    }

    public class Calculators
    {
        public List<DiscountCalCulator> Products { get; set; }
        public Calculators()
        {
            this.Products = new List<DiscountCalCulator>();
        }
        public void SeedData(int size)
        {
            string[] possibleNames = new string[10];
            possibleNames = ["Sugar", "Laptop", "TV Stand", "Bed", "Mobile", "TV", "Mirror", "Mouse"];
            for(int i = 0; i < size; i++)
            {
                this.Products.Add(new DiscountCalCulator(possibleNames[Random.Shared.Next(possibleNames.Length)], i*10));
            }
        }
        public int AddNumbers(int a, int b)
        {
            return a + b;
        }
        public int AddNumbers(int a, int b, int c)
        {
            return a + b + c;
        }
        public double AddNumbers(double a, double b)
        {
            return a + b;
        }
        public static void Main(string[] args)
        {
            DiscountCalCulator calc = new DiscountCalCulator("Sugar", 2000);
            Console.WriteLine(calc.calculateDiscount());
            ElectrinicsCalculator electrinics = new ElectrinicsCalculator("Laptop", 20000);
            Console.WriteLine(electrinics.calculateDiscount());
            Furniturecalculator furn = new Furniturecalculator("Tv Stand", 2000);
            Console.WriteLine(furn.calculateDiscount());

            Calculators calculator = new();
            calculator.SeedData(20); 
            foreach (var product in calculator.Products)
            {
                Console.WriteLine($"{product.Name}, {product.Price}");
            }
            Console.WriteLine("This program demonstrated Polymorphism in C#");

        }
    }
}
