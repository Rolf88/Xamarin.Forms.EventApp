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
    public class AboutPage : ContentPage
    {
        public AboutPage() {
            Title = "About";

            //Button btn = new Button
            //{
            //    Text = "Go Back",
            //    TextColor = Color.White,
            //    BackgroundColor = Color.Blue,
            //    VerticalOptions = LayoutOptions.End
            //};

            //btn.Clicked += async (object sender, EventArgs e) => {
            //    await Navigation.PopModalAsync();
            //};

            var conference = JsonConvert.DeserializeObject<Conference>(App.Current.Properties["conference"].ToString());

            var stackLay = new StackLayout {
                Orientation = StackOrientation.Vertical,
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Padding = 20,
                Children = {
                    new Label{ Text = conference.Name,
                        HorizontalOptions = LayoutOptions.Center,
                        VerticalOptions = LayoutOptions.Start,
                        HorizontalTextAlignment = TextAlignment.Center,
                        FontAttributes = FontAttributes.Bold,
                        FontSize = 35,
                        TextColor = Color.Black                    },
                    new StackLayout{
                        Orientation = StackOrientation.Horizontal,
                        HorizontalOptions = LayoutOptions.FillAndExpand,
                        Children ={
                            new StackLayout{
                                Orientation = StackOrientation.Horizontal,
                                HorizontalOptions= LayoutOptions.StartAndExpand,
                                Children ={
                                    new Label{ Text = conference.Adress + "\n" + conference.City + "\n" + conference.Country,
                                        HorizontalOptions = LayoutOptions.StartAndExpand,
                                        FontSize = 15,
                                        TextColor = Color.Blue
                                     },
                                     },
                                    },
                            new StackLayout{
                                Orientation = StackOrientation.Horizontal,
                                HorizontalOptions= LayoutOptions.EndAndExpand,
                                Children = {
                                    new Label{ Text = conference.PhoneNumber,
                                        HorizontalOptions = LayoutOptions.EndAndExpand,
                                        FontSize = 15,
                                        TextColor = Color.Blue
                            },
                                },
                            }
                        },
                    },
                    new ScrollView{
                       Content = new Label{ Text = conference.Details,
                        HorizontalOptions = LayoutOptions.Center,
                        HorizontalTextAlignment = TextAlignment.Center,
                        FontSize = 25,
                        TextColor = Color.Black
                       },
                    },
                    //new StackLayout{
                    //    VerticalOptions = LayoutOptions.EndAndExpand,
                    //    Children = {
                    //        btn,
                    //    }
                    //}
                }
            };

            Content = stackLay;
        }
    }
}
