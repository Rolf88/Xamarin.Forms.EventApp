using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Zmart.EventApp.CodedPages
{
    public class CodedMainPage : ContentPage
    {
        
        private Grid grid;

        public CodedMainPage() {
            Title = "Event App";
            var table1 = MakeTable();
            var table2 = MakeTable();

            grid = new Grid();
            grid.HorizontalOptions = LayoutOptions.FillAndExpand;
            grid.VerticalOptions = LayoutOptions.FillAndExpand;

            grid.RowDefinitions = new RowDefinitionCollection
            {
                new RowDefinition { Height = GridLength.Auto },
                new RowDefinition { }
            };

            grid.ColumnDefinitions = new ColumnDefinitionCollection {
                new ColumnDefinition{ },
                new ColumnDefinition{ }
            };

            grid.Children.Add(new Label { Text = "Column 1", TextColor = Color.Aquamarine }, 0, 0);
            grid.Children.Add(new Label { Text = "Column 2", TextColor = Color.DarkBlue }, 1, 0);

            grid.Children.Add(table1,0,1);
            grid.Children.Add(table2,1,1);

            Content = grid;
        }
        

        private TableView MakeTable() {
            var table = new TableView() { Intent = TableIntent.Menu };
            var root = new TableRoot();
            var section1 = new TableSection() { Title = "First Section" };
            var section2 = new TableSection() { Title = "Second Section" };
            var section3 = new TableSection() { Title = "Third Section" };
            var section4 = new TableSection() { Title = "Fourth Section" };
            var section5 = new TableSection() { Title = "Fifth Section" };

            var text = new TextCell { Text = "TextCell", Detail = "TextCell Detail" };
            var image = new ImageCell { Text = "ImageCell Text", Detail = "ImageCell Detail", ImageSource = "icon.png" };

            section1.Add(text);
            section1.Add(image);
            section2.Add(text);
            section2.Add(image);
            section3.Add(text);
            section3.Add(image);
            section4.Add(text);
            section4.Add(image);
            section5.Add(text);
            section5.Add(image);

            table.Root = root;
            root.Add(section1);
            root.Add(section2);
            root.Add(section3);
            root.Add(section4);
            root.Add(section5);

            return table;
        }
    }
}
