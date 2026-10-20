using WebApplicationProjetN5.Models.Entities;
using WebApplicationProjetN5.Models.ViewModels;

namespace WebApplicationProjetN5.Models.Services.Interfaces
{
    public interface ICarModelService
    {
        public IEnumerable<CarModelViewModel> GetAllCarModels();
        void Save(CarModel CarModel);

        void Delete(int id);

        CarModel? GetById(int id);
        CarModel? GetByName(string name);
    }
}
