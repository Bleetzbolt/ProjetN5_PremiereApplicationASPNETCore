using Microsoft.CodeAnalysis;
using WebApplicationProjetN5.Models.Entities;
using WebApplicationProjetN5.Models.ViewModels;

namespace WebApplicationProjetN5.Models.Services.Interfaces
{
    public interface IBrandService
    {
        public IEnumerable<BrandViewModel> GetAllBrands();
        int Save(Brand brand);

        void Delete(int Id);

        Brand? GetById(int Id);

        

    }
}
