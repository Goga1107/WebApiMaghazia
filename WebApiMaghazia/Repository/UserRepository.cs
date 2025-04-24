using Microsoft.Extensions.ObjectPool;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebApiMaghazia.Data;
using WebApiMaghazia.Models;

namespace WebApiMaghazia.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly MaghaziaDbContext _context;
        private const string SecretKey = "GogaSecretKey1234567891011121314151612"; 
        private const string Issuer = "GogaApi";
        public UserRepository(MaghaziaDbContext context)
        {
            _context = context;
        }

        public static string GenerateToken(string username, string role, User user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecretKey));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
            new Claim(ClaimTypes.Name, username),
            new Claim(ClaimTypes.Role, role),
            new Claim("UserId", user.Id.ToString())
        };

            var token = new JwtSecurityToken(
                issuer: Issuer,
                audience: Issuer,
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        public string Login(string userName, string password)
        {
            var user =  _context.Users.FirstOrDefault(u => u.Name == userName && u.Password == password);
            if (user == null) throw new Exception("Invalid username or password");

            var token =  GenerateToken(user.Name, user.Role,user);
            return  token;
        }

        public async Task Register(string name, string password, string role,string email)
        {
            User user = new User
            {
                Name = name,
                Email =email,
                Password = password,
                Role = role
            };
           await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }
    }
}
