namespace WebApplicationProjetN5.Models.Entities
{
    public class Car
    {
        public int Id { get; set; }
        public bool Availability { get; set; }
        public string Photo { get; set; }
        public string Message { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal SellingPrice { get; set; }
        public decimal ReparationCost { get; set; }
        public DateOnly AvailableSaleDate { get; set; }
        public DateOnly SaleDate { get; set; }
        public DateOnly PurchaseDate { get; set; }
        public int ReleasedYear { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int CarModelId { get; set; }
        public CarModel CarModel { get; set; }  

        public IList<Reparation> Reparations { get; set; }
        public IList<Visitor> Visitors { get; set; }

        public Car()
        {
            Reparations = [];
            Visitors = [];

        }


    }
}
