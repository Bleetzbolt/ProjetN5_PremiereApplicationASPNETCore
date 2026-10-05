using WebApplicationProjetN5.Data;
using WebApplicationProjetN5.Models.Entities;
using WebApplicationProjetN5.Models.Repositories.Interfaces;

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
            return _context.CarFinishs.ToList();
        }

        public void SaveCarFinish(CarFinish CarFinish)
        {
            _context.CarFinishs.Add(CarFinish);
            _context.SaveChanges();
        }

        public CarFinish? GetCarFinish(int id)
        {
            return _context.CarFinishs.Find(id);
        }

        public void DeleteCarFinish(int id)
        {
            var CarFinishToDelete = GetCarFinish(id);
            if (CarFinishToDelete != null)
            {
                _context.CarFinishs.Remove(CarFinishToDelete);
                _context.SaveChanges();
            }

        }
    }
}

