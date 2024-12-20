using Microsoft.Extensions.DependencyInjection;
using OOPinCSharps;
using StockManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace OOPinCSharp
{
    public interface IProducts
    {
        public Product AddProduct(Product product);
        public Product UpdateProduct(Product product);  
        public Product? DeleteProduct(Product product);
        public List<Product> GetProducts();
        public Product GetProductById(int id);
            
    }
    public class ProductImplementation : IProducts
    {
        public List<Product> Products { get; set; }
        public ProductImplementation()
        {
            Products = new List<Product>();
        }
        public Product AddProduct(Product product)
        {
            Products.Add(product);
            return product;
        }
        public Product UpdateProduct(Product product)
        {
            var productToUpdate = Products.FirstOrDefault(a => a.ProductId == product.ProductId);
            if (productToUpdate != null)
            {
                productToUpdate.ProductId = product.ProductId;
                productToUpdate.ProductName = product.ProductName;
                productToUpdate.Quantity = product.Quantity;
                var index = Products.IndexOf(productToUpdate);
               //Products.Insert(index, productToUpdate);
                return productToUpdate;
            }
            return new Product(0,"",1);
        }
        public Product GetProductById(int id)
        {
            var productSearched = Products.FirstOrDefault(a => a.ProductId == id);
            return productSearched != null ? productSearched : new Product(0, "", 1);
        }
        public Product? DeleteProduct(Product productToDelet)
        {
            Product? productToDelete = Products.FirstOrDefault(a=>a.ProductId==productToDelet.ProductId);
            if(productToDelete != null)
            {
                Products.Remove(productToDelete);

            }
            return productToDelete;
        }
        public List<Product> GetProducts()
        {
            return Products.ToList();
        }
        public static void zMain()
        {
            Product product1 = new Product(1, "Computer", 25);
            Product product2 = new Product(2, "TV Stand", 35);
            Product product3 = new Product(3, "Furniture", 250);


            ProductImplementation implementation = new ProductImplementation();
            implementation.AddProduct(product1);
            implementation.AddProduct(product2);
            implementation.AddProduct(product3);


           var Item3 = implementation.GetProductById(3);
            Console.WriteLine($"{Item3.ProductId}   {Item3.ProductName} {Item3.Quantity} is obtained");
            product3.Quantity = 300;
            implementation.UpdateProduct(product3);
            foreach( Product productItem in implementation.Products)
            {
                Console.WriteLine($"Id:   {productItem.ProductId}    Name: {productItem.ProductName}    Quantity: {productItem.Quantity}");
            }
           
        }
    }
}

