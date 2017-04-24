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
        public EventDetailPage(EventModel viewModel) {
            Title = viewModel.Name;

            Button btn = new Button { Text = "Go Back",
                TextColor = Color.White,
                BackgroundColor = Color.Blue,
                VerticalOptions = LayoutOptions.End
            };

            btn.Clicked += async (object sender, EventArgs e) => {
                await Navigation.PopModalAsync();
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
                    new Label{ Text = viewModel.Description,
                        VerticalTextAlignment = TextAlignment.Center,
                        HorizontalTextAlignment = TextAlignment.Center,
                        HorizontalOptions = LayoutOptions.Center,
                        Margin = 20
                    },
                    new StackLayout{
                        VerticalOptions = LayoutOptions.EndAndExpand,
                        Children = {
                            btn,
                        }
                    }
                },
            };
        }
    }
}
