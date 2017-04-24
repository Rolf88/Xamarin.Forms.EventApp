﻿using Acr.UserDialogs;
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

            Content = new StackLayout {
                Orientation = StackOrientation.Vertical,
                VerticalOptions = LayoutOptions.Center,
                Children = {
                    CreateLabel(),
                },
            };
            
                StartBeaconRanging();
        }

        private Label CreateLabel() {
            Label lbl = new Label();
            lbl.Text = "Please hold your device up against the beacon, until you're logged in.";
            lbl.TextColor = Color.DarkSlateBlue;
            lbl.FontFamily = "Bold";
            lbl.FontSize = 25;
            lbl.VerticalTextAlignment = TextAlignment.Center;
            lbl.HorizontalTextAlignment = TextAlignment.Center;
            lbl.HorizontalOptions = LayoutOptions.Center;
            lbl.VerticalOptions = LayoutOptions.Center;
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