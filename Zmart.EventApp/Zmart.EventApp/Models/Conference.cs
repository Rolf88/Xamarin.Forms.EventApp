using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zmart.EventApp.Models
{
    public class Conference
    {
        public Conference() {
            Dates = new List<string>();
            Events = new List<EventModel>();
        }

        public Conference(string name, string adress, string city, string country, string phoneNumber, string details, List<string> dates) {
            Dates = new List<string>();
            Events = new List<EventModel>();
            Name = name;
            Adress = adress;
            City = city;
            Country = country;
            PhoneNumber = phoneNumber;
            Details = details;
            Dates.Clear();
            Dates.AddRange(dates);
        }

        public string Name { get; set; }
        public string Adress { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string PhoneNumber { get; set; }
        public string Details { get; set; }
        public List<string> Dates { get; }
        public List<EventModel> Events { get; }

        public void SetEvents(List<EventModel> events) {
            Events.Clear();
            Events.AddRange(events);
        }

        public void SetDates(List<string> dates) {
            Dates.Clear();
            Dates.AddRange(dates);
        }
    }
}
