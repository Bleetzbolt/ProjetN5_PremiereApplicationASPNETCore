using System.ComponentModel.DataAnnotations;
using WebApplicationProjetN5.Models.Entities;

namespace WebApplicationProjetN5.Models.ViewModels
{
    public class CarViewModel
    {
        public Car Car { get; set; } = new();
        public Brand Brand { get; set; }

    }
}
