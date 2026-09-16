namespace WebApplicationProjetN5.Models.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
       
        public int RoleId { get; set; }
        public Role Role { get; set; }

        public IList<Announce>Announces {  get; set; }

        public IList<Car> Cars { get; set; }

        public User()
        {
            Announces = [];
            Cars = [];
        }

    }
}
