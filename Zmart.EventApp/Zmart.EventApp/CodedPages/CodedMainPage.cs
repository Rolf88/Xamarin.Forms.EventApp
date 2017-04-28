using Acr.UserDialogs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Zmart.EventApp.Handlers;
using Zmart.EventApp.Models;
using Zmart.EventApp.ViewModels;

namespace Zmart.EventApp.CodedPages
{
    public class CodedMainPage : ContentPage
    {
        //public ObservableCollection<EventModel> eventItems { get; set; }
        SchemaHandler _schemaHandler;
        List<EventModel> events;

        public CodedMainPage(string date) {

            Title = "It-Conference";

            events = new List<EventModel>();
            var conference = JsonConvert.DeserializeObject<Conference>(App.Current.Properties["conference"].ToString());

            foreach (var eventItem in conference.Events)
            {
                if (eventItem.Date.Equals(date)) {
                    events.Add(eventItem);
                }
            }

            _schemaHandler = new SchemaHandler();

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
                        new Label { Text = hours + ":00", HeightRequest = 30, FontSize = 10, BackgroundColor = Color.White, HorizontalTextAlignment = TextAlignment.Center,
                            VerticalTextAlignment = TextAlignment.Center, VerticalOptions = LayoutOptions.CenterAndExpand,
                            HorizontalOptions = LayoutOptions.FillAndExpand},
                    },
                        BackgroundColor = Color.Black,
                        Padding = 1,
                        HorizontalOptions = LayoutOptions.FillAndExpand,
                    };

                    calendarGrid.Children.Add(stackLay, 0, i + 1);
                }
                else {
                    calendarGrid.Children.Add(new StackLayout
                    {
                        Children = {
                        new Label { Text = hours + ":30", HeightRequest = 30, FontSize = 10, BackgroundColor = Color.White, HorizontalTextAlignment = TextAlignment.Center,
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
            calendarGrid.Children.Add(new StackLayout {
                Children = {
                    new Label{ Text = "Track 1", FontSize = 20, FontAttributes = FontAttributes.Bold, HorizontalTextAlignment = TextAlignment.Center}
                },
            }, 1, 0);

            calendarGrid.Children.Add(new StackLayout
            {
                Children = {
                    new Label{ Text = "Track 2", FontSize = 20, FontAttributes = FontAttributes.Bold, HorizontalTextAlignment = TextAlignment.Center}
                },
            }, 2, 0);
            
            //Count For Event Color
            int count = 0;
            int count2 = 0;
            //Add events to calendar.
            foreach (var item in events) {
                
                if (item.Track.Equals("track1"))
                {
                    count++;
                    calendarGrid.Children.Add(new StackLayout {
                        Orientation = StackOrientation.Horizontal,
                        BackgroundColor = _schemaHandler.CalendarColorManager(count),
                        Children = { new Label {FontSize = 10, Text = _schemaHandler.TruncateTitle(item.Name) + "\n" 
                        + item.StartTime + "\n  -\n" + item.StopTime},
                            new Image { Source = "icon.png", HeightRequest = 20, WidthRequest = 20,
                                HorizontalOptions = LayoutOptions.EndAndExpand,
                                VerticalOptions = LayoutOptions.Start }
                        },
                        GestureRecognizers = { new TapGestureRecognizer {
                            Command = new Command(()=> App.masterDetailPage.Detail = new NavigationPage(new EventDetailPage(item, false)){ BarBackgroundColor = Color.Green}),
                        }
                        },
                    }, 1, 2, _schemaHandler.ConvertStartTimeToRows(item.StartTime), 
                    _schemaHandler.ConvertStartTimeToRows(item.StartTime) + _schemaHandler.ConvertStopTimeToRows(item.StopTime, item.StartTime));
                }
                else {
                    count2++;
                    calendarGrid.Children.Add(new StackLayout {
                        Orientation = StackOrientation.Horizontal,
                        BackgroundColor = _schemaHandler.CalendarColorManager2(count2),
                        Children = { new Label {FontSize = 10, Text = _schemaHandler.TruncateTitle(item.Name) + "\n" 
                        + item.StartTime + "\n  -\n" + item.StopTime},
                            new Image { Source = "icon.png", HeightRequest = 20, WidthRequest = 20,
                                HorizontalOptions = LayoutOptions.EndAndExpand,
                                VerticalOptions = LayoutOptions.Start }
                        },
                        GestureRecognizers = { new TapGestureRecognizer {
                            Command = new Command(()=> App.masterDetailPage.Detail = new NavigationPage(new EventDetailPage(item, false)){ BarBackgroundColor = Color.Green}),
                        }
                        },
                    }, 2, 3, _schemaHandler.ConvertStartTimeToRows(item.StartTime), 
                    _schemaHandler.ConvertStartTimeToRows(item.StartTime) + _schemaHandler.ConvertStopTimeToRows(item.StopTime, item.StartTime));
                }
            }

            Content = new ScrollView {
                Content = calendarGrid,
            };

            //Save this bit of code to show different visual possibillities.
            //eventItems = new ObservableCollection<EventViewModel>();
            //ListView listView = new ListView();
            //listView.RowHeight = 100;
            //listView.ItemTemplate = new DataTemplate(typeof(CustomEventCell));
            //eventItems.Add(new EventViewModel { Name = "BestEvent", StartTime = "18:00", StopTime = "19:00", Image = "icon.png", Description = "blablablablablablablablablablablablablablablablablablablablablablablablablablablablablabla..."});
            //eventItems.Add(new EventViewModel { Name = "BestEvent", StartTime = "18:00", StopTime = "19:00", Image = "icon.png", Description = "blablabla..." });
            //eventItems.Add(new EventViewModel { Name = "BestEvent", StartTime = "18:00", StopTime = "19:00", Image = "icon.png", Description = "blablabla..." });
            //eventItems.Add(new EventViewModel { Name = "BestEvent", StartTime = "18:00", StopTime = "19:00", Image = "icon.png", Description = "blablabla..." });
            //eventItems.Add(new EventViewModel { Name = "BestEvent", StartTime = "18:00", StopTime = "19:00", Image = "icon.png", Description = "blablabla..." });
            //eventItems.Add(new EventViewModel { Name = "BestEvent", StartTime = "18:00", StopTime = "19:00", Image = "icon.png", Description = "blablabla..." });
            //eventItems.Add(new EventViewModel { Name = "BestEvent", StartTime = "18:00", StopTime = "19:00", Image = "icon.png", Description = "blablabla..." });
            //eventItems.Add(new EventViewModel { Name = "BestEvent", StartTime = "18:00", StopTime = "19:00", Image = "icon.png", Description = "blablabla..." });
            //eventItems.Add(new EventViewModel { Name = "BestEvent", StartTime = "18:00", StopTime = "19:00", Image = "icon.png", Description = "blablabla..." });
            //eventItems.Add(new EventViewModel { Name = "BestEvent", StartTime = "18:00", StopTime = "19:00", Image = "icon.png", Description = "blablabla..." });
            //eventItems.Add(new EventViewModel { Name = "BestEvent", StartTime = "18:00", StopTime = "19:00", Image = "icon.png", Description = "blablabla..." });
            //eventItems.Add(new EventViewModel { Name = "BestEvent", StartTime = "18:00", StopTime = "19:00", Image = "icon.png", Description = "blablabla..." });
            //eventItems.Add(new EventViewModel { Name = "BestEvent", StartTime = "18:00", StopTime = "19:00", Image = "icon.png", Description = "blablabla..." });
            //eventItems.Add(new EventViewModel { Name = "BestEvent", StartTime = "18:00", StopTime = "19:00", Image = "icon.png", Description = "blablabla..." });
            //listView.ItemsSource = eventItems;

            //listView.ItemTapped += async (sender, e) =>
            //{
            //    var eventItem = e.Item as EventViewModel;

            //    await Navigation.PushModalAsync(new NavigationPage(new EventDetailPage(eventItem)));
            //};

            //Content = listView;
        }

        //For Truncating details if details should be shown in mainpage.
        //private string TruncateWord(string description) {
        //    var charArr = description.ToCharArray();
        //    var result = "";

        //    if (charArr.Length >= 6)
        //    {
        //        for (int i = 0; i < charArr.Length; i++)
        //        {
        //            if (i == 15) {
        //                result += "...";
        //                break;
        //            }

        //            result += charArr[i].ToString();

        //            if (i != 0 && i%6 == 0) {
        //                result += "\n";
        //            }
        //        }
        //    }
        //    else {
        //        result = description;
        //    }

        //    return result;
        //}

        private List<EventModel> CreateEventsForTest() {
            List<EventModel> eventList = new List<EventModel>();

            //eventList.Add(new EventModel("BestEvent", "blablabla", "icon.png", "12:00", "13:00", "track1"));
            eventList.Add(new EventModel(1, "BestEvent", "blablablablablablablablablablablablablablablablablablablablablablablablablablablablabla" +
                "blablablablablablablablablablablablablablablablablablablablablablablablablablablablablablablablablablablablablablablablablablablabla" +
                "blablablablablablablablablablablablablablablablabla", "icon.png", "12:00", "13:00", "track2", "1st day"));
            eventList.Add(new EventModel(2, "BestEventttttttttttttttttttttttttttttttttt", "blablabla", "icon.png", "13:00", "14:00", "track1", "1st day"));
            eventList.Add(new EventModel(3, "BestEvent", "blablabla", "icon.png", "13:00", "14:00", "track2", "1st day"));
            eventList.Add(new EventModel(4, "BestEvent", "blablabla", "icon.png", "14:00", "15:00", "track1", "1st day"));
            eventList.Add(new EventModel(5, "BestEvent", "blablabla", "icon.png", "14:00", "15:00", "track2", "1st day"));
            eventList.Add(new EventModel(6, "BestEvent", "blablabla", "icon.png", "15:00", "16:00", "track1", "2nd day"));
            eventList.Add(new EventModel(7, "BestEvent", "blablabla", "icon.png", "15:00", "16:00", "track2", "1st day"));
            eventList.Add(new EventModel(8, "BestEvent", "blablabla", "icon.png", "16:00", "17:00", "track1", "2nd day"));
            eventList.Add(new EventModel(9, "BestEvent", "blablabla", "icon.png", "16:00", "17:00", "track2", "1st day"));
            eventList.Add(new EventModel(10, "BestEvent", "blablabla", "icon.png", "17:00", "18:00", "track1", "1st day"));
            eventList.Add(new EventModel(11, "BestEvent", "blablabla", "icon.png", "17:00", "18:00", "track2", "1st day"));
            eventList.Add(new EventModel(12, "BestEvent", "blablabla", "icon.png", "10:00", "11:00", "track1", "2nd day"));
            eventList.Add(new EventModel(13, "BestEvent", "blablabla", "icon.png", "10:00", "11:00", "track2", "2nd day"));
            eventList.Add(new EventModel(14, "BestEvent", "blablabla", "icon.png", "11:00", "13:00", "track1", "1st day"));
            eventList.Add(new EventModel(15, "BestEvent", "blablabla", "icon.png", "11:00", "12:00", "track2", "1st day"));
            eventList.Add(new EventModel(16, "BestEvent", "blablabla", "icon.png", "01:00", "06:30", "track2", "1st day"));

            return eventList;
        }

        //For a TableView instead of the calendar Gridview.
        //private ViewCell MakeTable() {
        //    //var table = new TableView() { Intent = TableIntent.Menu };
        //    //var root = new TableRoot();
        //    //var section1 = new TableSection();

        //    //var text = new TextCell { Detail = "TextCell Detail" };
        //    //var image = new ImageCell { Detail = "ImageCell Detail", ImageSource = "icon.png" };

        //    var viewCell = new ViewCell {
        //        View = new StackLayout {
        //            Orientation = StackOrientation.Horizontal,
        //            VerticalOptions = LayoutOptions.FillAndExpand,
        //            HorizontalOptions = LayoutOptions.FillAndExpand,
        //            Children = {
        //                new Label {
        //                    Text = "18:30",
        //                    FontSize = 15,
        //                    VerticalTextAlignment = TextAlignment.Center,
        //                    VerticalOptions = LayoutOptions.Center
        //                },
        //                new Image{
        //                    Source = "icon.png",
        //                    IsVisible = true,
        //                    HeightRequest = 90,
        //                    WidthRequest = 90
        //                },
        //                new Label{
        //                    Text = "Some Very important text...",
        //                    VerticalTextAlignment = TextAlignment.Center,
        //                    VerticalOptions = LayoutOptions.Center
        //                }
        //            },
        //        }  
        //    };

        //    //section1.Add(viewCell);

        //    //section1.Add(text);
        //    //section1.Add(image);

        //    //section2.Add(text);
        //    //section2.Add(image);

        //    //section3.Add(text);
        //    //section3.Add(image);

        //    //section4.Add(text);
        //    //section4.Add(image);

        //    //section5.Add(text);
        //    //section5.Add(image);

        //    //table.Root = root;

        //    //root.Add(section1);
        //    //root.Add(section1);
        //    //root.Add(section1);
        //    //root.Add(section1);
        //    //root.Add(section1);
        //    //root.Add(section1);
        //    //root.Add(section1);
        //    //root.Add(section1);
        //    //root.Add(section1);
        //    //root.Add(section1);
        //    //root.Add(section1);
        //    //root.Add(section1);
        //    //root.Add(section1);
        //    //root.Add(section1);
        //    //root.Add(section1);
        //    //root.Add(section1);
        //    //root.Add(section1);
        //    //root.Add(section1);
        //    //root.Add(section1);
        //    //root.Add(section1);

        //    return viewCell;
        //}
    }
}
