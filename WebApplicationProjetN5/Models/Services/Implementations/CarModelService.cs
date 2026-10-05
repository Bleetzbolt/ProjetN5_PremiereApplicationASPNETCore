using WebApplicationProjetN5.Models.Entities;
using WebApplicationProjetN5.Models.Repositories.Interfaces;
using WebApplicationProjetN5.Models.Services.Interfaces;
using WebApplicationProjetN5.Models.ViewModels;

namespace WebApplicationProjetN5.Models.Services.Implementations
{
    public class CarModelService : ICarModelService
    {
        private readonly ICarModelRepository _CarModelRepository;

        public CarModelService(ICarModelRepository CarModelRepository)
        {
            _CarModelRepository = CarModelRepository;
        }


        public IEnumerable<CarModelViewModel> GetAllCarModels()
        {

            return _CarModelRepository.GetAllCarModels();
        }
        public void SaveCarModel(CarModelViewModel CarModel)
        {
            _CarModelRepository.SaveCarModel(CarModel);
        }

        public int GetCarModelId(CarModel CarModel)
        {
            return CarModel.Id;
        }
        public void DeleteCarModel(int id)
        {
            _CarModelRepository.DeleteCarModel(id);

        }
    }
}
