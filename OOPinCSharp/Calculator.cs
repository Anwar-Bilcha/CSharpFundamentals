using Microsoft.Identity.Client.Cache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPinCSharp
{
    public static class Messages
    {
        public const string StockNotFound = "Stock item not found.";
        public const string InvalidStockQuantity = "Invalid stock quantity.";
        public const string OperationSuccessful = "Operation completed successfully.";
    }
    public static class AppConfig
    {
        public const string ConnectionString = "Server=myServer;Database=StockDB;Trusted_Connection=True;";
        public const decimal MaxDiscountRate = 0.25m; // 25%
        public const decimal MinDiscountRate = 0.05m; // 5%
        public const decimal MinStockQuantity = 25;
         static AppConfig()
        {
            
        }
        public static bool isOrderInRange(int stockQuantity, int orderQuantity)
        {
            return stockQuantity - orderQuantity >= AppConfig.MinStockQuantity;
        }
        public static bool isDiscountInRange(decimal discountRate)
        {
            return discountRate >= MinDiscountRate && discountRate <= MaxDiscountRate;
        }
    }
    public static class DataValidator
    {
        public static bool isValidQuantity(double quantity)
        {
            return quantity>=0;
        }
        public static bool isValidPrice(double price)
        {
            return price >= 0;
        }
    }
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
            //DiscountCalCulator calc = new DiscountCalCulator("Sugar", 2000);
            //Console.WriteLine(calc.calculateDiscount());
            //ElectrinicsCalculator electrinics = new ElectrinicsCalculator("Laptop", 20000);
            //Console.WriteLine(electrinics.calculateDiscount());
            //Furniturecalculator furn = new Furniturecalculator("Tv Stand", 2000);
            //Console.WriteLine(furn.calculateDiscount());

            Calculators calculator = new();
            calculator.SeedData(20);
            calculator.Products[11].Price = -10;
            foreach (var product in calculator.Products)
            {
                if(DataValidator.isValidPrice(product.Price))
                {
                    Console.WriteLine($"{product.Name}, {product.Price}");
                }
            }


            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine($"{calculator.Products[11].Price}   {calculator.Products[11].Name}");

            Console.WriteLine("This program demonstrated Polymorphism in C#");

        }
    }
}
