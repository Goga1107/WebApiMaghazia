using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiMaghazia.Dtos;
using WebApiMaghazia.Models;
using WebApiMaghazia.Repository;

namespace WebApiMaghazia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _repository;
        private readonly IEmailSender _emailSender;
        public ProductController(IProductRepository repository, IEmailSender emailSender)
        {
            _repository = repository;
            _emailSender = emailSender;

        }

        [Authorize(Roles = "admin")]
        [HttpPost("AddProduct")]

        public IActionResult AddProduct(Product product)
        {
            _repository.AddProduct(product);
            return Ok("Product Added successfully");
        }

        [Authorize(Roles = "admin")]
        [HttpPost("AddCategory")]

        public async Task<IActionResult> AddCategory([FromBody]Category category)
        {
           await _repository.AddCategory(category);
            return Ok(new { Message = "Category Added successfully" });
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll() 
        { 
        var all = await _repository.GetAll();
            return Ok(all);
        
        }
        [HttpGet("GetWCategory")]
        public async Task<IActionResult> GetWCategory()
        {
            var all = await _repository.GetProductsWCategory();
            return Ok(all);

        }

        [HttpPost("GaagzavneEmailze")]
        public async Task<IActionResult> EmailSender(string email,string message)
        {
           await _emailSender.SendOTPEmailAsync(email, message);
            return Ok("warmatebit gaigzavna");
        }
        [Authorize(Roles = "admin")]
        [HttpDelete("Remove")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
              await _repository.DeleteProduct(id);
            return Ok(new { Message = "removed  successfully" });
        }
        [Authorize(Roles ="admin")]
        [HttpPut("Update")]
        public async Task<IActionResult> EditProduct(int id,Product newProd)
        {
           await _repository.UpdateProduct(id, newProd);
            return Ok(new { Message = "Updated  successfully" });
        }


    }
}
