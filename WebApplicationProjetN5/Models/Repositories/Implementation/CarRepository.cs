using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlTypes;
using WebApplicationProjetN5.Data;
using WebApplicationProjetN5.Models.Entities;
using WebApplicationProjetN5.Models.Repositories.Interfaces;
using WebApplicationProjetN5.Models.ViewModels;

namespace WebApplicationProjetN5.Models.Repositories.Implementation
{
    public class CarRepository : ICarRepository
    {
        private static GarageDBContext _context;
        private readonly IBrandRepository _brandRepository;
        private readonly ICarModelRepository _carModelRepository;
        private readonly ICarFinishRepository _carFinishRepository;

        public CarRepository(GarageDBContext context, IBrandRepository brandRepository, ICarModelRepository carModelRepository, ICarFinishRepository carFinishRepository)
        {
            _context = context;
            _brandRepository = brandRepository;
            _carModelRepository = carModelRepository;
            _carFinishRepository = carFinishRepository;
        }

        public  IEnumerable<CarViewModel> GetAllCars()
        {
            var cars = _context.Cars
                .Include(c => c.CarModel)
                .ThenInclude(cm => cm.Brand)
                .Include(c => c.CarFinish)
                .Select(c => new CarViewModel
                {
                    Car = c
                });

            return cars;
        }

        public void SaveCar(Car car)
        {
            _context.Cars.Add(car);
            _context.SaveChanges();
        }

        public void UpdateCar(Car car)
        {
            _context.SaveChanges();
        }

        public Car? GetById(int id)
        {
            return _context.Cars.Find(id);
        }

        public void DeleteCar(int id)
        {
            var CarToDelete = GetById(id);
            if (CarToDelete != null)
            {
                _context.Cars.Remove(CarToDelete);
                _context.SaveChanges();
            }
        }
    }
}

