using WebApplicationProjetN5.Models.Entities;

namespace WebApplicationProjetN5.Models.Repositories.Interfaces
{
    public interface ICarFinishRepository
    {
        public IList<CarFinish> GetAllCarFinish();
        void SaveCarFinish(CarFinish carFinish);
        CarFinish? GetCarFinish(int id);
        void DeleteCarFinish(int id);
    }
}
