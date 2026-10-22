namespace WebApplicationProjetN5.Models.Entities
{
    public class Reparation
    {
        public int Id { get; set; }
        public string? Description { get; set; }

        public decimal Cost { get; set; }

        public int CarId { get; set; }

        public Car Car { get; set; } = null!;

    }
}
