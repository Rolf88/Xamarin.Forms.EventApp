using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zmart.EventApp.Models
{
    public class Conference
    {
        public Conference() { }

        public Conference(string name, string adress, string city, string country, string phoneNumber, string details) {
            Name = name;
            Adress = adress;
            City = city;
            Country = country;
            PhoneNumber = phoneNumber;
            Details = details;
        }

        public string Name { get; set; }
        public string Adress { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string PhoneNumber { get; set; }
        public string Details { get; set; }
    }
}
