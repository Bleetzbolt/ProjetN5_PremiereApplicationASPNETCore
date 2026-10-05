using WebApplicationProjetN5.Models.Entities;
using WebApplicationProjetN5.Models.ViewModels;

namespace WebApplicationProjetN5.Models.Repositories.Interfaces
{
    public interface ICarRepository
    {
        public IEnumerable<CarViewModel> GetAllCars();
        void SaveCar(CarViewModel CarVM);
        Car? GetCar(int id);
        void DeleteCar(int id);
    }
}
