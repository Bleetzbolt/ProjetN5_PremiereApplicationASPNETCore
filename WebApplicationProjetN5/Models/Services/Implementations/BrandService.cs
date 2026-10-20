using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
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
        public int Save(Brand brand)
        {
            if (brand == null || string.IsNullOrWhiteSpace(brand.Name))
                return 0;

            var ExistingBrand = _brandRepository.GetByName(brand.Name);

            if (ExistingBrand != null)
                return ExistingBrand.Id;

            return _brandRepository.Save(brand);
        }

        public Brand? GetById(int Id)
        {
           return _brandRepository.GetById(Id);
        }
             


        public void Delete(int id)
        { 
         _brandRepository.Delete(id);

        }
    }
}
