using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zmart.EventApp.ViewModels
{
    public class EventViewModel
    {
        public string Description { get; set; }
        public string StartTime { get; set; }
        public string StopTime { get; set; }
        public string Image { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
