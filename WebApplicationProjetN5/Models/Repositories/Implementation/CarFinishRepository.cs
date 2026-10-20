using WebApplicationProjetN5.Data;
using WebApplicationProjetN5.Models.Entities;
using WebApplicationProjetN5.Models.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace WebApplicationProjetN5.Models.Repositories.Implementation
{
    public class CarFinishRepository : ICarFinishRepository
    {
        private static GarageDBContext _context;

        public CarFinishRepository(GarageDBContext context)
        {
            _context = context;
        }

        public IList<CarFinish> GetAllCarFinish()
        {
            return _context.CarFinishes
                    .Include(f => f.CarModels)
                    .Include(c => c.Cars)
                    .ToList();
        }

        public int Save(CarFinish CarFinish)
        {
           

            _context.CarFinishes.Add(CarFinish);
            _context.SaveChanges();
            return CarFinish.Id;
                      
        }

        public CarFinish? GetById(int id)
        {
            return _context.CarFinishes.Find(id);
        }

        public CarFinish? GetByName(string name)
        {
            return _context.CarFinishes.FirstOrDefault(cf => cf.Name == name);
        }

        public void Delete(int id)
        {
            var CarFinishToDelete = GetById(id);
            if (CarFinishToDelete != null)
            {
                _context.CarFinishes.Remove(CarFinishToDelete);
                _context.SaveChanges();
            }

        }
    }
}

