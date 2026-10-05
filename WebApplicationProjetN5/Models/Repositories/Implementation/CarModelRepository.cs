using WebApplicationProjetN5.Data;
using WebApplicationProjetN5.Models.Entities;
using WebApplicationProjetN5.Models.Repositories.Interfaces;
using WebApplicationProjetN5.Models.ViewModels;

namespace WebApplicationProjetN5.Models.Repositories.Implementation
{
    public class CarModelRepository : ICarModelRepository
        {
        private readonly IBrandRepository _brandRepository;
        private static GarageDBContext _context;

        public CarModelRepository(GarageDBContext context)
        {
            _context = context;
        }

        public IEnumerable<CarModelViewModel> GetAllCarModels()
        {
            
            IEnumerable<CarModelViewModel> carModels = _context.CarModels.Select(cm => new CarModelViewModel
            {
                CarModel = new CarModel
                {
                    Id = cm.Id,
                    Name = cm.Name,
                    BrandId = cm.BrandId

                },
                Brand = _context.Brands.FirstOrDefault(b => b.Id == cm.BrandId),
                CarFinishName = cm.CarFinishes[0].Name

            }).ToList();
            
            return carModels;
        }

        public void SaveCarModel(CarModelViewModel carModelVM)
        {
            var carModel = new CarModel
            {
                Name=carModelVM.CarModel.Name,
                BrandId=carModelVM.BrandId,

            };


            var carFinish = _context.CarFinishs
                .FirstOrDefault(f => f.Id == carModelVM.CarFinishId);
            carModel.CarFinishes.Add(carFinish);
            _context.CarModels.Add(carModel);
            _context.SaveChanges();
        }

        public CarModel? GetCarModel(int id)
        {
            return _context.CarModels.Find(id);
        }

        public void DeleteCarModel(int id)
        {
            var CarModelToDelete = GetCarModel(id);
            if (CarModelToDelete != null)
            {
                _context.CarModels.Remove(CarModelToDelete);
                _context.SaveChanges();
            }
        }
    }
}
