using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Zmart.EventApp.CodedPages;

namespace Zmart.EventApp.Models
{
    public class MainLink : Button
    {
        public MainLink(string name)
        {
            Text = name;
            //Command = new Command(o => {
            //    App.masterDetailPage.Detail = new NavigationPage(new RangingPage { Title = "Estimotes - Ranging" }) { Title = "Ranging" };
            //    App.masterDetailPage.IsPresented = false;
            //});
        }
    }
}
