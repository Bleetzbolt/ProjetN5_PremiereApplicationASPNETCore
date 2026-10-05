using Microsoft.AspNetCore.Mvc;
using WebApplicationProjetN5.Models.Entities;
using WebApplicationProjetN5.Models.Services.Interfaces;

namespace WebApplicationProjetN5.Controllers
{
    public class ReparationController : Controller
    {
        private readonly IReparationService _ReparationService;

        public ReparationController(IReparationService ReparationService)
        {
            _ReparationService = ReparationService;
        }
        public IList<Reparation> GetAllReparations()
        {
            return _ReparationService.GetAllReparations();
        }

        public IActionResult Create(Reparation Reparation)
        {
            _ReparationService.SaveReparation(Reparation);
            return RedirectToAction("Read");
        }

        public IActionResult Delete(int id)
        {
            _ReparationService.DeleteReparation(id);
            return RedirectToAction("Read");
        }

        public IActionResult Index()
        {

            return View();
        }
        public IActionResult Read()
        {
            var Reparations = GetAllReparations();

            return View(Reparations);
        }
    }
}
