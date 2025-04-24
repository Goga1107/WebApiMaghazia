using Microsoft.EntityFrameworkCore;
using WebApiMaghazia.Data;
using WebApiMaghazia.Models;

namespace WebApiMaghazia.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly MaghaziaDbContext _context;
        public ProductRepository(MaghaziaDbContext context)
        {
            _context = context;
        }

        public async Task AddCategory(Category category)
        {
           await _context.Categories.AddAsync(category);
           await _context.SaveChangesAsync();
        }

        public async Task AddProduct(Product product)
        {
           await _context.Products.AddAsync(product);
           await _context.SaveChangesAsync();
        }

        public async Task DeleteProduct(int id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p=> p.Id == id);
            if (product != null)
            {
                _context.Products.Remove(product);
               await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("product not found");
            }
        }

        public async Task<ICollection<Product>> GetAll()
        {
            var products = await _context.Products.ToListAsync();
            return  products;
        }

        public async Task<Product> GetProductById(int id)
        {
           var prod = await _context.Products.FirstOrDefaultAsync(p=> p.Id == id);
            if (prod != null)
            return prod;
            else
            {
                throw new Exception("product not found");
            }
        }

        public async Task<ICollection<Product>> GetProductsWCategory()
        {
            var prodWCategory = await _context.Products.Include(c=> c.Category).ToListAsync();
            if(prodWCategory != null)
            {
                return prodWCategory;
            }
            else
            {
                throw new Exception("not found products with category");
            }
        }

        public async Task UpdateProduct(int id, Product newProduct)
        {
            var prod = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
            if(prod != null)
            {
                prod.Name = newProduct.Name;
                prod.Price = newProduct.Price;
                prod.Category = newProduct.Category;
                prod.ReleaseDate = newProduct.ReleaseDate;
               await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("product not found to update");
            }
        }
    }
}
