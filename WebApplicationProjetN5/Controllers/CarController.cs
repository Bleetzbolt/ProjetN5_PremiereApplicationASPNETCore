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
        private readonly ICarFinishService _CarFinishService;


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
            if (carVM.Car.CarModel.Brand.Name == "__custom__Brand")
            {
                carVM.Car.CarModel.Brand.Name = CustomBrand;
            }
            if (carVM.Car.CarModel.Name == "__custom__CarModel")
            {
                carVM.Car.CarModel.Name = CustomCarModel;
            }
            if (carVM.Car.CarFinish.Name == "__custom__CarFinish")
            {
                carVM.Car.CarFinish.Name = CustomCarFinish;
            }

            

            // Supprimer la validation pour la propriété Photo du Model si la photo exist
            if (photo == null || photo.Length == 0)
            {
                carVM.Car.Photo = null;
                ModelState.AddModelError("Car.Photo", "Veuillez ajouter une image.");
                //ModelState.Remove("Car.Photo"); 
            }
            else
            {
                carVM.Car.Photo = photo.FileName;

                // Retirer une éventuelle erreur de validation
                // initiale sur Car.Photo.
                ModelState.Remove("Car.Photo");
            }

            //Retrait du Model des Car.reparations
            for (int x = 0; x <= carVM.Car.Reparations.Count; x++)
            {

                ModelState.Remove("Car.Reparations[" + x + "].Car");
            }

            //Ajout d'erreur au model si le champs de saisie d'ajout d'une marque est vide
            if(carVM.Car.CarModel.Brand.Name==null || carVM.Car.CarModel.Brand.Name.Length==0)
            {
                ModelState.AddModelError("Car.CarModel.Brand.Name", "Veuillez Ajouter une marque.");
            }
            //Ajout d'erreur au model si le champs de saisie d'ajout d'un modèle est vide
            if (carVM.Car.CarModel.Name == null || carVM.Car.CarModel.Name.Length == 0)
            {
                ModelState.AddModelError("Car.CarModel.Name", "Veuillez Ajouter un modèle.");
            }
            //Ajout d'erreur au model si le champs de saisie d'ajout d'une finition est vide
            if (carVM.Car.CarFinish.Name == null || carVM.Car.CarFinish.Name.Length == 0)
            {
                ModelState.AddModelError("Car.CarFinish.Name", "Veuillez Ajouter une finition.");
            }

            //Vérification du model: si il y a une erreur on renvoie la page en rechargeant les listes déroulantes
            if (!ModelState.IsValid)
            {
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
                return View("FormNewCar", carVM);
            }


            _CarService.SaveCar(carVM, photo);
            return RedirectToAction("CarPublished");
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int Car_Id)
        {
            // Retrieve the car view model before deletion
            CarViewModel? carVM = _CarService.GetAllCars().FirstOrDefault(c => c.Car.Id == Car_Id);

            _CarService.DeleteCar(Car_Id);
            return View("CarDeleted", carVM);
        }

        public IActionResult Index()
        {
            var Cars = GetAllCars();

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
            carVM.SelCarFinishVMs = _CarFinishService.GetCarFinishByModel(carVM.Car.CarModel.Name).ToList().Select(cf => new SelectListItem
            {
                Value = cf.Name,
                Text = cf.Name
            });


            return View(carVM);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult CarUpdate(CarViewModel carVM, IFormFile photo, string? CustomCarFinish)
        {
            if (carVM.Car.CarFinish.Name == "__custom__CarFinish")
            {
                carVM.Car.CarFinish.Name = CustomCarFinish;
            }
            //Ajout d'erreur au model si le champs de saisie d'ajout d'une finition est vide
            if (carVM.Car.CarFinish.Name == null || carVM.Car.CarFinish.Name.Length == 0)
            {
                ModelState.AddModelError("Car.CarFinish.Name", "Veuillez Ajouter une finition.");
            }

            ModelState.Remove("photo");
            ModelState.Remove("Car.Photo");
            ModelState.Remove("Car.CarModel");
            ModelState.Remove("Car.ReleasedYear");
            ModelState.Remove("Car.PurchasePrice");

            //Vérification du model: si il y a une erreur on renvoie la page en rechargeant les listes déroulantes
            if (!ModelState.IsValid)
            {
                
                return RedirectToAction("FormUpdate", new { Car_Id = carVM.Car.Id });
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

