namespace WebApplicationProjetN5.Models.Entities
{
    public class Visitor
    {
        public int Id { get; set; }
       IList<Car> Cars { get; set; }

        public Visitor()
        {
            Cars = [];
        }

    }
}
