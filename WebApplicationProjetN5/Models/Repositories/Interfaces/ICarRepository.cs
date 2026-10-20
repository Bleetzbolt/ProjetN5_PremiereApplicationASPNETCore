using WebApplicationProjetN5.Models.Entities;
using WebApplicationProjetN5.Models.ViewModels;

namespace WebApplicationProjetN5.Models.Repositories.Interfaces
{
    public interface ICarRepository
    {
        public IEnumerable<CarViewModel> GetAllCars();
        public void SaveCar(Car car);
        public Car? GetById(int id);
        public void DeleteCar(int id);
        public void UpdateCar(Car car);

       
    }
}
