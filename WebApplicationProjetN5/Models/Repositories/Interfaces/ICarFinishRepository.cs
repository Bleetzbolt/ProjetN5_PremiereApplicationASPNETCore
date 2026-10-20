using WebApplicationProjetN5.Models.Entities;

namespace WebApplicationProjetN5.Models.Repositories.Interfaces
{
    public interface ICarFinishRepository
    {
        public IList<CarFinish> GetAllCarFinish();
        int Save(CarFinish carFinish);
        CarFinish? GetById(int id);
        CarFinish? GetByName(string name);
        void Delete(int id);

    }
}
