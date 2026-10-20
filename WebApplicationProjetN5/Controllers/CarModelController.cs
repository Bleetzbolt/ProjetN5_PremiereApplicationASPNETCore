using Microsoft.AspNetCore.Mvc;
using WebApplicationProjetN5.Models.Entities;
using WebApplicationProjetN5.Models.Services.Interfaces;
using WebApplicationProjetN5.Models.ViewModels;

namespace WebApplicationProjetN5.Controllers
{
    public class CarModelController : Controller
    {
        private readonly ICarModelService _CarModelService;
        private readonly IBrandService _brandService;

        public CarModelController(ICarModelService CarModelService)
        {
            _CarModelService = CarModelService;
        }
        public IEnumerable<CarModelViewModel> GetAllCarModels()
        {
            return _CarModelService.GetAllCarModels();
        }

        public IActionResult Create(CarModelViewModel carModelVM)
        {
            CarModel carModel = new CarModel
            {
                Name = carModelVM.CarModel.Name,
                BrandId = carModelVM.BrandId
                //CarFinishId = carModelVM.CarFinishId
            };
            _CarModelService.Save(carModel);
            return RedirectToAction("Read");
        }

        public IActionResult Delete(int id)
        {
            _CarModelService.Delete(id);
            return RedirectToAction("Read");
        }

        public IActionResult Index()
        {

            return View();
        }
        public IActionResult Read()
        {
            var CarModels = GetAllCarModels();

            return View(CarModels);
        }
    }
}

