using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOPinCSharps;

namespace OOPinCSharp
{
    public class GenericProducts<T> where T : class, new()
    {

        public T CreateInstance() {
            return new T();
        }
        
    }
    public class Electronic
    {
        public int ItemId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal Quantity { get; set; }
        public Electronic()
        {
            ItemId = 0;
            Name = "";
            Price = 0;
            Quantity = 0;
        }
    }

    public class Furnitures
    {
        public int ItemId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal Quantity { get; set; }
        public Furnitures()
        {
            ItemId = 0;
            Name = "";
            Price = 0;
            Quantity = 0;
        }
    }

    public class GenericProductsManager<T> where T : class, new()
    {
        public List<T> ItemsList { get; set; }
        public GenericProductsManager() { ItemsList = new List<T>(); }
        public T Addinstance(T instance) { ItemsList.Add(instance); return instance; }
    }
}
