using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using WebApplicationProjetN5.Models.Entities;
using WebApplicationProjetN5.Models.Services.Implementations;

namespace WebApplicationProjetN5.Models.ViewModels
{
    public class CarViewModel
    {
        
        public Car Car { get; set; } = new();
        [Required]
        public string BrandName { get; set; }=string.Empty;

        [Required]
        public string CarModelName { get; set; }=string.Empty;

        public Brand Brand { get; set; }

        public CarFinish CarFinish { get; set; }

        
        public IEnumerable<SelectListItem> SelBrandVMs { get; set; } = [];
       
        public IEnumerable<SelectListItem> SelCarModelVMs { get; set; } = [];
       
        public IEnumerable<SelectListItem> SelCarFinishVMs { get; set; } = [];

    }
}
