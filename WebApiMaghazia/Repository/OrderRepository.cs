using Microsoft.EntityFrameworkCore;
using WebApiMaghazia.Data;
using WebApiMaghazia.Models;

namespace WebApiMaghazia.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly MaghaziaDbContext _context;
        private readonly HttpContext _httpContext;
        public OrderRepository(MaghaziaDbContext context)
        {
            _context = context;
            

        }

        public async Task BuyProduct(int productId,int userId)
        {

         

           
            var prod = await  _context.Products.FirstOrDefaultAsync(p => p.Id == productId);
            
            if(prod == null)
            {
                throw new Exception("Product doesnot exsists");
            }

            Order order = new Order
            {
                ProductId = productId,
                UserId = userId,
                OrderDate = DateTime.Now,





            };
           await _context.Orders.AddAsync(order);
           await _context.SaveChangesAsync();
        }

        public  async Task<ICollection<Order>> GetOrdersByUserAsync(int userId)
        {
            return  await _context.Orders.Where(u => u.UserId == userId).Include(p => p.Product).ToListAsync();
        }
    }
}
