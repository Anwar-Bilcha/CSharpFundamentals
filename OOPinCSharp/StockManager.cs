using System;
using System.Collections.Generic;

namespace OOPinCSharp
{
    // Represents a Product in the stock
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }

        public Product(int id, string name, int qty)
        {
            ProductId = id;
            ProductName = name;
            Quantity = qty;
        }

        public string DisplayDetail()
        {
            return $"ID: {ProductId}, Name: {ProductName}, Quantity: {Quantity}";
        }
    }

    // Stock Management Class
    public class StockManager
    {
        private List<Product> products = new List<Product>();

        // Method Overloading for Adding Stock
        public void AddStock(int productId, string productName, int quantity)
        {
            products.Add(new Product(productId, productName, quantity));
            Console.WriteLine("Product added with ID and Name.");
        }
        
        public void AddStock(Product product)
        {
            products.Add(product);
            Console.WriteLine("Product added using Product object.");
        }

        // Method Overloading for Searching Stock
        public Product? SearchStock(int productId)
        {
            return products.Find(p => p.ProductId == productId);
        }

        public Product? SearchStock(string productName)
        {
            return products.Find(p => p.ProductName.Equals(productName, StringComparison.OrdinalIgnoreCase));
        }

        // Display All Products
        public void DisplayStock()
        {
            foreach (var product in this.products)
            {
                Console.WriteLine($" ID: {product.ProductId}   Name: {product.ProductName}   Quantity:  {product.Quantity}");
            }
        }
    }

    // Program Execution
    class ExecutionClass
    {
        static void Mainq(string[] args)
        {
            StockManager stockManager = new StockManager();
            Product product3 = new Product(2, "Mobile Phone", 15);
            // Adding stock using different overloaded methods
            stockManager.AddStock(1, "Laptop", 10); // Product Added using name and ID
            stockManager.AddStock(product3); // Products added using Object

            // Searching stock using different inputs
            Product? productById = stockManager.SearchStock(3);
            Product? productByName = stockManager.SearchStock("Mobile Phone");
            Product? productById2 = stockManager.SearchStock(1);


            Console.WriteLine("\n--- Search Results ---");
            Console.WriteLine(productById != null ? productById.DisplayDetail() : "Product not found."); // Product Not found
            Console.WriteLine(productById2 != null ? productById2.DisplayDetail() : "Product not found."); // Product with Id 1
            Console.WriteLine(productByName != null ? productByName.DisplayDetail() : "Product not found."); // Mobile 


            
            // Display all stock
            Console.WriteLine("\n--- All Stock ---");
            stockManager.DisplayStock();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var evenNumbers = from num in numbers
                              where num % 2 == 0
                              orderby num
                              select num;
            foreach (var number in evenNumbers)
            {
                Console.WriteLine(number); // Outputs: 2, 4, 6, 8, 10 }
            }
            
        }
    }
}
