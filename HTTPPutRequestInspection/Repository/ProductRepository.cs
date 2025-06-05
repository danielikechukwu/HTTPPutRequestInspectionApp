using HTTPPutRequestInspection.Models;

namespace HTTPPutRequestInspection.Repository
{
    public class ProductRepository
    {
        public List<Product> Products = new List<Product>()
        {
            new Product() { Id = 1, Name= "Laptop", Price = 1000, Quantity = 10 },
            new Product() { Id = 2, Name= "Desktop", Price = 2000, Quantity = 20 }

        };

        public async Task<Product> UpdateProduct(Product product)
        {
            //Set the Product Id
            var existingProduct = Products.FirstOrDefault(u => u.Id == product.Id);

            if (existingProduct != null)
            {
                existingProduct.Price = product.Price;
                existingProduct.Quantity = product.Quantity;
                existingProduct.Name = product.Name;
            }

            await Task.Delay(TimeSpan.FromSeconds(3));

            return existingProduct!;

        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            var products = Products.ToList();

            await Task.Delay(TimeSpan.FromSeconds(3));

            return products;
        }
    }
}
