using System.Data.SqlTypes;
using WebApplicationProjetN5.Data;
using WebApplicationProjetN5.Models.Entities;
using WebApplicationProjetN5.Models.Repositories.Interfaces;
using WebApplicationProjetN5.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace WebApplicationProjetN5.Models.Repositories.Implementation
{
    public class CarRepository : ICarRepository
    {
        private static GarageDBContext _context;
        private readonly IBrandRepository _brandRepository;

        public CarRepository(GarageDBContext context)
        {
            _context = context;
        }

        public IEnumerable<CarViewModel> GetAllCars()
        {
            var cars = _context.Cars
                .Include(c => c.CarModel)
                .ThenInclude(cm => cm.Brand)
                .Select(c => new CarViewModel
                {
                    Car = c,
                    Brand = c.CarModel.Brand
                });

            return cars;
        }

        public void SaveCar(CarViewModel CarVM)
        {
            var Car = CarVM.Car;

            _context.Cars.Add(Car);
            _context.SaveChanges();
        }

        public Car? GetCar(int id)
        {
            return _context.Cars.Find(id);
        }

        public void DeleteCar(int id)
        {
            var CarToDelete = GetCar(id);
            if (CarToDelete != null)
            {
                _context.Cars.Remove(CarToDelete);
                _context.SaveChanges();
            }

        }
    }
}

