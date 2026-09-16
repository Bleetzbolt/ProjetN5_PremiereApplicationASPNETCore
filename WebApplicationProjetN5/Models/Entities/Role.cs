namespace WebApplicationProjetN5.Models.Entities
{
    public class Role
    {
        public int Id { get; set; }
        public string Libelle { get; set; }

        public IList<User> Users { get; set; }

        public Role()
        {
            Users = [];
        }
    }
}
