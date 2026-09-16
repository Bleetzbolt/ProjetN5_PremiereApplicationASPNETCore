namespace WebApplicationProjetN5.Models.Entities
{
    public class DateComponent
    {
        public int Id { get; set; }
        public DateOnly SaleAvailableDate { get; set; }
        public DateOnly SaleDate { get; set;}
        public DateOnly PurchaseDate { get; set; }

        public int CarId { get; set; }
        public Car Car { get; set; }

    }
}
