using System;
using System.Collections.Generic;
using System.Text;

namespace WGUCapstoneProject.Models
{
    public class Address
    {
        public int AddressId { get; set; }
        public int AddressNumber { get; set; }
        public string StreetName { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int ZipCode { get; set; }
    }
}
