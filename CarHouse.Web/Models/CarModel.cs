namespace CarHouse.Web.Models
{
    public class CarModel
    {
        public int CarId { get; set; }
        public string Make { get; set; } = null!;
        public string Model { get; set; } = null!;
        public int Year { get; set; }
        public int OdometerKm { get; set; }
        public decimal AdvertisedPrice { get; set; }
    }
}
