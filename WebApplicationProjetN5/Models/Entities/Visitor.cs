namespace WebApplicationProjetN5.Models.Entities
{
    public class Visitor
    {
        public int Id { get; set; }
        public IList<Announce>Announces {  get; set; }

        public Visitor()
        {
            Announces = [];
        }

    }
}
