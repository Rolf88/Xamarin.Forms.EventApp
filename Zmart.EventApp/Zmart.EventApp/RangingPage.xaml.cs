using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Zmart.EventApp.ViewModels;

namespace Zmart.EventApp
{
    public partial class RangingPage : Acr.XamForms.ContentPage
    {

        public RangingPage()
        {
            InitializeComponent();
            this.BindingContext = new RangingViewModel();
        }
    }
}
