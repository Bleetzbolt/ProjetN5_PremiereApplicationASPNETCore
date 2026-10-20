using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplicationProjetN5.Models.Entities;
using WebApplicationProjetN5.Models.Services.Implementations;
using WebApplicationProjetN5.Models.Services.Interfaces;
using WebApplicationProjetN5.Models.ViewModels;

namespace WebApplicationProjetN5.Controllers
{
    public class CarController : Controller
    {

        private readonly ICarService _CarService;
        private readonly ICarModelService _CarModelService;
        private  readonly ICarFinishService _CarFinishService;


        private readonly IBrandService _BrandService;

        public CarController(ICarService CarService, ICarModelService CarModelService, IBrandService BrandService, ICarFinishService CarFinishService)
        {
            _CarService = CarService;
            _CarModelService = CarModelService;
            _BrandService = BrandService;
            _CarFinishService = CarFinishService;
        }
        public IEnumerable<CarViewModel> GetAllCars()
        {
            return _CarService.GetAllCars();
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Create(CarViewModel carVM, IFormFile photo, string? CustomBrand, string? CustomCarModel, string? CustomCarFinish)
        {
            if(carVM.BrandName == "__custom__Brand")
            {
                carVM.BrandName = CustomBrand;
            }
            if(carVM.CarModelName == "__custom__CarModel")
            {
                carVM.CarModelName = CustomCarModel;
            }
            if (carVM.CarFinish.Name == "__custom__CarFinish")
            {
                carVM.CarFinish.Name = CustomCarFinish;
            }
/*
            if (!ModelState.IsValid)
            {
                // Recharger ici les listes déroulantes
                // SelBrandVMs, SelCarModelVMs et SelCarFinishVMs.
                return RedirectToAction("FormNewCar");
            }
*/

            _CarService.SaveCar(carVM,photo);
            return RedirectToAction("CarPublished");
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int Car_Id)
        {
            // Retrieve the car view model before deletion
            CarViewModel? carVM = _CarService.GetAllCars().FirstOrDefault(c => c.Car.Id == Car_Id);
            
            _CarService.DeleteCar(Car_Id);
            return View("CarDeleted",carVM);
        }

        public IActionResult Index()
        {
            var Cars= GetAllCars();

            return View(Cars);
        }
        public IActionResult Read()
        {
            var Cars = GetAllCars();

            return View(Cars);
        }
        [Authorize(Roles = "Admin")]
        public IActionResult FormNewCar()
        {
            CarViewModel carVM = new CarViewModel();

            carVM.Car.SaleDate = DateOnly.FromDateTime(DateTime.Now);
            carVM.SelBrandVMs = _BrandService.GetAllBrands().Select(b => new SelectListItem
            {
                Value = b.Name,
                Text = b.Name
            });
            carVM.SelCarModelVMs = _CarModelService.GetAllCarModels().Select(cm => new SelectListItem
            {
                Value = cm.CarModel.Name,
                Text = cm.CarModel.Name
            });
            carVM.SelCarFinishVMs = _CarFinishService.GetAllCarFinish().Select(cf => new SelectListItem
            {
                Value = cf.Name,
                Text = cf.Name
            });
            return View(carVM);
        }

        public IActionResult CarPublished()
        {
            return View();
        }
        public IActionResult Single_Car(int Car_Id)
        {
           CarViewModel? carVM = _CarService.GetAllCars().FirstOrDefault(c => c.Car.Id == Car_Id);

            return View(carVM);
        }
        [Authorize(Roles = "Admin")]
        public IActionResult FormUpdate(int Car_Id)
        {
            CarViewModel? carVM = _CarService.GetAllCars().FirstOrDefault(c => c.Car.Id == Car_Id);
            
            if (carVM == null)
            {
                return NotFound($"Aucune voiture trouvée avec l'identifiant {Car_Id}.");
            }
            carVM.SelCarFinishVMs = _CarFinishService.GetCarFinishByModel(carVM.CarModelName).ToList().Select(cf => new SelectListItem
            {
                Value = cf.Name,
                Text = cf.Name
            });

            
            return View(carVM);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult CarUpdate(CarViewModel carVM, IFormFile photo, string? CustomCarFinish)
        {
            if (carVM.CarFinish.Name == "__custom__CarFinish")
            {
                carVM.CarFinish.Name = CustomCarFinish;
            }
            _CarService.CarUpdate(carVM, photo);
            return RedirectToAction("Single_Car", new { Car_Id = carVM.Car.Id });
        }

        [HttpGet]
        public IActionResult GetModelsByBrand(string brandName)
        {
            var models = _CarModelService.GetAllCarModels()
                .Where(m => m.Brand.Name == brandName)
                .Select(m => new
                {
                    id = m.CarModel.Id,
                    name = m.CarModel.Name
                })
                .ToList();

            return Json(models);
        }
        [HttpGet]
        public IActionResult GetCarFinishesByModel(string carModelName)
        {
            
            var carFinishes = _CarFinishService.GetCarFinishByModel(carModelName).ToList();
            return Json(carFinishes);
            
     
        }
    }
}

