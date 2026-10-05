using Microsoft.CodeAnalysis;
using WebApplicationProjetN5.Models.Entities;
using WebApplicationProjetN5.Models.Repositories.Interfaces;
using WebApplicationProjetN5.Models.Services.Interfaces;
using WebApplicationProjetN5.Models.ViewModels;

namespace WebApplicationProjetN5.Models.Services.Implementations
{
    public class BrandService : IBrandService
    {
        private readonly IBrandRepository _brandRepository;

        public BrandService(IBrandRepository BrandRepository)
        {
            _brandRepository = BrandRepository;
        }


        public IEnumerable<BrandViewModel> GetAllBrands()
        {
           
           return _brandRepository.GetAllBrands();
        }
        public void SaveBrand(Brand brand)
        {
           _brandRepository.SaveBrand(brand);
        }

        public int GetBrandId(Brand brand)
        {
           return brand.Id;
        }
        public void DeleteBrand(int id)
        { 
         _brandRepository.DeleteBrand(id);

        }
    }
}
