namespace WebApplicationProjetN5.Models.Entities
{
    public class Inventory
    {
        public int Id { get; set; }
        public IList<Car> Cars { get; set; }
       
        
        public Inventory()
        {
            Cars = [];
        }




    }
}
