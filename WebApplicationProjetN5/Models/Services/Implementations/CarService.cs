using System.Linq.Expressions;
using WebApplicationProjetN5.Models.Entities;
using WebApplicationProjetN5.Models.Repositories.Implementation;
using WebApplicationProjetN5.Models.Repositories.Interfaces;
using WebApplicationProjetN5.Models.Services.Interfaces;
using WebApplicationProjetN5.Models.ViewModels;
 

namespace WebApplicationProjetN5.Models.Services.Implementations
{
    public class CarService : ICarService
    {
        private readonly ICarRepository _CarRepository;
        private readonly IBrandRepository _brandRepository;
        private readonly ICarModelRepository _carModelRepository;
        private readonly ICarFinishRepository _carFinishRepository;

        public CarService(ICarRepository CarRepository,
                            IBrandRepository brandRepository,
                                ICarModelRepository carModelRepository,
                                    ICarFinishRepository carFinishRepository)
        {
            _CarRepository = CarRepository;
            _brandRepository = brandRepository;
            _carModelRepository = carModelRepository;
            _carFinishRepository = carFinishRepository;
        }


        public IEnumerable<CarViewModel> GetAllCars()
        {

            return _CarRepository.GetAllCars();
        }
        public void SaveCar(CarViewModel carVM, IFormFile photo)
        {
            // Creation of a new Car entity from the CarViewModel
            var car = carVM.Car;
            car.Message = "";
            car.Photo = "";

            // Validate BrandName
            if (carVM.Car.CarModel.Brand.Name == null || string.IsNullOrEmpty(carVM.Car.CarModel.Brand.Name))
            {
                throw new ArgumentException("Brand cannot be null or empty.");
            }

            Brand? Brand = _brandRepository.GetByName(carVM.Car.CarModel.Brand.Name);
            if (Brand == null)
            {
                Brand = new Brand();
                Brand.Name = carVM.Car.CarModel.Brand.Name;
                _brandRepository.Save(Brand);
            }



            // Validate CarModelName
            if (carVM.Car.CarModel.Name == null || string.IsNullOrEmpty(carVM.Car.CarModel.Name))
            {
                throw new ArgumentException("CarModel cannot be null or empty.");
            }


            CarModel? carModel = _carModelRepository.GetByName(carVM.Car.CarModel.Name);
            if (carModel == null)
            {
                carModel = new CarModel();

                carModel.Name = carVM.Car.CarModel.Name;
                carModel.BrandId = _brandRepository.GetByName(carVM.Car.CarModel.Brand.Name).Id;

                car.CarModelId = _carModelRepository.Save(carModel);
            }
            else
            {
                car.CarModelId = carModel.Id;
            }

            // Add the CarModel to the Brand's CarModels collection if it doesn't already exist
            if (Brand.CarModels.FirstOrDefault(cm => cm.Id == carModel.Id) == null)
            {
                Brand.CarModels.Add(carModel);
                _brandRepository.Update(Brand);
            }



            // Validate CarFinish
            if (carVM.Car.CarFinish.Name == null || string.IsNullOrEmpty(carVM.Car.CarFinish.Name))
            {
                throw new ArgumentException("CarFinish cannot be null or empty.");
            }

            CarFinish? carFinish = _carFinishRepository.GetByName(carVM.Car.CarFinish.Name);
            if (carFinish == null)
            {
                carFinish = new CarFinish();
                carFinish.Name = carVM.Car.CarFinish.Name;

                car.CarFinishId = _carFinishRepository.Save(carFinish);
            }
            else
            {
                car.CarFinishId = carFinish.Id;
            }

            _carModelRepository.AddCarFinishIfMissing(carModel.Id, carFinish.Id);

            //validate the photo
            if (photo == null || string.IsNullOrEmpty(photo.FileName))
            {
                throw new ArgumentException("Photo cannot be null or empty.");
            }
            else
            {
                var fileName = Guid.NewGuid() + Path.GetExtension(photo.FileName);

                var folder = Path.Combine(
                    Directory.GetCurrentDirectory(),
                    "wwwroot",
                    "images",
                    "cars");

                Directory.CreateDirectory(folder);

                var filePath = Path.Combine(folder, fileName);

                using var stream = new FileStream(filePath, FileMode.Create);
                photo.CopyTo(stream);
                car.Photo = "/images/cars/" + fileName;

            }
            //deletion of Model and finition to avoid  EF Core  duplicate then in database
            car.CarFinish = null;
            car.CarModel = null;
            

            //Calculate the selling price:
            car.SellingPrice = car.PurchasePrice + 500 + car.Reparations.Sum(r => r.Cost);

            // Save the Car entity to the database
            _CarRepository.SaveCar(car);
        }

        
        public Car? GetById(int id)
        {
            return _CarRepository.GetById(id);
        }
        
       
        public void DeleteCar(int Id)
        {
            CarViewModel? carVM = GetAllCars().FirstOrDefault(c => c.Car.Id == Id);

            string filePath = Path.Combine(
                Directory.GetCurrentDirectory(),
                "wwwroot",
                carVM.Car.Photo.TrimStart('/'));

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            _CarRepository.DeleteCar(Id);

        }

        public void CarUpdate(CarViewModel carVM, IFormFile photo)
        {
            var car = _CarRepository.GetById(carVM.Car.Id);
            if(car == null)
            {
                throw new ArgumentException("Car not found.");
            }
            

            // Update the car properties
            car.Message = carVM.Car.Message;
            car.SellingPrice = carVM.Car.SellingPrice;

            // Validate CarFinish
            if (carVM.Car.CarFinish.Name == null || string.IsNullOrEmpty(carVM.Car.CarFinish.Name))
            {
                throw new ArgumentException("CarFinish cannot be null or empty.");
            }

            CarFinish? carFinish = _carFinishRepository.GetByName(carVM.Car.CarFinish.Name);
            if (carFinish == null)
            {
                carFinish = new CarFinish
                {
                    Name = carVM.Car.CarFinish.Name
                };

                car.CarFinishId = _carFinishRepository.Save(carFinish);
            }
            else
            {
                car.CarFinishId = carFinish.Id;
            }

            _carModelRepository.AddCarFinishIfMissing(car.CarModelId, carFinish.Id);




            // Handle photo update
            if (photo != null && !string.IsNullOrEmpty(photo.FileName))
            {
                // Delete the old photo if it exists
                if (!string.IsNullOrEmpty(car.Photo))
                {
                    string oldFilePath = Path.Combine(
                        Directory.GetCurrentDirectory(),
                        "wwwroot",
                        car.Photo.TrimStart('/'));
                    if (File.Exists(oldFilePath))
                    {
                        File.Delete(oldFilePath);
                    }
                }
                // Save the new photo
                var fileName = Guid.NewGuid() + Path.GetExtension(photo.FileName);
                var folder = Path.Combine(
                    Directory.GetCurrentDirectory(),
                    "wwwroot",
                    "images",
                    "cars");
                Directory.CreateDirectory(folder);
                var filePath = Path.Combine(folder, fileName);
                using var stream = new FileStream(filePath, FileMode.Create);
                photo.CopyTo(stream);
                car.Photo = "/images/cars/" + fileName;
            }
            // Save changes to the database
            _CarRepository.UpdateCar(car);
        }
    }
}
