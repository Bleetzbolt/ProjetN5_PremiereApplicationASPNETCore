using WebApplicationProjetN5.Models.Entities;
using WebApplicationProjetN5.Models.ViewModels;

namespace WebApplicationProjetN5.Models.Services.Interfaces
{
    public interface ICarModelService
    {
        public IEnumerable<CarModelViewModel> GetAllCarModels();
        void SaveCarModel(CarModelViewModel CarModel);

        void DeleteCarModel(int id);

        int GetCarModelId(CarModel CarModel);
    }
}
