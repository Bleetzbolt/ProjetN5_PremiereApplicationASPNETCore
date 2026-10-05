using WebApplicationProjetN5.Models.Entities;
using WebApplicationProjetN5.Models.Repositories.Interfaces;
using WebApplicationProjetN5.Models.Services.Interfaces;

namespace WebApplicationProjetN5.Models.Services.Implementations
{
    public class CarFinishService : ICarFinishService
    {
        private readonly ICarFinishRepository _CarFinishRepository;

        public CarFinishService(ICarFinishRepository CarFinishRepository)
        {
            _CarFinishRepository = CarFinishRepository;
        }


        public IList<CarFinish> GetAllCarFinish()
        {

            return _CarFinishRepository.GetAllCarFinish();
        }
        public void SaveCarFinish(CarFinish CarFinish)
        {
            _CarFinishRepository.SaveCarFinish(CarFinish);
        }

        public int GetCarFinishId(CarFinish CarFinish)
        {
            return CarFinish.Id;
        }
        public void DeleteCarFinish(int id)
        {
            _CarFinishRepository.DeleteCarFinish(id);

        }
    }
}
