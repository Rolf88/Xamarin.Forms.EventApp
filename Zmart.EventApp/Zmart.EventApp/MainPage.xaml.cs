using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Zmart.EventApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            Title = "Event App";
            var label = new Label() {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                FontSize = 20,
                FontAttributes = FontAttributes.Bold,
                TextColor = Color.Black,
                VerticalTextAlignment = TextAlignment.Center,
                HorizontalTextAlignment = TextAlignment.Center,
                Text = "Please Wait While Redirecting..."
            };
            Content = label;
            ChoosePageAsync();
        }

        private async void ChoosePageAsync()
        {
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
    }
}
