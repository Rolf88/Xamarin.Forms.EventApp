using Acr.UserDialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Zmart.EventApp.Models;
using Zmart.EventApp.ViewModels;

namespace Zmart.EventApp.CodedPages
{
    public class CodedMainPage : ContentPage
    {
        //public ObservableCollection<EventModel> eventItems { get; set; }

        public CodedMainPage(string title) {

            Title = title;

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

            for (int i = 0; i < 50; i++)
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
                else {
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

            //EventList for tests
            var eventList = CreateEventsForTest();

            //Add events to calendar.
            foreach (var item in eventList) {
                if (item.Track.Equals("track1"))
                {
                    calendarGrid.Children.Add(new StackLayout {
                        Orientation = StackOrientation.Horizontal,
                        BackgroundColor = Color.DarkGreen,
                        Children = { new Label { Text = item.Name + "\n" + item.StartTime + "\n  -\n" + item.StopTime }, new Label { Text = TruncateWord(item.Description), HorizontalOptions = LayoutOptions.Center}, new Image { Source = "icon.png", HeightRequest = 29, WidthRequest = 29, HorizontalOptions = LayoutOptions.EndAndExpand, VerticalOptions = LayoutOptions.Start } },
                        GestureRecognizers = { new TapGestureRecognizer {
                            Command = new Command(()=> Navigation.PushModalAsync(new NavigationPage(new EventDetailPage(item)))),
                        } },
                    }, 1, 2, ConvertStartTimeToRows(item.StartTime), ConvertStartTimeToRows(item.StartTime) + ConvertStopTimeToRows(item.StopTime, item.StartTime));
                }
                else {
                    calendarGrid.Children.Add(new StackLayout {
                        Orientation = StackOrientation.Horizontal,
                        BackgroundColor = Color.DarkRed,
                        Children = { new Label { Text = item.Name + "\n" + item.StartTime + "\n  -\n" + item.StopTime}, new Label { Text = TruncateWord(item.Description), HorizontalOptions = LayoutOptions.Center}, new Image { Source = "icon.png", HeightRequest = 29, WidthRequest = 29, HorizontalOptions = LayoutOptions.EndAndExpand, VerticalOptions = LayoutOptions.Start } },
                        GestureRecognizers = { new TapGestureRecognizer {
                            Command = new Command(()=> Navigation.PushModalAsync(new NavigationPage(new EventDetailPage(item)))),
                        } },
                    }, 2, 3, ConvertStartTimeToRows(item.StartTime), ConvertStartTimeToRows(item.StartTime) + ConvertStopTimeToRows(item.StopTime, item.StartTime));
                }
            }

            Content = new ScrollView {
                Content = calendarGrid,
            };

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

        private string TruncateWord(string description) {
            var charArr = description.ToCharArray();
            var result = "";

            if (charArr.Length >= 10)
            {
                for (int i = 0; i < charArr.Length+1; i++)
                {
                    if (i == 20) {
                        result += "...";
                        break;
                    }

                    result += charArr[i].ToString();

                    if (i != 0 && i%10 == 0) {
                        result += "\n";
                    }
                }
            }
            else {
                result = description;
            }

            return result;
        }

        private int ConvertStopTimeToRows(string timeStop, string timeStart) {
            var stopSplitted = timeStop.Split(':');
            var startSplitted = timeStart.Split(':');

            var stopHour = Int32.Parse(stopSplitted[0]);
            var startHour = Int32.Parse(startSplitted[0]);

            var stopMin = Int32.Parse(stopSplitted[1]);
            var startMin = Int32.Parse(startSplitted[1]);

            double finalStop = 0;
            double finalStart = 0;

            if (stopMin==30)
            {
                finalStop = stopHour + 0.5;
            }
            else {
                finalStop = stopHour;
            }

            if (startMin==30)
            {
                finalStart = startHour + 0.5;
            }
            else {
                finalStart = startHour;
            }

            var res = ((finalStop - finalStart) * 2);

            return (int)res;
        }

        //private int ConvertStopTimeToRows(string timeStop, string timeStart) {
        //    var stopSplitted = timeStop.Split(':');
        //    var startSplitted = timeStart.Split(':');

        //    var stop = Int32.Parse(stopSplitted[0]);
        //    var start = Int32.Parse(startSplitted[0]);

        //    int res = stop - start;

        //    if (res != 1)
        //    {
        //        res++;
        //    }

        //    if (!stopSplitted[1].Equals("30"))
        //    {
        //        res ++;
        //    }
        //    else {
        //        res += 2;
        //    }

        //    return res;
        //}

        private int ConvertStartTimeToRows(string timeStart) {
            string[] timeSplitted = timeStart.Split(':');

            var hour = Int32.Parse(timeSplitted[0]);

            if (!timeSplitted[1].Equals("30"))
            {
                return (int)((hour + 0.5) * 2);
            }
            else {
                return (int)((hour + 0.5) * 2)+1;
            }
        }

        private List<EventModel> CreateEventsForTest() {
            List<EventModel> eventList = new List<EventModel>();

            //eventList.Add(new EventModel("BestEvent", "blablabla", "icon.png", "12:00", "13:00", "track1"));
            eventList.Add(new EventModel("BestEvent", "blablablablablablablablablablablablablablablablablablablablablablablablablablablablablablablablablablablablablablablablablablablablablablablablablablablablablablablablablablablablablablablablablablablablablablablablablablablablablablablablablablablablablablablablablabla", "icon.png", "12:00", "13:00", "track2"));
            eventList.Add(new EventModel("BestEvent", "blablabla", "icon.png", "13:00", "14:00", "track1"));
            eventList.Add(new EventModel("BestEvent", "blablabla", "icon.png", "13:00", "14:00", "track2"));
            eventList.Add(new EventModel("BestEvent", "blablabla", "icon.png", "14:00", "15:00", "track1"));
            eventList.Add(new EventModel("BestEvent", "blablabla", "icon.png", "14:00", "15:00", "track2"));
            eventList.Add(new EventModel("BestEvent", "blablabla", "icon.png", "15:00", "16:00", "track1"));
            eventList.Add(new EventModel("BestEvent", "blablabla", "icon.png", "15:00", "16:00", "track2"));
            eventList.Add(new EventModel("BestEvent", "blablabla", "icon.png", "16:00", "17:00", "track1"));
            eventList.Add(new EventModel("BestEvent", "blablabla", "icon.png", "16:00", "17:00", "track2"));
            eventList.Add(new EventModel("BestEvent", "blablabla", "icon.png", "17:00", "18:00", "track1"));
            eventList.Add(new EventModel("BestEvent", "blablabla", "icon.png", "17:00", "18:00", "track2"));
            eventList.Add(new EventModel("BestEvent", "blablabla", "icon.png", "10:00", "11:00", "track1"));
            eventList.Add(new EventModel("BestEvent", "blablabla", "icon.png", "10:00", "11:00", "track2"));
            eventList.Add(new EventModel("BestEvent", "blablabla", "icon.png", "11:00", "13:00", "track1"));
            eventList.Add(new EventModel("BestEvent", "blablabla", "icon.png", "11:00", "12:00", "track2"));
            eventList.Add(new EventModel("BestEvent", "blablabla", "icon.png", "01:00", "06:30", "track2"));

            return eventList;
        }

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
