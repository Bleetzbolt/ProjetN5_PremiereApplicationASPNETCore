using WebApplicationProjetN5.Models.Entities;
using WebApplicationProjetN5.Models.ViewModels;

namespace WebApplicationProjetN5.Models.Repositories.Interfaces
{
    public interface ICarModelRepository
    {
        public IEnumerable<CarModelViewModel> GetAllCarModels();
        void SaveCarModel(CarModelViewModel CarModel);
        CarModel? GetCarModel(int id);
        void DeleteCarModel(int id);
    }
}
