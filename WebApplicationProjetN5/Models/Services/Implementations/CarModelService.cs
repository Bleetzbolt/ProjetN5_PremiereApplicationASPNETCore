using Microsoft.EntityFrameworkCore;
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
        public void Save(CarModel carModel)
        {
             
            _CarModelRepository.Save(carModel);
        }

        public CarModel? GetById(int Id)
        {
            return _CarModelRepository.GetById(Id);
        }

        public CarModel? GetByName(string name)
        {
            return _CarModelRepository.GetByName(name);
        }

        public int GetCarModelId(CarModel CarModel)
        {
            return CarModel.Id;
        }
        
        public void Delete(int id)
        {
            _CarModelRepository.Delete(id);

        }
        
    }
}
