using System;
using System.Collections.Generic;

namespace CarHouse.DataAccess
{
    public partial class Car
    {
        public Car()
        {
            Sales = new HashSet<Sale>();
        }

        public int CarId { get; set; }
        public string RegistrationNumber { get; set; } = null!;
        public string Make { get; set; } = null!;
        public string Model { get; set; } = null!;
        public int Year { get; set; }
        public int OdometerKm { get; set; }
        public decimal AdvertisedPrice { get; set; }
        public string? Notes { get; set; }
        public DateTimeOffset AcquiredDate { get; set; }
        public bool AvailableFlag { get; set; }

        public virtual ICollection<Sale> Sales { get; set; }
    }
}
