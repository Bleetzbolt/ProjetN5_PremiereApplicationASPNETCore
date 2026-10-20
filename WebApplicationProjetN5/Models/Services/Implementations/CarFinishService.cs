using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplicationProjetN5.Models.Entities;
using WebApplicationProjetN5.Models.Repositories.Interfaces;
using WebApplicationProjetN5.Models.Services.Interfaces;
using WebApplicationProjetN5.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApplicationProjetN5.Models.Services.Implementations
{
    public class CarFinishService : ICarFinishService
    {
        private readonly ICarFinishRepository _CarFinishRepository;

        public CarFinishService(ICarFinishRepository CarFinishRepository)
        {
            _CarFinishRepository = CarFinishRepository;
        }


        public IList<CarFinish> GetAllCarFinish()
        {

            return _CarFinishRepository.GetAllCarFinish();
        }
        public int Save(CarFinish carFinish)
        {
            if (carFinish == null || string.IsNullOrWhiteSpace(carFinish.Name))
                return 0;

            var ExistingCarFinish = _CarFinishRepository.GetByName(carFinish.Name);

            if (ExistingCarFinish != null)
                return ExistingCarFinish.Id;

            _CarFinishRepository.Save(carFinish);
            return carFinish.Id;
        }

        public CarFinish? GetById(int id)
        {
            return _CarFinishRepository.GetById(id);
        }


        public CarFinish? GetByName(string name)
        {
            return _CarFinishRepository.GetByName(name);
        }

        public void Delete(int id)
        {
            _CarFinishRepository.Delete(id);

        }

        public IEnumerable<CarFinish> GetCarFinishByModel(string carModelName)
        {

            var carFinishes = GetAllCarFinish()
                .Where(f => f.CarModels.Any(m => m.Name == carModelName))
                .Select(f => new CarFinish
                {
                    Id = f.Id,
                    Name = f.Name
                })
                .ToList();
            return carFinishes;
        }
    }
}
