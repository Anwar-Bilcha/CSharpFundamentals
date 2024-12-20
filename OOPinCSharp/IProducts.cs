using OOPinCSharps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPinCSharp
{
    public interface IProducts
    {
        public Product AddProduct(Product product);
        public Product UpdateProduct(Product product);  
        public Product DeleteProduct(Product product);
        public List<Product> GetProducts();
        public Product GetProductById(int id);
    }
}
