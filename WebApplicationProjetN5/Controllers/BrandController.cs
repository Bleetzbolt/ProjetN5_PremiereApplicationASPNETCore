using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplicationProjetN5.Models.Entities;
using WebApplicationProjetN5.Models.Services.Interfaces;
using WebApplicationProjetN5.Models.ViewModels;

namespace WebApplicationProjetN5.Controllers
{
    public class BrandController : Controller
    {
        private readonly IBrandService _brandService;

        public BrandController(IBrandService brandService)
        {
            _brandService = brandService;
        }
        public IEnumerable<BrandViewModel> GetAllBrands()
        {
            return _brandService.GetAllBrands();
        }

        public IActionResult Create(Brand brand)
        {
            _brandService.SaveBrand(brand);
            return RedirectToAction("Read");
        }

        public IActionResult Delete(int id)
        {
            _brandService.DeleteBrand(id);
            return RedirectToAction("Read");
        }

        public IActionResult Index()
        {
          
            return View();
        }
        public IActionResult Read()
        {
            IEnumerable<BrandViewModel> brands = GetAllBrands();

            return View(brands);
        }
    }
}
