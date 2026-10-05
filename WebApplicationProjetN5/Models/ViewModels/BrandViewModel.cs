using System.ComponentModel.DataAnnotations;

namespace WebApplicationProjetN5.Models.ViewModels
{
    public class BrandViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Le nom de la marque est requis.")]
        public string Name { get; set; }
    }
}
