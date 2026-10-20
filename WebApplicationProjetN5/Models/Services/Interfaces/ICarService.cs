using WebApplicationProjetN5.Models.Entities;
using WebApplicationProjetN5.Models.ViewModels;

namespace WebApplicationProjetN5.Models.Services.Interfaces
{
    public interface ICarService
    {
        public IEnumerable<CarViewModel> GetAllCars();
        void SaveCar(CarViewModel carVM, IFormFile photo);

        void DeleteCar(int id);

        Car? GetById(int id);

        void CarUpdate(CarViewModel carVM, IFormFile photo);
    }
}
