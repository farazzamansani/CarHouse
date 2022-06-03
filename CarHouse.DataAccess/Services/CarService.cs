using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarHouse.DataAccess.Services
{
    public class CarService : ICarService
    {
        private readonly CarHouseContext _context;

        public CarService(CarHouseContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Returns list of cars filterable by given parameters
        /// </summary>
        /// <param name="registrationNumber"></param>
        /// <param name="availableCarsOnly"></param>
        /// <returns></returns>
        public IList<Car> GetCars(string? registrationNumber, bool availableCarsOnly)
        {
            IQueryable<Car> cars = _context.Cars;
            if (availableCarsOnly)
            {
                cars = cars.Where(c => c.AvailableFlag == true);
            }
            if (!string.IsNullOrEmpty(registrationNumber))
            {
                cars = cars.Where(c => c.RegistrationNumber.Contains(registrationNumber));
            }
            return cars.ToList();
        }

        public Car GetCarDetails(int id)
        {
            return _context.Cars.Single(c => c.CarId == id);
        }
  
        /// <summary>
        /// Add a new car to the database
        /// </summary>
        /// <param name="make"></param>
        /// <param name="model"></param>
        /// <param name="year"></param>
        /// <param name="odometerKm"></param>
        /// <param name="advertisedPrice"></param>
        /// <param name="notes"></param>
        /// <param name="AcquiredDate"></param>
        /// <param name="availableFlag"></param>
        public void AddCar(string make, string model,string registration, int year, int odometerKm, decimal advertisedPrice, string? notes, DateTimeOffset AcquiredDate, bool availableFlag)
        {
            var car = new Car()
            {
                Make = make,
                Model = model,
                RegistrationNumber = registration,
                Year = year,
                OdometerKm = odometerKm,
                AdvertisedPrice = advertisedPrice,
                Notes = notes,
                AcquiredDate = AcquiredDate,
                AvailableFlag = availableFlag
            };
            _context.Cars.Add(car);
            _context.SaveChanges();
        }

        /// <summary>
        /// Update an existing car with provided parameters
        /// </summary>
        /// <param name="id"></param>
        /// <param name="make"></param>
        /// <param name="model"></param>
        /// <param name="year"></param>
        /// <param name="odometerKm"></param>
        /// <param name="advertisedPrice"></param>
        /// <param name="notes"></param>
        /// <param name="AcquiredDate"></param>
        /// <param name="availableFlag"></param>
        public void UpdateCar(int id, string make, string model, string registration, int year, int odometerKm, decimal advertisedPrice, string? notes, DateTimeOffset AcquiredDate, bool availableFlag)
        {
            var car = _context.Cars.Single(c => c.CarId == id);
            car.Make = make;
            car.Model = model;
            car.Year = year;
            car.OdometerKm = odometerKm;
            car.AdvertisedPrice = advertisedPrice;
            car.Notes = notes;
            car.AcquiredDate = AcquiredDate;
            car.AvailableFlag = availableFlag;
            _context.SaveChanges();
        }

        /// <summary>
        /// Make a previously sold car available for sale again
        /// </summary>
        /// <param name="id"></param>
        public void ReObtainCar(int id)
        {
            var car = _context.Cars.Single(c => c.CarId == id);
            car.AvailableFlag = true;
            _context.SaveChanges();
        }

        /// <summary>
        /// Delete the car for the specified id
        /// </summary>
        /// <param name="id"></param>
        public void DeleteCar(int id)
        {
            var car = _context.Cars.Single(c => c.CarId == id);
            _context.Cars.Remove(car);
            _context.SaveChanges();
        }
    }
}
