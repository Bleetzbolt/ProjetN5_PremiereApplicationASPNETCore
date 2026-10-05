namespace WebApplicationProjetN5.Models.Entities
{
    public class CarFinish
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<CarModel> CarModels { get; set; }

        public IList<Car> Cars { get; set; }
        public CarFinish()
        {
            CarModels = [];
            Cars = [];
        }


    }
}
