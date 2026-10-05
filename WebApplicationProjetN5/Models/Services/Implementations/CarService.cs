using WebApplicationProjetN5.Models.Entities;
using WebApplicationProjetN5.Models.Repositories.Interfaces;
using WebApplicationProjetN5.Models.Services.Interfaces;
using WebApplicationProjetN5.Models.ViewModels;

namespace WebApplicationProjetN5.Models.Services.Implementations
{
    public class CarService :ICarService
    {
        private readonly ICarRepository _CarRepository;

        public CarService(ICarRepository CarRepository)
        {
            _CarRepository = CarRepository;
        }


        public IEnumerable<CarViewModel> GetAllCars()
        {

            return _CarRepository.GetAllCars();
        }
        public void SaveCar(CarViewModel carVM)
        {
            _CarRepository.SaveCar(carVM);
        }

        public int GetCarId(Car Car)
        {
            return Car.Id;
        }
        public void DeleteCar(int id)
        {
            _CarRepository.DeleteCar(id);

        }
    }
}
