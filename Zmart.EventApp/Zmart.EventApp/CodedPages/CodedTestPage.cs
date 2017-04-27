using Acr.UserDialogs;
using Estimotes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Zmart.EventApp.CodedPages
{
    public class CodedTestPage : ContentPage
    {
        public CodedTestPage() {
            Title = "Registration";

            Content = new StackLayout
            {
                BackgroundColor = Color.White,
                Orientation = StackOrientation.Vertical,
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Children = {
                    new StackLayout{
                        BackgroundColor = Color.White,
                        Orientation = StackOrientation.Vertical,
                        VerticalOptions = LayoutOptions.CenterAndExpand,
                        HorizontalOptions = LayoutOptions.CenterAndExpand,
                        Children={
                            CreateLabel(),
                            CreateImage()
                        }
                    },
                }
            };

            //StartBeaconRanging();
            Application.Current.Properties["firstLogin"] = "true";
            Application.Current.MainPage = App.masterDetailPage;
            //UserDialogs.Instance.Alert("Welcome for the first time!!!!", "Welcome Message Box");
        }

        private Image CreateImage() {
            Image img = new Image();
            img.Source = "conference.png";
            img.HorizontalOptions = LayoutOptions.CenterAndExpand;
            img.VerticalOptions = LayoutOptions.CenterAndExpand;
            return img;
        }

        private Label CreateLabel() {
            Label lbl = new Label();
            lbl.Text = "Enter conference to use app.";
            lbl.TextColor = Color.DarkSlateBlue;
            lbl.FontFamily = "Bold";
            lbl.FontSize = 25;
            lbl.VerticalTextAlignment = TextAlignment.Center;
            lbl.HorizontalTextAlignment = TextAlignment.Center;
            lbl.HorizontalOptions = LayoutOptions.CenterAndExpand;
            lbl.VerticalOptions = LayoutOptions.CenterAndExpand;
            return lbl;
        }

        private async void StartBeaconRanging() {
            EstimoteManager.Instance.Ranged += Instance_Ranged;
            var status = await EstimoteManager.Instance.Initialize();
            if (status != BeaconInitStatus.Success)
                UserDialogs.Instance.Alert($"Beacon functionality failed - {status}");
            else
            {
                foreach (var region in App.Regions)
                    EstimoteManager.Instance.StartRanging(region);
            }
        }

        private void Instance_Ranged(object sender, IEnumerable<IBeacon> e)
        {
            foreach (var beacon in e)
            {
                if ((beacon.Proximity == Proximity.Immediate || beacon.Proximity == Proximity.Near) && !Application.Current.Properties.ContainsKey("firstLogin"))
                {
                    Application.Current.Properties["firstLogin"] = "true";
                    Application.Current.MainPage = App.masterDetailPage;
                    UserDialogs.Instance.Alert("Welcome for the first time!!!!", "Welcome Message Box");
                    EstimoteManager.Instance.StopAllRanging();
                }
            }
        }
    }
}
