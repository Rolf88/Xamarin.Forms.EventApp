using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zmart.EventApp.Models
{
    public class EventModel
    {
        public EventModel(string name, string description, string image, string startTime, string stopTime, string track) {
            Name = name;
            Description = description;
            Image = image;
            StartTime = startTime;
            StopTime = stopTime;
            Track = track;
        }

        public string Description { get; set; }
        public string StartTime { get; set; }
        public string StopTime { get; set; }
        public string Image { get; set; }
        public string Name { get; set; }
        public string Track { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
