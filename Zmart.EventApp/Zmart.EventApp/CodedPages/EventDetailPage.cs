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
    public class EventDetailPage : ContentPage 
    {
        private EventModel eventModel;

        public EventDetailPage(EventModel viewModel, bool personalOrNot) {
            Title = viewModel.Name;

            eventModel = viewModel;
            Button regBtn;

            if (!personalOrNot)
            {
                regBtn = new Button
                {
                    Text = "Add event to personal schema",
                    TextColor = Color.White,
                    BackgroundColor = Color.Blue
                };

                regBtn.Clicked += RegBtn_Clicked;
            }
            else {
                regBtn = new Button
                {
                    Text = "Remove event from personal schema",
                    TextColor = Color.White,
                    BackgroundColor = Color.Blue
                };

                regBtn.Clicked += RegBtn_Clicked1;
            }

            Button btn = new Button { Text = "Go Back",
                TextColor = Color.White,
                BackgroundColor = Color.Blue,
                VerticalOptions = LayoutOptions.End
            };

            btn.Clicked += async (object sender, EventArgs e) => {
                if (!personalOrNot)
                {
                    await Navigation.PopModalAsync();
                }
                else {
                    NavigateToPersonalSchema();
                }
            };

            Content = new StackLayout {
                Orientation = StackOrientation.Vertical,
                VerticalOptions = LayoutOptions.FillAndExpand,
                Children = {
                    new Image{ Source = "icon.png", HeightRequest = 100, WidthRequest = 100, Margin = 10 },
                    new Label{ Text = viewModel.StartTime + " - " + viewModel.StopTime,
                        VerticalTextAlignment = TextAlignment.Center,
                        HorizontalTextAlignment = TextAlignment.Center,
                        HorizontalOptions = LayoutOptions.Center,
                        Margin = 20
                    },
                    new ScrollView{
                        Content = new Label{ Text = viewModel.Description,
                        VerticalTextAlignment = TextAlignment.Center,
                        HorizontalTextAlignment = TextAlignment.Center,
                        HorizontalOptions = LayoutOptions.Center,
                        Margin = 20
                    },
                    },
                    new StackLayout{
                        VerticalOptions = LayoutOptions.EndAndExpand,
                        Children = {
                            regBtn,
                            btn,
                        }
                    }
                },
            };
        }

        private void NavigateToPersonalSchema()
        {
            var conference = JsonConvert.DeserializeObject<Conference>(App.Current.Properties["conference"].ToString());
            TabbedPage tabbedPage = new TabbedPage();

            foreach (var date in conference.Dates)
            {
                tabbedPage.Children.Add(new NavigationPage(new PersonalSchema(date)) { Title = date });
            }

            App.masterDetailPage.Detail = tabbedPage;
        }

        private void RegBtn_Clicked1(object sender, EventArgs e)
        {
            List<EventModel> eventList = JsonConvert.DeserializeObject<List<EventModel>>(Application.Current.Properties["personalSchema"].ToString());
            
            eventList.Remove(eventModel);

            Application.Current.Properties["personalSchema"] = JsonConvert.SerializeObject(eventList);
            
            DisplayAlert("", "event have been removed", "Ok");
            NavigateToPersonalSchema();
        }

        private void RegBtn_Clicked(object sender, EventArgs e)
        {
            List<EventModel> eventList = new List<EventModel>();
            if (Application.Current.Properties.ContainsKey("personalSchema"))
            {
                eventList = JsonConvert.DeserializeObject<List<EventModel>>(Application.Current.Properties["personalSchema"].ToString());

                if (!eventList.Contains(eventModel))
                {
                    eventList.Add(eventModel);

                    Application.Current.Properties["personalSchema"] = JsonConvert.SerializeObject(eventList);
                    DisplayAlert("", "event have been added", "Ok");
                    Navigation.PopModalAsync();
                }
                else {
                    DisplayAlert("","You have already added this event to your personal schema.","Ok");
                }

            }
            else {
                eventList.Add(eventModel);

                Application.Current.Properties["personalSchema"] = JsonConvert.SerializeObject(eventList);
                DisplayAlert("", "event have been added", "Ok");
                Navigation.PopModalAsync();
            }
            
        }
    }
}
