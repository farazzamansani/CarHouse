namespace CarHouse.DataAccess.Services
{
    public class SaleService : ISaleService
    {
        private readonly CarHouseContext _context;

        public SaleService(CarHouseContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Creates the customer and returns the Id
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="driversLicenseNo"></param>
        /// <param name="contactNo"></param>
        /// <param name="email"></param>
        /// <param name="suburb"></param>
        /// <param name="postCode"></param>
        /// <returns></returns>
        public int AddCustomer(string firstName, string lastName, string driversLicenseNo, string contactNo, string email, string suburb, string postCode)
        {
            var customer = new Customer()
            {
                FirstName = firstName,
                LastName = lastName,
                DriversLicenseNo = driversLicenseNo,
                ContactNumber = contactNo,
                Email = email,
                ResidentialSuburb = suburb,
                ResidentialPostCode = postCode
            };
            _context.Add(customer);
            _context.SaveChanges();
            return customer.CustomerId;
        }

        public void SellCar(int carId, int salePrice, int customerId, string salesmanName)
        {
            var customer = _context.Customers.Single(c => c.CustomerId == customerId);
            var car = _context.Cars.Single(c => c.CarId == carId);
            var sale = new Sale()
            {
                AdvertisedPrice = car.AdvertisedPrice,
                SaleAmount = salePrice,
                SalesmanName = salesmanName,
                Car = car,
                Customer = customer
            };
            car.AvailableFlag = false;
            _context.Sales.Add(sale);
            _context.SaveChanges();
        }
    }
}
