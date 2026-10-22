using System.ComponentModel.DataAnnotations;

namespace WebApplicationProjetN5.Models.Entities
{
    public class CarModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Le nom du modèle est obligatoire.")]
        public string Name { get; set; }

        public int BrandId { get; set; }
        public Brand Brand { get; set; }

        public IList<CarFinish>CarFinishes { get; set; }

        public CarModel()
        {
            CarFinishes = [];
        }
    }
}
