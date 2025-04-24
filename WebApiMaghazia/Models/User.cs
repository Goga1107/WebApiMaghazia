using System.Text.Json.Serialization;

namespace WebApiMaghazia.Models
{
    public class User
    {
        public int Id { get; set; }

        
        public string Name { get; set; }

        public string Role { get; set; }
        public string Email { get; set; }

        public string Password { get; set; }


        [JsonIgnore]
        public ICollection<Order> orders { get; set; }
    }
}
