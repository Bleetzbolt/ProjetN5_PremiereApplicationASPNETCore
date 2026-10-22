using System.ComponentModel.DataAnnotations;

namespace WebApplicationProjetN5.Models.Entities
{
    public class Car
    {
        public int Id { get; set; }
        public bool Availability { get; set; }
        [Required(ErrorMessage = "L'ajout d'une photo est obligatoire")]
        public string Photo { get; set; }
        public string? Message { get; set; }


        [Required(ErrorMessage = "Le prix d'achat est obligatoire.")]
        [Range(0.01, double.MaxValue,ErrorMessage = "Le prix doit être supérieur à zéro.")]
        public decimal PurchasePrice { get; set; }
        public decimal SellingPrice { get; set; }
        public DateOnly AvailableSaleDate { get; set; }
        public DateOnly SaleDate { get; set; }
        public DateOnly PurchaseDate { get; set; }

        [Required(ErrorMessage = "L'année de sortie de la voiture est obligatoire.")]
        [Range(1990, int.MaxValue, ErrorMessage = "l'année doit être supérieur à 1990")]
        public int? ReleasedYear { get; set; }
        public int CarModelId { get; set; }
        public CarModel CarModel { get; set; }
        public int CarFinishId { get; set; }
        public CarFinish CarFinish { get; set; }
        public IList<Reparation> Reparations { get; set; }
        public Car()
        {
            Reparations = [];
        }
    }
}
