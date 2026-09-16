namespace WebApplicationProjetN5.Models.Entities
{
    public class Car
    {
        public int Id { get; set; }
        public bool Availability { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int InventoryId { get; set; }
        public Inventory Inventory { get; set; }

        public int CarVersionId { get; set; }
        public CarVersion CarVersion { get; set; }

        public IList<Reparation> Reparations { get; set; }

       public Car()
        {
            Reparations = [];
        }


    }
}
