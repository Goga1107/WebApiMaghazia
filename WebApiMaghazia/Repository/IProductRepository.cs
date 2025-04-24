using WebApiMaghazia.Models;

namespace WebApiMaghazia.Repository
{
    public interface IProductRepository
    {
        Task AddProduct(Product product);

        Task AddCategory(Category category);
        Task UpdateProduct(int id,Product newProduct);

        Task DeleteProduct(int id);

        Task<Product> GetProductById(int id);

        Task<ICollection<Product>> GetAll();

        Task<ICollection<Product>> GetProductsWCategory();
    }
}
