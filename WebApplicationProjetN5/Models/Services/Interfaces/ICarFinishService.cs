using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplicationProjetN5.Models.Entities;

namespace WebApplicationProjetN5.Models.Services.Interfaces
{
    public interface ICarFinishService
    {
        public IList<CarFinish> GetAllCarFinish();
        int Save(CarFinish carFinish);

        void Delete(int id);

        CarFinish? GetById(int id);

        CarFinish? GetByName(string name);

        IEnumerable<CarFinish> GetCarFinishByModel(string modelName);

    }
}
