using WebApplicationProjetN5.Models.Entities;
using WebApplicationProjetN5.Models.ViewModels;

namespace WebApplicationProjetN5.Models.Repositories.Interfaces
{
    public interface IBrandRepository
    {
        public IEnumerable<BrandViewModel> GetAllBrands();
        void SaveBrand(Brand brand);
        Brand? GetBrand(int id);
        void DeleteBrand(int id);
    }
}
