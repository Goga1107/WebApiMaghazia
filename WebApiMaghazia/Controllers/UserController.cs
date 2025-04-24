using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiMaghazia.Dtos;
using WebApiMaghazia.Repository;

namespace WebApiMaghazia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterDto register)
        {
          await _userRepository.Register(register.Name,register.Password,register.Role,register.Email);
            return Ok(new {Message = "User registered successfully"});

        }

        [HttpPost("Login")]
        public  IActionResult Login(LoginDto login)
        {
            var token =  _userRepository.Login(login.Name, login.Password);
            return Ok(new { Token = token,User = login.Name });
        }


    }
}
