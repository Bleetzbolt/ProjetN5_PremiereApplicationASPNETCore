using System.ComponentModel.DataAnnotations;
namespace WebApplicationProjetN5.Models.Entities
{
    public class CarFinish
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Le nom de la finition est obligatoire.")]
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
