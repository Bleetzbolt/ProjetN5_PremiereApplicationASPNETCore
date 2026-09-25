namespace WebApplicationProjetN5.Models.Entities
{
    public class CarModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int BrandId { get; set; }
        public Brand Brand { get; set; }
        public int CarfinishId { get; set; }
        public CarFinish CarFinish { get; set; }
        public IList<Car> Cars { get; set; }
        public CarModel()
        {
            Cars = [];
        }
    }
}
