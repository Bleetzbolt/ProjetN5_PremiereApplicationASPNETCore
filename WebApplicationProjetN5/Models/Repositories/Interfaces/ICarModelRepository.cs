using WebApplicationProjetN5.Models.Entities;
using WebApplicationProjetN5.Models.ViewModels;

namespace WebApplicationProjetN5.Models.Repositories.Interfaces
{
    public interface ICarModelRepository
    {
        public IEnumerable<CarModelViewModel> GetAllCarModels();
        int Save(CarModel CarModel);
        CarModel? GetById(int id);
        CarModel? GetByName(string name);
        void Delete(int id);

        void Update(CarModel CarModel);

        void AddCarFinishIfMissing(int carModelId, int finishId);
    }
}
