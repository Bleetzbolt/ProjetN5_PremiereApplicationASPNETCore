namespace WebApplicationProjetN5.Models.Entities
{
    public class Brand
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IList<CarModel> CarModels { get; set; }

        public Brand()
        {
            CarModels=[];
        }
    }
}
