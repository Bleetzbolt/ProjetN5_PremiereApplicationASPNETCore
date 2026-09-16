namespace WebApplicationProjetN5.Models.Entities
{
    public class CarModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int BrandId { get; set; }
        public Brand Brand { get; set; }

        public IList<CarVersion> CarVersions { get; set; }
        
        public CarModel() 
        {
            CarVersions = [];
        }
    }
}
