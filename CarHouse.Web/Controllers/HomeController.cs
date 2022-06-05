using CarHouse.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using CarHouse.DataAccess.Services;

namespace CarHouse.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ICarService _carService;
        private ISaleService _saleService;

        public HomeController(ILogger<HomeController> logger, ICarService carService, ISaleService saleService)
        {
            _logger = logger;
            _carService = carService;
            _saleService = saleService;
        }

        public IActionResult HomeView()
        {
            var cars = _carService.GetCars(true);

            var carModels = cars.Select(c => new CarModel() { CarId = c.CarId, Make = c.Make, Model = c.Model, AdvertisedPrice = c.AdvertisedPrice, OdometerKm = c.OdometerKm, Year = c.Year, AvailableFlag = c.AvailableFlag}).ToList();
            
            return View(carModels);
        }

        public IActionResult AddCarView()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult AddCar(string make, string model, string registration, int year, int odometer, int advertisedPrice,DateTimeOffset acquisitionDate, string? notes)
        {
            _carService.AddCar(make,model,registration, year,odometer,advertisedPrice,notes,acquisitionDate,true);
            return RedirectToAction("HomeView");
        }

        [HttpPost]
        public IActionResult EditCar(int id,string make, string model, string registration, int year, int odometer, decimal advertisedPrice, DateTimeOffset acquisitionDate, string? notes)
        {
            _carService.UpdateCar(id, make, model, registration, year, odometer, advertisedPrice, notes, acquisitionDate, true);
            return RedirectToAction("HomeView");
        }
        public IActionResult CarSearchView(string? make, string? model, string? registration, int? year, int? minimumPrice, decimal? maximumPrice, bool availableOnly)
        {
            var cars = _carService.GetCars(registration,make,model,minimumPrice,maximumPrice, availableOnly);

            var carModels = cars.Select(c => new CarModel() { CarId = c.CarId, Make = c.Make, Model = c.Model, AdvertisedPrice = c.AdvertisedPrice, OdometerKm = c.OdometerKm, Year = c.Year, AvailableFlag = c.AvailableFlag}).ToList();

            return View(carModels);
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

        public IActionResult ReObtainCar(int id)
        {
            _carService.ReObtainCar(id);
            return RedirectToAction("CarDetailsView", new { id = id});
        }

        public IActionResult DeleteCar(int id)
        {
            _carService.DeleteCar(id);
            return RedirectToAction("HomeView");
        }

        public ActionResult SellCar(int id, int salePrice, string salesmanName, string firstName, string lastName, string licenseNo, string contactNo, string email, string suburb, string postCode )
        {
            //ToDo: We are making a new customer for every sale, it would be better to implement a UI process to link to an existing/returning customer

            var customerId = _saleService.AddCustomer(firstName,lastName,licenseNo, contactNo,email,suburb,postCode);
            _saleService.SellCar(id,salePrice,customerId,salesmanName);
            return RedirectToAction("CarDetailsView",new {id = id});
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}