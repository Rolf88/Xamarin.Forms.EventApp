using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Zmart.EventApp.ViewModels;

namespace Zmart.EventApp
{
    public partial class MainPage : Acr.XamForms.ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            this.BindingContext = new MonitorViewModel();
        }
    }
}
