using Newtonsoft.Json;
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

            forsideLink.GestureRecognizers.Add(new TapGestureRecognizer{Command = new Command(() => ForsideLink_Clicked())});

            rangingPage.GestureRecognizers.Add(new TapGestureRecognizer { Command = new Command(() => RangingPage_Clicked()) });
            aboutPage.GestureRecognizers.Add(new TapGestureRecognizer { Command = new Command(() => AboutPage_Clicked()) });
            personalSchemaPage.GestureRecognizers.Add(new TapGestureRecognizer { Command = new Command(() => PersonalSchemaPage_Clicked()) });

            Content = new StackLayout
            {
                //Padding = new Thickness(0, Device.OnPlatform<int>(20, 0, 0), 0, 0),
                Children = {
                    new StackLayout{
                        Padding = new Thickness(0,20,0,10),
                        Orientation = StackOrientation.Horizontal,
                        HorizontalOptions = LayoutOptions.FillAndExpand,
                        BackgroundColor = Color.White,
                      Children = {
                            new Image{
                        Source = "conference.png",
                        HeightRequest = 50,
                        WidthRequest = 50
                            },
                        },
                    },
                forsideLink,
                aboutPage,
                personalSchemaPage,
                rangingPage
            }
            };
            Title = "Menu";
            BackgroundColor = Color.Gray.WithLuminosity(0.9);
            Icon = Device.OS == TargetPlatform.iOS ? "menu.png" : null;
        }

        private void PersonalSchemaPage_Clicked()
        {
            TabbedPage tabbedPage = new TabbedPage();
            var conference = JsonConvert.DeserializeObject<Conference>(App.Current.Properties["conference"].ToString());
            foreach (var date in conference.Dates)
            {
                tabbedPage.Children.Add(new NavigationPage(new PersonalSchema(date)) { Title = date });
            }

            App.masterDetailPage.Detail = tabbedPage;
            App.masterDetailPage.IsPresented = false;
        }

        private void AboutPage_Clicked()
        {
            App.masterDetailPage.Detail = new NavigationPage(new AboutPage { Title = "About" }) { Title = "About" };
            App.masterDetailPage.IsPresented = false;
        }

        private void RangingPage_Clicked()
        {
            App.masterDetailPage.Detail = new NavigationPage(new RangingPage { Title = "Estimotes - Ranging" }) { Title = "Ranging" };
            App.masterDetailPage.IsPresented = false;
        }

        private void ForsideLink_Clicked()
        {
            App.masterDetailPage.Detail = App.tabbedPage;
            App.masterDetailPage.IsPresented = false;
        }
    }
}
