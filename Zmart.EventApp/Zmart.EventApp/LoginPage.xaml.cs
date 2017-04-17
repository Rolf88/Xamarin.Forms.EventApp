using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

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

                    TabbedPage tabbedPage = new TabbedPage();

                    foreach (var item in testList)
                    {
                        tabbedPage.Children.Add(new NavigationPage(new CodedPages.CodedMainPage(item)) { Title = item });
                    }

                    Application.Current.MainPage = tabbedPage;
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
