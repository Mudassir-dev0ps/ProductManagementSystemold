using ProductService.Models;
using System.Collections.Generic;
using System.Linq;


namespace ProductService.Repository
{
    public class ProductRepository
    {
        private static readonly List<Product> Products = new();
        private static int _idCounter = 1;

        public List<Product> GetAll() => Products;

        public Product? GetById(int id) => Products.FirstOrDefault(p => p.Id == id);

        public Product Add(Product product)
        {
            product.Id = _idCounter++;
            Products.Add(product);
            Console.WriteLine(product.Name);
            return product;
        }

        public bool Update(Product updated)
        {
            var existing = GetById(updated.Id);
            if (existing == null) return false;

            existing.Name = updated.Name;
            existing.Price = updated.Price;
            return true;
        }

        public bool Delete(int id)
        {
            var product = GetById(id);
            if (product == null) return false;

            Products.Remove(product);
            return true;
        }
    }
}
