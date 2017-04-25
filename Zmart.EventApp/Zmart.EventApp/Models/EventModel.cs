using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zmart.EventApp.Models
{
    public class EventModel
    {
        public EventModel(int id, string name, string description, string image, string startTime, string stopTime, string track) {
            Id = id;
            Name = name;
            Description = description;
            Image = image;
            StartTime = startTime;
            StopTime = stopTime;
            Track = track;
        }

        public int Id { get; set; }
        public string Description { get; set; }
        public string StartTime { get; set; }
        public string StopTime { get; set; }
        public string Image { get; set; }
        public string Name { get; set; }
        public string Track { get; set; }

        public override bool Equals(object obj)
        {
            EventModel eventModel = obj as EventModel;
            if (this.Id == eventModel.Id) {
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
