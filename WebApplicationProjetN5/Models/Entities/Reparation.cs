namespace WebApplicationProjetN5.Models.Entities
{
    public class Reparation
    {
        public int Id { get; set; }
        public string? Description { get; set; }

        public IList<Car> Cars { get; set; }

        public Reparation()
        {
            Cars = [];
        }


    }
}
