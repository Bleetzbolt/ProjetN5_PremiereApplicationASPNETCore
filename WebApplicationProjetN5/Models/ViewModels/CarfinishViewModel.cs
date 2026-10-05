using System.ComponentModel.DataAnnotations;

namespace WebApplicationProjetN5.Models.ViewModels
{
    public class CarFinishViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Le nom de la finition de voiture est requis.")]
        public string Name { get; set; }

        public int CarModelId { get; set; }
    }
}
