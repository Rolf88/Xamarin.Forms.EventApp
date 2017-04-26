using System;
using System.Collections.Generic;
using System.Diagnostics;
using Acr.Notifications;
using Estimotes;
using Xamarin.Forms;
using Zmart.EventApp.Models;
using Microsoft.WindowsAzure.MobileServices;
using Zmart.EventApp.CodedPages;
using Newtonsoft.Json;

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
            var conference = ConferenceMaker();

            App.Current.Properties["conference"] = JsonConvert.SerializeObject(conference);

            tabbedPage = new TabbedPage();

            foreach (var date in conference.Dates)
            {
                tabbedPage.Children.Add(new NavigationPage(new CodedMainPage(date)) { Title = date });
            }

            masterDetailPage = new MasterDetailPage
            {
                Master = new MenuPage(),
                Detail = tabbedPage,
            };
        }

        private Conference ConferenceMaker()
        {
            Conference conference = new Conference();

            conference.Name = "IT-MagicEvent";
            conference.Adress = "Blabla Parken 3";
            conference.City = "Ballerup";
            conference.Country = "Danmark";
            conference.PhoneNumber = "+45 88 88 88 88";
            conference.Details = "Blablablablablablablablablablablablablablablablablablablablablablablabla" +
                "blablablablablablablablablablablablablablablablablablablablablablablablablablabla" +
                "blablablablablablablablablablablablablablablablablablablablablablablablablablabla" +
                "blablablablablablablablablablablablablablablablablablablablablablablablablablabla" +
                "blablablablablablablablablablablablablablablablablablablablablablablablablablabla" +
                "blablablablablablablablablablablablablablablablablablablablablablablablablablabla";

            var testDates = new List<string>() { "1st Day", "2nd Day" };

            conference.SetDates(testDates);

            conference.SetEvents(CreateEventsForTest());

            return conference;
        }

        private List<EventModel> CreateEventsForTest()
        {
            List<EventModel> eventList = new List<EventModel>();

            //eventList.Add(new EventModel("BestEvent", "blablabla", "icon.png", "12:00", "13:00", "track1"));
            eventList.Add(new EventModel(1, "BestEvent", "blablablablablablablablablablablablablablablablablablablablablablablablablablablablabla" +
                "blablablablablablablablablablablablablablablablablablablablablablablablablablablablablablablablablablablablablablablablablablablabla" +
                "blablablablablablablablablablablablablablablablabla", "icon.png", "12:00", "13:00", "track2", "1st Day"));
            eventList.Add(new EventModel(2, "BestEventttttttttttttttttttttttttttttttttt", "blablabla", "icon.png", "13:00", "14:00", "track1", "1st Day"));
            eventList.Add(new EventModel(3, "BestEvent", "blablabla", "icon.png", "13:00", "14:00", "track2", "1st Day"));
            eventList.Add(new EventModel(4, "BestEvent", "blablabla", "icon.png", "14:00", "15:00", "track1", "1st Day"));
            eventList.Add(new EventModel(5, "BestEvent", "blablabla", "icon.png", "14:00", "15:00", "track2", "1st Day"));
            eventList.Add(new EventModel(6, "BestEvent", "blablabla", "icon.png", "15:00", "16:00", "track1", "2nd Day"));
            eventList.Add(new EventModel(7, "BestEvent", "blablabla", "icon.png", "15:00", "16:00", "track2", "1st Day"));
            eventList.Add(new EventModel(8, "BestEvent", "blablabla", "icon.png", "16:00", "17:00", "track1", "2nd Day"));
            eventList.Add(new EventModel(9, "BestEvent", "blablabla", "icon.png", "16:00", "17:00", "track2", "1st Day"));
            eventList.Add(new EventModel(10, "BestEvent", "blablabla", "icon.png", "17:00", "18:00", "track1", "1st Day"));
            eventList.Add(new EventModel(11, "BestEvent", "blablabla", "icon.png", "17:00", "18:00", "track2", "1st Day"));
            eventList.Add(new EventModel(12, "BestEvent", "blablabla", "icon.png", "10:00", "11:00", "track1", "2nd Day"));
            eventList.Add(new EventModel(13, "BestEvent", "blablabla", "icon.png", "10:00", "11:00", "track2", "2nd Day"));
            eventList.Add(new EventModel(14, "BestEvent", "blablabla", "icon.png", "11:00", "13:00", "track1", "1st Day"));
            eventList.Add(new EventModel(15, "BestEvent", "blablabla", "icon.png", "11:00", "12:00", "track2", "1st Day"));
            eventList.Add(new EventModel(16, "BestEvent", "blablabla", "icon.png", "01:00", "06:30", "track2", "1st Day"));

            return eventList;
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
