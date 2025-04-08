using MongoDB.Driver;
using ProductCatalog.Models;

namespace ProductCatalogService.Controllers
{

    public class ProductService
    {
        private readonly IMongoCollection<Product> _products;

        public ProductService(IMongoDatabase database)
        {
            _products = database.GetCollection<Product>("products");
        }

        public async Task<List<Product>> GetAllProductsAsync()
        {
            return await _products.Find(_ => true).ToListAsync();
        }

        public async Task<Product> GetProductByIdAsync(string id)
        {
            return await _products.Find(p => p.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Product> CreateProductAsync(Product product)
        {
            await _products.InsertOneAsync(product);
            return product;
        }

        public async Task UpdateProductAsync(string id, Product product)
        {
            await _products.ReplaceOneAsync(p => p.Id == id, product);
        }

        public async Task DeleteProductAsync(string id)
        {
            await _products.DeleteOneAsync(p => p.Id == id);
        }
    }
}


