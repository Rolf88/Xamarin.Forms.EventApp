using System;
using System.Collections.Generic;
using System.Diagnostics;
using Acr.Notifications;
using Estimotes;
using Xamarin.Forms;
using Zmart.EventApp.Models;
using Microsoft.WindowsAzure.MobileServices;
using Zmart.EventApp.CodedPages;

namespace Zmart.EventApp
{
    public partial class App : Application
    {
        public static bool IsBackgrounded { get; private set; }

        //List of beacons to check for.
        public static IList<BeaconRegion> Regions { get; } = new List<BeaconRegion> {
            new BeaconRegion("estimote",  "2AA96926-CB2E-A712-EDA1-4F248F971AD9", 6983, 12188)
        };

        //Pages to be used again and again
        public static MasterDetailPage masterDetailPage;
        public static TabbedPage tabbedPage;

        public App()
        {
            //Creates the Main Pages used in the app
            CreateMainPages();

            //Chooses which page on startup
            StartUpNavigation();
        }

        private void StartUpNavigation() {
            if (Application.Current.Properties.ContainsKey("firstLogin"))
            {
                Application.Current.MainPage = masterDetailPage;
            }
            else
            {
                Application.Current.MainPage = new NavigationPage(new CodedTestPage());
            }
        }

        private void CreateMainPages() {
            var testList = new List<string>() { "1st Day", "2nd Day" };
            tabbedPage = new TabbedPage();
            foreach (var item in testList)
            {
                tabbedPage.Children.Add(new NavigationPage(new CodedMainPage(item)) { Title = item });
            }
            masterDetailPage = new MasterDetailPage
            {
                Master = new MenuPage(),
                Detail = tabbedPage,
            };
        }

        protected override void OnStart()
        {
            base.OnStart();
            App.IsBackgrounded = false; 
        }

        protected override void OnSleep()
        {
            base.OnSleep();
            App.IsBackgrounded = true;
            EstimoteManager.Instance.StopAllRanging();
        }

        protected override void OnResume()
        {
            base.OnResume();
            App.IsBackgrounded = false;
        }
    }
}
