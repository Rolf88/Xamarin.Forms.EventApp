using Acr.UserDialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Zmart.EventApp.ViewModels;

namespace Zmart.EventApp.CodedPages
{
    public class CodedMainPage : ContentPage
    {
        public ObservableCollection<EventViewModel> eventItems { get; set; }

        public CodedMainPage(string title) {

            Title = title;
            
            eventItems = new ObservableCollection<EventViewModel>();
            ListView listView = new ListView();
            listView.RowHeight = 100;
            listView.ItemTemplate = new DataTemplate(typeof(CustomEventCell));
            eventItems.Add(new EventViewModel { Name = "BestEvent", StartTime = "18:00", StopTime = "19:00", Image = "icon.png", Description = "blablablablablablablablablablablablablablablablablablablablablablablablablablablablablabla..."});
            eventItems.Add(new EventViewModel { Name = "BestEvent", StartTime = "18:00", StopTime = "19:00", Image = "icon.png", Description = "blablabla..." });
            eventItems.Add(new EventViewModel { Name = "BestEvent", StartTime = "18:00", StopTime = "19:00", Image = "icon.png", Description = "blablabla..." });
            eventItems.Add(new EventViewModel { Name = "BestEvent", StartTime = "18:00", StopTime = "19:00", Image = "icon.png", Description = "blablabla..." });
            eventItems.Add(new EventViewModel { Name = "BestEvent", StartTime = "18:00", StopTime = "19:00", Image = "icon.png", Description = "blablabla..." });
            eventItems.Add(new EventViewModel { Name = "BestEvent", StartTime = "18:00", StopTime = "19:00", Image = "icon.png", Description = "blablabla..." });
            eventItems.Add(new EventViewModel { Name = "BestEvent", StartTime = "18:00", StopTime = "19:00", Image = "icon.png", Description = "blablabla..." });
            eventItems.Add(new EventViewModel { Name = "BestEvent", StartTime = "18:00", StopTime = "19:00", Image = "icon.png", Description = "blablabla..." });
            eventItems.Add(new EventViewModel { Name = "BestEvent", StartTime = "18:00", StopTime = "19:00", Image = "icon.png", Description = "blablabla..." });
            eventItems.Add(new EventViewModel { Name = "BestEvent", StartTime = "18:00", StopTime = "19:00", Image = "icon.png", Description = "blablabla..." });
            eventItems.Add(new EventViewModel { Name = "BestEvent", StartTime = "18:00", StopTime = "19:00", Image = "icon.png", Description = "blablabla..." });
            eventItems.Add(new EventViewModel { Name = "BestEvent", StartTime = "18:00", StopTime = "19:00", Image = "icon.png", Description = "blablabla..." });
            eventItems.Add(new EventViewModel { Name = "BestEvent", StartTime = "18:00", StopTime = "19:00", Image = "icon.png", Description = "blablabla..." });
            eventItems.Add(new EventViewModel { Name = "BestEvent", StartTime = "18:00", StopTime = "19:00", Image = "icon.png", Description = "blablabla..." });
            listView.ItemsSource = eventItems;

            listView.ItemTapped += async (sender, e) =>
            {
                var eventItem = e.Item as EventViewModel;

                await Navigation.PushModalAsync(new NavigationPage(new EventDetailPage(eventItem)));
            };

            Content = listView;
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
