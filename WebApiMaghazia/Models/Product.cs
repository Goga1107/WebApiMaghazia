using System.Text.Json.Serialization;

namespace WebApiMaghazia.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime ReleaseDate { get; set; }

        public int Price { get; set; }

        public int CategoryId { get; set; }
        
        public Category Category { get; set; }

    }
}
