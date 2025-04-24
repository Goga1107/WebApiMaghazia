namespace WebApiMaghazia.Models
{
    public class Order
    {
        public int Id { get; set; }

        public DateTime OrderDate { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int UserId { get;set; }

        public User User { get; set; }


    }
}
