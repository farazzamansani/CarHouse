using System;
using System.Collections.Generic;

namespace CarHouse.DataAccess
{
    public partial class Sale
    {
        public int SaleId { get; set; }
        public decimal AdvertisedPrice { get; set; }
        public decimal SaleAmount { get; set; }
        public string SalesmanName { get; set; } = null!;
        public int CarId { get; set; }
        public int CustomerId { get; set; }
    }
}
