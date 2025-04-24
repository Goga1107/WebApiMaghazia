using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebApiMaghazia.Repository;

namespace WebApiMaghazia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;

        public OrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        
        [HttpPost("Buy")]

        public async Task<IActionResult> BuyProduct(int productId)
        {
            var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == "UserId");
          int id = int.Parse(userIdClaim.Value);
            await _orderRepository.BuyProduct(productId,id);
            return Ok("Product purchased successfully");
        }

        [Authorize(Roles ="admin")]
        [HttpGet("GetUserOrders")]
        public async Task<IActionResult> GetUserOrders()
        {
            var userIdClaim = User.Claims.FirstOrDefault(c=> c.Type == "UserId");
            int id = int.Parse(userIdClaim.Value);
           return Ok(await _orderRepository.GetOrdersByUserAsync(id));

        }
            
    }
}
