namespace CarHouse.DataAccess.Services;

public interface ICarService
{
    /// <summary>
    /// Returns list of cars filterable by given parameters
    /// </summary>
    /// <param name="registrationNumber"></param>
    /// <param name="availableCarsOnly"></param>
    /// <returns></returns>
    public IList<Car> GetCars(string? registrationNumber, string? make, string? model, decimal? minPrice,
        decimal? maxPrice, bool availableCarsOnly);

    /// <summary>
        /// Return list of all cars
        /// </summary>
        /// <param name="availableCarsOnly"></param>
        /// <returns></returns>
        public IList<Car> GetCars(bool availableCarsOnly);

    public Car GetCarDetails(int id);

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
    void AddCar(string make, string model, string registration, int year, int odometerKm, decimal advertisedPrice, string? notes, DateTimeOffset AcquiredDate, bool availableFlag);

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
    void UpdateCar(int id, string make, string model, string registration, int year, int odometerKm, decimal advertisedPrice, string? notes, DateTimeOffset AcquiredDate, bool availableFlag);

    /// <summary>
    /// Make a previously sold car available for sale again
    /// </summary>
    /// <param name="id"></param>
    void ReObtainCar(int id);

    /// <summary>
    /// Delete the car for the specified id
    /// </summary>
    /// <param name="id"></param>
    public void DeleteCar(int id);
}