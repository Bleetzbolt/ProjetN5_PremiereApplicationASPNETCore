using WebApplicationProjetN5.Data;
using WebApplicationProjetN5.Models.Entities;
using WebApplicationProjetN5.Models.Repositories.Interfaces;
using WebApplicationProjetN5.Models.ViewModels;

namespace WebApplicationProjetN5.Models.Repositories.Implementation
{
    public class BrandRepository : IBrandRepository
    {
        private static GarageDBContext _context;

        public BrandRepository(GarageDBContext context)
        {
            _context = context;
        }

        public IEnumerable<BrandViewModel> GetAllBrands()
        {
            IEnumerable<BrandViewModel> brands = _context.Brands.Select(b => new BrandViewModel
            {
                Id = b.Id,
                Name = b.Name
            }).ToList();
            return brands;
        }

        public void SaveBrand(Brand brand)
        {
            _context.Brands.Add(brand);
            _context.SaveChanges();
        }

        public Brand? GetBrand(int id)
        {
            return _context.Brands.Find(id);
        }

        public void DeleteBrand(int id)
        {
            var brandToDelete = GetBrand(id);
            if (brandToDelete != null)
            {
                _context.Brands.Remove(brandToDelete);
                _context.SaveChanges();
            }

        }
    }
}
