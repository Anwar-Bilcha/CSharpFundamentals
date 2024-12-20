using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.IdentityModel.Tokens;

namespace OOPinCSharp
{
    public class StockItem
    {
        public int ItemID { get; set; }
        public string ItemName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public StockItem(int itemId, string itemName, int quantity, decimal price)
        {
            ItemID = itemId; ItemName = itemName; Quantity = quantity; Price = price;
        }
        public static List<StockItem> GenerateSeedData(int size)
        {
            string[] itemNames = new string[10];
            itemNames =["Whats", "Can", "Possibly","Be", " a Name"];
            var seed = new List<StockItem>();
            if (size > 0)
            {
                for (int i = 0; i < size; i++)
                {
                    seed.Add( new(i,itemNames[Random.Shared.Next(itemNames.Length)],(int)i / 2, (decimal)i * Random.Shared.Next(itemNames.Length)));
                }
                return seed;
            }
            return new List<StockItem>();
        }
        // Common method to calculate total price for the item in stock
        public decimal GetTotalPrice() { return Quantity * Price; }
        // A method to display stock item details
        public virtual void DisplayDetails()
        {
            Console.WriteLine($"Item ID: {ItemID},   Name: {ItemName},    Quantity: {Quantity},    Price: {Price:C}");
        }
    }
    public class Electronics : StockItem
    {
        public int WarrantyPeriod { get; set; } // Warranty in months

        public Electronics(int itemId, string itemName, int quantity, decimal price, int warrantyPeriod)
            : base(itemId, itemName, quantity, price)
        {
            WarrantyPeriod = warrantyPeriod;
        }
        // Override the DisplayDetails method to include warranty information
        public override void DisplayDetails()
        {
            base.DisplayDetails();
            Console.WriteLine($"    Warranty Period: {WarrantyPeriod} months");
        }

        // Method to apply a discount based on the quantity
        public decimal ApplyDiscount()
        {
            if (Quantity > 50)
            {
                return Price * 0.9M; // 10% discount for bulk purchase
            }
            return Price;
        }
    }
    public class Furniture : StockItem
    {
        public string Material { get; set; } // e.g., Wood, Metal, etc.
        public Furniture(int itemId, string itemName, int quantity, decimal price, string material)
            : base(itemId, itemName, quantity, price)
        {
            Material = material;
        }
        // Override the DisplayDetails method to include material information
        public override void DisplayDetails()
        {
            base.DisplayDetails();
            Console.WriteLine($"     Material: {Material}");
        }

        // Method to add delivery charges for large items
        public decimal CalculateDeliveryCharges()
        {
            if (Quantity > 10)
            {
                return 50.0M; // Large quantity, additional delivery charge
            }
            return 20.0M; // Regular delivery charge
        }
    }
    public class Clothing : StockItem
    {
        public string Size { get; set; }
        public string Color { get; set; }
        public Clothing(int itemId, string itemName, int quantity, decimal price, string size, string color)
            : base(itemId, itemName, quantity, price)
        {
            Size = size; Color = color;
        }
        // Override the DisplayDetails method to include size and color information
        public override void DisplayDetails()
        {
            base.DisplayDetails(); Console.WriteLine($"Size: {Size}, Color: {Color}");
        }
        // Method to apply a seasonal discount
        public decimal ApplySeasonalDiscount()
        {
            if (DateTime.Now.Month == 12) // Example for December
            {
                return Price * 0.85M; // 15% discount in December
            }
            return Price;
        }
    }
    class Calculator
    { public int Add(int a, int b)
        {
            return a + b;
        }
        public double Add(double a, double b)
        {
            return a + b;
        }
        public int Add(int a, int b, int c)
        {
            return a + b + c;
        }
    }
    public class Warehouse
    {
        public int? WarehouseID { get; set; }
        public string? WarehouseLocation { get; set; }

        // Composition: Warehouse "has-a" collection of Products
        public List<StockItem>? StockItems { get; set; }
        public Warehouse(int warehouseId, string warehouseLocation)
        {
            WarehouseID = warehouseId; WarehouseLocation = warehouseLocation;
            StockItems = new List<StockItem>();  // Initialize the product list
        }
        public void AddProduct(StockItem items) { StockItems?.Add(items); }
        public Warehouse()
        {
            
        }
        ~Warehouse() 
        {
            Console.WriteLine("A Ware House object Destroyed");
        }
        public void DisplayWarehouseDetails()
        {
            Console.WriteLine($"Warehouse ID: {WarehouseID}, Location: {WarehouseLocation}");
            Console.WriteLine("Products in Warehouse:");
            foreach (var stockitem in StockItems)
            {
                stockitem.DisplayDetails();
            }
        }
    }
    public static class SecurityHelper
    {
        public static string HashPassword(string password)
        {
            using (var sha256 = System.Security.Cryptography.SHA256.Create())
            {
                var bytes = sha256.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(bytes);
            }
        }
    }
    public class Program
    {
        public static void Maidn(string[] args)
        {
            var electronics = new Electronics(1, "Laptop", 60, 800.00M,34);
            var furniture = new Furniture(2, "Office Chair", 15, 150.00M, "Leather");
            var clothing = new Clothing(3, "T-shirt", 100, 20.00M, "M", "Red");
            if(!DataValidator.isValidQuantity((double)electronics.Price))
            {
                Console.WriteLine($"item {nameof(electronics)} has {Messages.InvalidStockQuantity}");
            }
            else
            {
                Console.WriteLine(Messages.OperationSuccessful);
            }
            Console.WriteLine("Enter Password");
            string inputPassword = Console.ReadLine();
            Console.WriteLine("Your Hashed Password is: "+SecurityHelper.HashPassword(inputPassword.ToString()));
            
            
            //Warehouse warehouse2 = new();
            //warehouse2.StockItems = new List<StockItem>();
            //warehouse2.StockItems.Add(electronics);
            //warehouse2.StockItems.Add(furniture);
            //warehouse2.StockItems.Add(clothing);
            //warehouse2.DisplayWarehouseDetails();
            //warehouse2 = null;
            //var isNullifiedStockItemsProperty = warehouse2?.StockItems == null;
            Console.WriteLine();
            Console.WriteLine();
            //Console.WriteLine($" is StockItems property Nullified? {isNullifiedStockItemsProperty}");

            var SeedStockItems = StockItem.GenerateSeedData(100);
            var seedStockItemsHavingMorethanTenQuantity = from seedStockItem in SeedStockItems
                                                          where seedStockItem.Quantity >20
                                                          orderby seedStockItem.Quantity
                                                          select seedStockItem;
            foreach(var item in seedStockItemsHavingMorethanTenQuantity )
            {   
                if(AppConfig.isOrderInRange(item.Quantity, 1) || item.Quantity>AppConfig.MinStockQuantity)
                {
                    item.DisplayDetails();
                }
               
            }
            //SudoGame game = new();
            //Console.WriteLine(game.PlayGame("Anwar"));

            // Display details and calculate totals
            electronics.DisplayDetails();
            Console.WriteLine($"Total Price: {electronics.GetTotalPrice():C}");
            Console.WriteLine($"Price after Discount: {electronics.ApplyDiscount():C}\n");

            furniture.DisplayDetails();
            Console.WriteLine($"Total Price: {furniture.GetTotalPrice():C}");
            Console.WriteLine($"Delivery Charges: {furniture.CalculateDeliveryCharges():C}\n");

            clothing.DisplayDetails();
            Console.WriteLine($"Total Price: {clothing.GetTotalPrice():C}");
            Console.WriteLine($"Price after Seasonal Discount: {clothing.ApplySeasonalDiscount():C}\n");

            Warehouse warehouse1 = new Warehouse(12, "Merkato") { StockItems = new List<StockItem>() };

            warehouse1.StockItems.Add(new Electronics(123, "Laptop", 23, 2300, 2));
            warehouse1.StockItems.Add(new Furniture(123, "TV Stand", 23, 2300, "Wood"));
            warehouse1.StockItems.Add(new Clothing(123, "BED", 23, 15000, "1.8 Metre", "Coca-Color"));
            warehouse1.StockItems.Add(new Electronics(123, "TV", 23, 2200, 22));
            warehouse1.StockItems.Add(electronics);
            Console.WriteLine("Printing Stock-Items in a Warehouse");
            warehouse1.DisplayWarehouseDetails();
            //warehouse1 = null;
            //var isNullfiedStockItems = warehouse1?.StockItems == null;
            //Console.WriteLine("Is Null? " + isNullfiedStockItems);

            var electronicsItems = from stockitem in warehouse1.StockItems 
                                   where stockitem.GetType().Name == "Electronics"
                                   orderby stockitem.ItemID descending
                                   select stockitem;
            foreach (var item in electronicsItems)
            {
                Console.WriteLine("Printing Details ....");
                item.DisplayDetails();
            }


            //Calculator calculator = new Calculator();
            //Console.WriteLine(calculator.Add(23, 54));
            //Console.WriteLine(calculator.Add(23,24,65));
            //Console.WriteLine(calculator.Add(23.7, 54.6));


        }
    }
    }
