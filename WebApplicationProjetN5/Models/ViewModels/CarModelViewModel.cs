using System.ComponentModel.DataAnnotations;
using WebApplicationProjetN5.Models.Entities;

namespace WebApplicationProjetN5.Models.ViewModels
{
    public class CarModelViewModel
    {
      
        public CarModel CarModel { get; set; } = new();

        public Brand Brand { get; set; } = new();

        public int BrandId { get; set; }

        public int CarFinishId { get; set; }
        public string CarFinishName { get; set; }

        

    }
}
