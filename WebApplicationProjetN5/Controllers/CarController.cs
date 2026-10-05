using Microsoft.AspNetCore.Mvc;
using WebApplicationProjetN5.Models.Entities;
using WebApplicationProjetN5.Models.Services.Interfaces;
using WebApplicationProjetN5.Models.ViewModels;

namespace WebApplicationProjetN5.Controllers
{
    public class CarController : Controller
    {

        private readonly ICarService _CarService;

        public CarController(ICarService CarService)
        {
            _CarService = CarService;
        }
        public IEnumerable<CarViewModel> GetAllCars()
        {
            return _CarService.GetAllCars();
        }

        public IActionResult Create(CarViewModel carVM)
        {
            _CarService.SaveCar(carVM);
            return RedirectToAction("Read");
        }

        public IActionResult Delete(CarViewModel carVM)
        {
            _CarService.DeleteCar(carVM.Car.Id);
            return RedirectToAction("Read");
        }

        public IActionResult Index()
        {

            return View();
        }
        public IActionResult Read()
        {
            var Cars = GetAllCars();

            return View(Cars);
        }
    }
}

