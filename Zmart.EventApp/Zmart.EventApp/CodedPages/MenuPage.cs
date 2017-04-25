using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Zmart.EventApp.Models;

namespace Zmart.EventApp.CodedPages
{
    public class MenuPage : ContentPage
    {
        public MenuPage() {
            MainLink forsideLink = new MainLink("Schema");
            MainLink rangingPage = new MainLink("Ranging");
            MainLink aboutPage = new MainLink("About");
            MainLink personalSchemaPage = new MainLink("Personal Schema");

            forsideLink.Clicked += ForsideLink_Clicked;
            rangingPage.Clicked += RangingPage_Clicked;
            aboutPage.Clicked += AboutPage_Clicked;
            personalSchemaPage.Clicked += PersonalSchemaPage_Clicked;

            Content = new StackLayout
            {
                Padding = new Thickness(0, Device.OnPlatform<int>(20, 0, 0), 0, 0),
                Children = {
                forsideLink,
                aboutPage,
                personalSchemaPage,
                rangingPage
            }
            };
            Title = "Master";
            BackgroundColor = Color.Gray.WithLuminosity(0.9);
            Icon = Device.OS == TargetPlatform.iOS ? "menu.png" : null;
        }

        private void PersonalSchemaPage_Clicked(object sender, EventArgs e)
        {
            App.masterDetailPage.Detail = new NavigationPage(new PersonalSchema { Title = "Personal Schema" }) { Title = "Personal Schema" };
            App.masterDetailPage.IsPresented = false;
        }

        private void AboutPage_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new NavigationPage(new AboutPage { Title = "About" }) { Title = "About" });
            App.masterDetailPage.IsPresented = false;
        }

        private void RangingPage_Clicked(object sender, EventArgs e)
        {
            App.masterDetailPage.Detail = new NavigationPage(new RangingPage { Title = "Estimotes - Ranging" }) { Title = "Ranging" };
            App.masterDetailPage.IsPresented = false;
        }

        private void ForsideLink_Clicked(object sender, EventArgs e)
        {
            App.masterDetailPage.Detail = App.tabbedPage;
            App.masterDetailPage.IsPresented = false;
        }
    }
}
