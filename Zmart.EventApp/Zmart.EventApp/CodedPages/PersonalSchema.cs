using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Zmart.EventApp.Handlers;
using Zmart.EventApp.Models;

namespace Zmart.EventApp.CodedPages
{
    public class PersonalSchema : ContentPage
    {
        SchemaHandler schemaHandler;

        public PersonalSchema() {

            Title = "Personal Schema";
            
            schemaHandler = new SchemaHandler();

            Grid calendarGrid = new Grid();

            calendarGrid.Padding = 2;

            //Adds rows
            for (int i = 0; i < 26; i++)
            {
                RowDefinition rowDef = new RowDefinition();
                rowDef.Height = 30;

                calendarGrid.RowDefinitions.Add(rowDef);
            }

            //Adds Columns
            calendarGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = 45 });
            calendarGrid.ColumnDefinitions.Add(new ColumnDefinition());
            calendarGrid.ColumnDefinitions.Add(new ColumnDefinition());

            //Adds hours to the calendar
            int hours = 0;

            for (int i = 0; i < 49; i++)
            {

                if (i % 2 == 0)
                {
                    StackLayout stackLay = new StackLayout
                    {
                        Children = {
                        new Label { Text = hours + ":00", HeightRequest = 30, BackgroundColor = Color.White, HorizontalTextAlignment = TextAlignment.Center,
                            VerticalTextAlignment = TextAlignment.Center, VerticalOptions = LayoutOptions.CenterAndExpand,
                            HorizontalOptions = LayoutOptions.FillAndExpand},
                    },
                        BackgroundColor = Color.Black,
                        Padding = 1,
                        HorizontalOptions = LayoutOptions.FillAndExpand,
                    };

                    calendarGrid.Children.Add(stackLay, 0, i + 1);
                }
                else
                {
                    calendarGrid.Children.Add(new StackLayout
                    {
                        Children = {
                        new Label { Text = hours + ":30", HeightRequest = 30, BackgroundColor = Color.White, HorizontalTextAlignment = TextAlignment.Center,
                            VerticalTextAlignment = TextAlignment.Center, VerticalOptions = LayoutOptions.CenterAndExpand,
                            HorizontalOptions = LayoutOptions.FillAndExpand},
                    },
                        BackgroundColor = Color.Black,
                        Padding = 1,
                        HorizontalOptions = LayoutOptions.FillAndExpand
                    }, 0, i + 1);
                    hours++;
                }

            }

            //Adds Column headers
            calendarGrid.Children.Add(new StackLayout
            {
                Children = {
                    new Label{ Text = "Track 1", FontSize = 20, FontAttributes = FontAttributes.Bold,
                        HorizontalTextAlignment = TextAlignment.Center}
                },
            }, 1, 0);

            calendarGrid.Children.Add(new StackLayout
            {
                Children = {
                    new Label{ Text = "Track 2", FontSize = 20, FontAttributes = FontAttributes.Bold,
                        HorizontalTextAlignment = TextAlignment.Center}
                },
            }, 2, 0);

            List<EventModel> eventList = new List<EventModel>();

            if (Application.Current.Properties.ContainsKey("personalSchema")) {
                eventList = JsonConvert.DeserializeObject<List<EventModel>>(Application.Current.Properties["personalSchema"].ToString());

                //Count For Event Color
                int count = 0;
                int count2 = 0;
                //Add events to calendar.
                foreach (var item in eventList)
                {

                    if (item.Track.Equals("track1"))
                    {
                        count++;
                        calendarGrid.Children.Add(new StackLayout
                        {
                            Orientation = StackOrientation.Horizontal,
                            BackgroundColor = schemaHandler.CalendarColorManager(count),
                            Children = { new Label { Text = schemaHandler.TruncateTitle(item.Name) + "\n" + item.StartTime + "\n  -\n" + item.StopTime }, new Image { Source = "icon.png", HeightRequest = 29, WidthRequest = 29, HorizontalOptions = LayoutOptions.EndAndExpand, VerticalOptions = LayoutOptions.Start } },
                            GestureRecognizers = { new TapGestureRecognizer {
                            Command = new Command(()=> App.masterDetailPage.Detail = new NavigationPage(new EventDetailPage(item, true))),
                        } },
                        }, 1, 2, schemaHandler.ConvertStartTimeToRows(item.StartTime), schemaHandler.ConvertStartTimeToRows(item.StartTime) + schemaHandler.ConvertStopTimeToRows(item.StopTime, item.StartTime));
                    }
                    else
                    {
                        count2++;
                        calendarGrid.Children.Add(new StackLayout
                        {
                            Orientation = StackOrientation.Horizontal,
                            BackgroundColor = schemaHandler.CalendarColorManager2(count2),
                            Children = { new Label { Text = schemaHandler.TruncateTitle(item.Name) + "\n" + item.StartTime + "\n  -\n" + item.StopTime }, new Image { Source = "icon.png", HeightRequest = 29, WidthRequest = 29, HorizontalOptions = LayoutOptions.EndAndExpand, VerticalOptions = LayoutOptions.Start } },
                            GestureRecognizers = { new TapGestureRecognizer {
                            Command = new Command(()=> App.masterDetailPage.Detail = new NavigationPage(new EventDetailPage(item, true))),
                        } },
                        }, 2, 3, schemaHandler.ConvertStartTimeToRows(item.StartTime), schemaHandler.ConvertStartTimeToRows(item.StartTime) + schemaHandler.ConvertStopTimeToRows(item.StopTime, item.StartTime));
                    }
                }
            }
            else
            {
                DisplayAlert("","You haven't added any events yet, go to main page and tab an event to add it to your personal schema","Ok");
            }

            Content = new ScrollView
            {
                Content = calendarGrid,
            };
        }

        

    }
}
