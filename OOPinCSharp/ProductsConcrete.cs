using OOPinCSharps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace OOPinCSharp
{
    public class ProductsConcrete : IProducts
    {
        public List<Product> Products { get; set; }
        public ProductsConcrete()
        {
           this.Products = new List<Product>();
        }
        Product IProducts.AddProduct(Product product)
        {
            Products.Add(product);
            return product;
        }
        Product IProducts.DeleteProduct(Product product)
        {
            Products.Remove(product);
            return product;
        }
        OOPinCSharp.Product? IProducts.GetProductById(int id)
        {
            OOPinCSharp.Product? result = new OOPinCSharp.Product(1,"",0);
            result = Products.FirstOrDefault(x => x.ProductId == id);
            return result;  
        }

        List<Product> IProducts.GetProducts()
        {
            return Products;
        }
        Product IProducts.UpdateProduct(Product product)
        {
            Product? productToUpdate = Products.FirstOrDefault(x => x.ProductId == product.ProductId);
            productToUpdate.ProductId = product.ProductId;
            //productToUpdate.Name = product.Name;
            //productToUpdate.Description = product.Description;
            //productToUpdate.Price = product.Price;
            productToUpdate.Quantity = product.Quantity;
            int productToUpdateIndex = Products.IndexOf(productToUpdate);
            Products.Insert(productToUpdateIndex, productToUpdate);
            return productToUpdate;
        }
    }
}
