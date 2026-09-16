namespace WebApplicationProjetN5.Models.Entities
{
    public class Announce
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Photo {  get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
        
        public int CarId { get; set; }
        public Car Car { get; set; }

        public IList<Visitor> Visitors { get; set; }
        public Announce()
        {
            
            Visitors = [];

        }

    }
}
