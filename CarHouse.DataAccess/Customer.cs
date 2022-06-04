using System;
using System.Collections.Generic;

namespace CarHouse.DataAccess
{
    public partial class Customer
    {
        public Customer()
        {
            Sales = new HashSet<Sale>();
        }

        public int CustomerId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string DriversLicenseNo { get; set; } = null!;
        public string ContactNumber { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string ResidentialSuburb { get; set; } = null!;
        public string ResidentialPostCode { get; set; } = null!;

        public virtual ICollection<Sale> Sales { get; set; }
    }
}
