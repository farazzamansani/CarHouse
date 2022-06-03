using CarHouse.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using CarHouse.DataAccess;
using CarHouse.DataAccess.Services;

namespace CarHouse.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IList<Car> _cars;
        private ICarService _carService;

        public HomeController(ILogger<HomeController> logger, ICarService carService)
        {
            _logger = logger;
            _carService = carService;
        }

        public IActionResult HomeView()
        {
            var _cars = _carService.GetCars(null,true);

            var cars = _cars.Select(c => new CarModel() { CarId = c.CarId, Make = c.Make, Model = c.Model, AdvertisedPrice = c.AdvertisedPrice, OdometerKm = c.OdometerKm, Year = c.Year}).ToList();
            
            return View(cars);
        }

        public IActionResult AddCarView()
        {
            return View();
        }

        public IActionResult SellCarView(int id)
        {
            var carDetails = _carService.GetCarDetails(id);
            return View(carDetails);
        }

        [HttpPost]
        public IActionResult AddCar(string make, string model, string registration, int year, int odometer, int advertisedPrice,DateTimeOffset acquisitionDate, string? notes)
        {
            _carService.AddCar(make,model,registration, year,odometer,advertisedPrice,notes,acquisitionDate,true);
            return RedirectToAction("HomeView");
        }

        [HttpPost]
        public IActionResult EditCar(int id,string make, string model, string registration, int year, int odometer, int advertisedPrice, DateTimeOffset acquisitionDate, string? notes)
        {
            _carService.UpdateCar(id, make, model, registration, year, odometer, advertisedPrice, notes, acquisitionDate, true);
            return RedirectToAction("HomeView");
        }

        public IActionResult CarDetailsView(int id)
        {
            var carDetails = _carService.GetCarDetails(id);
            return View(carDetails);
        }

        public IActionResult EditCarView(int id)
        {
            var carDetails = _carService.GetCarDetails(id);
            return View(carDetails);
        }

        public IActionResult DeleteCar(int id)
        {
            _carService.DeleteCar(id);
            return RedirectToAction("HomeView");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}