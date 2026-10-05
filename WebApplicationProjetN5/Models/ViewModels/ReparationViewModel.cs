using System.ComponentModel.DataAnnotations;

namespace WebApplicationProjetN5.Models.ViewModels
{
    public class ReparationViewModel
    {
        public int Id { get; set; }
              
        [Required(ErrorMessage = "La description de la réparation est requise.")]
        public string Description { get; set; }

    }
}
