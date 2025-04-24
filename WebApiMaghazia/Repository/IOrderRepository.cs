using WebApiMaghazia.Models;

namespace WebApiMaghazia.Repository
{
    public interface IOrderRepository
    {
        Task BuyProduct(int productId,int userId);
        Task<ICollection<Order>> GetOrdersByUserAsync(int userId);

    }
}
