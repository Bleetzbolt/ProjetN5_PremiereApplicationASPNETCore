namespace WebApplicationProjetN5.Models.Entities
{
    public class FinancialComponent
    {

        public int Id { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal ReparationCost { get; set; }
        public decimal SellingPrice { get; set; }

        public int CarId { get; set; }
        public Car Car { get; set; }



    }
}
