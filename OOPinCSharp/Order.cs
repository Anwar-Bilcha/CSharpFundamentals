using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPinCSharps
{
       
     public partial class Person
    { public int Age { get; set; } 
        public void PrintAge()
        { Console.WriteLine($"Age: {Age}"); 
        }
    } 
    public class BaseClass
    {
        public virtual void VirtualMethod()
        {
            Console.WriteLine("BaseClass implementation.");
        }
    }
    public class DerivedClass : BaseClass
    {
        public override void VirtualMethod()
        {
            Console.WriteLine("DerivedClass implementation.");
        }
    }
    public class FurtherDerivedClass : DerivedClass
    {
         public override void VirtualMethod()
        {
            Console.WriteLine("FurtherDerivedClass implementation.");
        }
    }

    public class Order
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public string Description { get; set; }
        public Order()
        {
           Id = 1234;
            Name = "Known";
        }
    }
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public Product(int productId, string name, string description, decimal price, int quantity)
        {
            ProductId = productId;
            Name = name;
            Description = description;
            Price = price;
            Quantity = quantity;
        }
        public void Restock(int quantity) { Quantity += quantity; }
        public void DeductStock(int quantity)
        {
            if (quantity <= Quantity) { Quantity -= quantity; }
            else { throw new InvalidOperationException("Not enough stock to deduct"); }
        }
    }

}
