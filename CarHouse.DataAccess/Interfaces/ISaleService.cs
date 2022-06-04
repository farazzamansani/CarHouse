namespace CarHouse.DataAccess.Services;

public interface ISaleService
{
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
    int AddCustomer(string firstName, string lastName, string driversLicenseNo, string contactNo, string email, string suburb, string postCode);

    void SellCar(int carId, int salePrice, int customerId, string salesmanName);
}