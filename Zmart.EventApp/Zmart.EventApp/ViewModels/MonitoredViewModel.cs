using Acr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zmart.EventApp.Models;

namespace Zmart.EventApp.ViewModels
{
    public class MonitoredViewModel : ViewModel
    {

        public MonitoredViewModel(BeaconPing model)
        {
            this.Information = $"{model.Type}  {model.Identifier}";
            this.Details = $"M: {model.Major} - m: {model.Minor} - {model.DateCreated:g}";
        }


        public string Information { get; }
        public string Details { get; }
    }
}
