using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Zmart.EventApp.CodedPages;

namespace Zmart.EventApp
{
    public partial class LoginPage : ContentPage
    {
        
        public LoginPage()
        {

            InitializeComponent();
            var testList = new List<string>() { "1st", "2nd", "3rd", "4th", "5th", "6th" };

            Title = "Login";

            btnLogin.Clicked += (sender, args) => {

                var email = editEmail.Text;
                var password = editPassword.Text;

                if ((email != null && password != null) && (!email.Equals("") && !password.Equals("")))
                {
                    Application.Current.Properties["email"] = email;
                    Application.Current.Properties["password"] = password;
                    Application.Current.Properties["token"] = "myownwonderfulmadeuptokenhahahaha231455544";

                    //TabbedPage tabbedPage = new TabbedPage();
                    //foreach (var item in testList)
                    //{
                    //    tabbedPage.Children.Add(new NavigationPage(new CodedMainPage(item)) { Title = item });
                    //}

                    App.masterDetailPage = new MasterDetailPage
                    {
                        Master = new MenuPage(),
                        Detail = App.tabbedPage,
                    };

                    Application.Current.MainPage = App.masterDetailPage;
                    //await Navigation.PushAsync(new CodedPages.CodedMainPage());
                    //Navigation.RemovePage(this);
                }
            };
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            //Navigation.RemovePage(this);
        }
    }
}
