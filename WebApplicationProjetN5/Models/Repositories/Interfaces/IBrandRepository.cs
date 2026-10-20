using WebApplicationProjetN5.Models.Entities;
using WebApplicationProjetN5.Models.ViewModels;

namespace WebApplicationProjetN5.Models.Repositories.Interfaces
{
    public interface IBrandRepository
    {
        public IEnumerable<BrandViewModel> GetAllBrands();
        int Save(Brand brand);
        Brand? GetById(int id);
        void Delete(int id);
        Brand? GetByName(string name);

        void Update(Brand brand);
    }
}
