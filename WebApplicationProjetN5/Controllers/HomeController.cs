using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplicationProjetN5.Models;
using WebApplicationProjetN5.Models.Services.Interfaces;

namespace WebApplicationProjetN5.Controllers
{
    public class HomeController : Controller
    {
       private readonly ICarService _CarService;

        public HomeController(ICarService CarService)
        {
            _CarService = CarService;
        }


        public IActionResult Index()
        {
            var cars = _CarService.GetAllCars();
            return View(cars);
        }

        public IActionResult AddCar()
        {
            return View("Views/AddCar/Index.cshtml");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
