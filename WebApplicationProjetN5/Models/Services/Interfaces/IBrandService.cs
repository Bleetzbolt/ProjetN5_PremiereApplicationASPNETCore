using Microsoft.CodeAnalysis;
using WebApplicationProjetN5.Models.Entities;
using WebApplicationProjetN5.Models.ViewModels;

namespace WebApplicationProjetN5.Models.Services.Interfaces
{
    public interface IBrandService
    {
        public IEnumerable<BrandViewModel> GetAllBrands();
        void SaveBrand(Brand brand);

        void DeleteBrand(int id);

        int GetBrandId(Brand Brand);

    }
}
