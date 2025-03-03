// Services/ProductService.cs
using WebApi.Extensions;
using WebApi.Models;

namespace WebApi.Services
{
    public interface IProductService
    {
        Task<List<Product>> GetProductsAsync(string searchTerm, int page, int pageSize);
    }

    public class ProductService : IProductService
    {
        private readonly DbContext _context; // Replace with your actual DbContext

        public ProductService(DbContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> GetProductsAsync(string searchTerm, int page, int pageSize)
        {
            var query = _context.Set<Product>().AsQueryable();

            // Apply extension methods
            query = query.FilterBySearchTerm(searchTerm, p => p.Name);
            query = query.Paginate(page, pageSize);

            // Format category using string extension
            var products = await query.ToListAsync();
            products.ForEach(p => p.Category = p.Category.ToTitleCase());

            return products;
        }
    }
}
