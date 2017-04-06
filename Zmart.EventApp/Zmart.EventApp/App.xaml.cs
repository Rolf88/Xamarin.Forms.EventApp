using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Zmart.EventApp
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            if (Application.Current.Properties.ContainsKey("token"))
            {
                //await Navigation.PushAsync(new CodedPages.CodedMainPage());
                Application.Current.MainPage = new NavigationPage(new CodedPages.CodedMainPage());
            }
            else
            {
                //LoginPage logPage = new LoginPage();
                //await Navigation.PushAsync(logPage);
                Application.Current.MainPage = new NavigationPage(new LoginPage());
            }
        }

        protected override void OnStart()
        {
            
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
