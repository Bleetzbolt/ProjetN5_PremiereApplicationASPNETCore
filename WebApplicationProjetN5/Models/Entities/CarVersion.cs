namespace WebApplicationProjetN5.Models.Entities
{
    public class CarVersion
    {
        public int Id { get; set; }
        public int ReleasedYear { get; set; }
        public string CarFinish { get; set; }

        public int CarModelId { get; set; }

        public CarModel CarModel { get; set; }
        
        public IList<Car> Cars { get; set; }

        public CarVersion()
        {
            Cars = [];
        }


    }
}
