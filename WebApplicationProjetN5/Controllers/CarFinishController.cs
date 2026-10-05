using Microsoft.AspNetCore.Mvc;
using WebApplicationProjetN5.Models.Entities;
using WebApplicationProjetN5.Models.Services.Interfaces;

namespace WebApplicationProjetN5.Controllers
{
    public class CarFinishController : Controller
    {
        private readonly ICarFinishService _CarFinishService;

        public CarFinishController(ICarFinishService CarFinishService)
        {
            _CarFinishService = CarFinishService;
        }
        public IList<CarFinish> GetAllCarFinishs()
        {
            return _CarFinishService.GetAllCarFinish();
        }

        public IActionResult Create(CarFinish CarFinish)
        {
            _CarFinishService.SaveCarFinish(CarFinish);
            return RedirectToAction("Read");
        }

        public IActionResult Delete(int id)
        {
            _CarFinishService.DeleteCarFinish(id);
            return RedirectToAction("Read");
        }

        public IActionResult Index()
        {

            return View();
        }
        public IActionResult Read()
        {
            var CarFinishs = GetAllCarFinishs();

            return View(CarFinishs);
        }
    }
}

