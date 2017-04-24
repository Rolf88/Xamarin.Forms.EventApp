using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Zmart.EventApp.ViewModels
{
    public class CustomEventCell : ViewCell
    {
        public CustomEventCell() {
            var startTime = new Label();
            var slashLabel = new Label();
            var stopTime = new Label();
            var name = new Label();
            var desc = new Label();
            var image = new Image();

            var horizontalLayout = new StackLayout();
            var verticalLayout = new StackLayout();

            startTime.SetBinding(Label.TextProperty, new Binding("StartTime"));
            stopTime.SetBinding(Label.TextProperty, new Binding("StopTime"));
            name.SetBinding(Label.TextProperty, new Binding("Name"));
            image.SetBinding(Image.SourceProperty, new Binding("Image"));
            desc.SetBinding(Label.TextProperty, new Binding("Description"));

            //image.IsVisible = true;
            image.HeightRequest = 70;
            image.WidthRequest = 70;

            horizontalLayout.Orientation = StackOrientation.Horizontal;
            horizontalLayout.HorizontalOptions = LayoutOptions.Fill;

            startTime.VerticalOptions = LayoutOptions.Center;
            startTime.FontSize = 15;
            startTime.FontAttributes = FontAttributes.Bold;
            stopTime.VerticalOptions = LayoutOptions.Center;
            stopTime.FontSize = 15;
            stopTime.FontAttributes = FontAttributes.Bold;
            slashLabel.VerticalOptions = LayoutOptions.Center;
            slashLabel.Text = " - ";
            slashLabel.FontSize = 15;
            slashLabel.FontAttributes = FontAttributes.Bold;
            name.FontAttributes = FontAttributes.Bold;
            name.FontSize = 18;
            desc.WidthRequest = 150;
            desc.LineBreakMode = LineBreakMode.TailTruncation;

            verticalLayout.Children.Add(name);
            verticalLayout.Children.Add(desc);

            horizontalLayout.Children.Add(startTime);
            horizontalLayout.Children.Add(slashLabel);
            horizontalLayout.Children.Add(stopTime);
            horizontalLayout.Children.Add(image);
            horizontalLayout.Children.Add(verticalLayout);

            View = horizontalLayout;
        }
    }
}
