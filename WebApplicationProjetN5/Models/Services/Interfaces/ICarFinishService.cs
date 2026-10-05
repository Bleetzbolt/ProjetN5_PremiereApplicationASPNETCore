using WebApplicationProjetN5.Models.Entities;

namespace WebApplicationProjetN5.Models.Services.Interfaces
{
    public interface ICarFinishService
    {
        public IList<CarFinish> GetAllCarFinish();
        void SaveCarFinish(CarFinish carFinish);

        void DeleteCarFinish(int id);

        int GetCarFinishId(CarFinish carFinish);

    }
}
