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

        public int Save(Brand brand)
        {

            _context.Brands.Add(brand);
            _context.SaveChanges();
            return brand.Id;
        }

        public Brand? GetById(int id)
        {
            return _context.Brands.Find(id);
        }

        public Brand? GetByName(string name)
        {
            return _context.Brands.FirstOrDefault(b => b.Name == name);
        }

        public void Delete(int id)
        {
            var brandToDelete = GetById(id);
            if (brandToDelete != null)
            {
                _context.Brands.Remove(brandToDelete);
                _context.SaveChanges();
            }

        }

        public void Update(Brand brand)
        {
                _context.Update(brand);
                _context.SaveChanges();
           
        }

    }
}
