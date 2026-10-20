using Microsoft.EntityFrameworkCore;
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

            return _context.CarModels
         .Include(cm => cm.CarFinishes)
         .Select(cm => new CarModelViewModel
         {
             CarModel = new CarModel
             {
                 Id = cm.Id,
                 Name = cm.Name,
                 BrandId = cm.BrandId
             },
             Brand = _context.Brands
                 .FirstOrDefault(b => b.Id == cm.BrandId),
             CarFinishName = cm.CarFinishes
                 .Select(cf => cf.Name)
                 .FirstOrDefault() ?? ""
         })
         .ToList();
        }

        public int Save(CarModel carModel)
        {
            if (carModel.CarFinishes == null)
            {
                // var CarFinish = _context.CarFinishes.FirstOrDefault(f => f.Id == carModel.);
            }


            //var carFinish = _context.CarFinishes
            //.Any(f => f.Id == carModel.CarFinishes[0].Id);
            //carModel.CarFinishes.Add(carFinish);
            _context.CarModels.Add(carModel);
            _context.SaveChanges();

            return carModel.Id;
        }

        public CarModel? GetById(int id)
        {
            return _context.CarModels.Find(id);
        }

        public CarModel? GetByName(string name)
        {
            return _context.CarModels.FirstOrDefault(cm => cm.Name == name);
        }

        public void Delete(int id)
        {
            var CarModelToDelete = GetById(id);
            if (CarModelToDelete != null)
            {
                _context.CarModels.Remove(CarModelToDelete);
                _context.SaveChanges();
            }
        }

        public void Update(CarModel carModel)
        {


            _context.Update(carModel);
            _context.SaveChanges();

        }

        public void AddCarFinishIfMissing(int carModelId, int carFinishId)
        {
            var carModel = _context.CarModels
                .Include(cm => cm.CarFinishes)
                .FirstOrDefault(cm => cm.Id == carModelId);

            if (carModel == null)
                throw new ArgumentException("Modèle introuvable.");

            var carFinish = _context.CarFinishes
                .Find(carFinishId);

            if (carFinish == null)
                throw new ArgumentException("Finition introuvable.");

            if (!carModel.CarFinishes.Any(cf => cf.Id == carFinishId))
            {
                carModel.CarFinishes.Add(carFinish);
                _context.SaveChanges();
            }
        }
    }
}
