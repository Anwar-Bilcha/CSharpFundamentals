using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPinCSharp
{
    public class GenericPrimitive<T>
    {
        public T? data { get; set; }
        public GenericPrimitive() {}
        public T SetData(T value) {
            data = value;
            return data;
        }
        public T? GetData() {
            return data;
        }
    }
    public class GenericManager
    {
        public static void Main(string[] args)
        {
            //GenericProductsManager<Electronic> genericManager = new GenericProductsManager<Electronic>();
            //Electronic electronicItem = new Electronic();
            //electronicItem.ItemId = 2; electronicItem.Name = "Car"; electronicItem.Price = 200;
            //electronicItem.Quantity = 100; 
            //genericManager.ItemsList.Add(electronicItem);
            //genericManager.Addinstance(electronicItem);
            //foreach (var item in genericManager.ItemsList)
            //{
            //    Console.WriteLine($"{item.Name} ,   {item.ItemId}    , {item.Quantity}    , {item.Price}");
            //}
            Furnitures furnitureItem = new Furnitures();
            furnitureItem.ItemId = 12; furnitureItem.Name = "Master Bed ";
            furnitureItem.Price = 200; furnitureItem.Quantity = 100;
            List<Furnitures> furnitureList = new List<Furnitures>();
            furnitureList.Add(furnitureItem);
            GenericProductsManager<Furnitures> furnitureManager = new GenericProductsManager<Furnitures>();
            furnitureManager.Addinstance(furnitureItem);
            foreach (var item in furnitureManager.ItemsList)
            {
                Console.WriteLine($"{item.Name} ,   {item.ItemId}    , {item.Quantity}    , {item.Price}");
            }
            //GenericPrimitive<int> ints = new();
            //ints.SetData(123);
            //Console.WriteLine(ints.GetData());
            //GenericPrimitive<string> names = new();
            //List<string> namesgeneric = new List<string>();
            //string? abebe = names.SetData("Abebe");
            //namesgeneric.Add(abebe);
            // namesgeneric.Add(names.SetData("Kedir"));
            //namesgeneric.Add(names.SetData("Senayt"));
            //foreach(var name in namesgeneric)
            //{
            //    Console.WriteLine(name);
            //}
            //Console.WriteLine("Finally "+names.GetData());


        }
    }
}
