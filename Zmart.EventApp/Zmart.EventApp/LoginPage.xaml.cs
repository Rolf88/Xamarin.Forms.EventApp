using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Zmart.EventApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {

            InitializeComponent();
            Title = "Event App";
            btnLogin.Clicked += async (sender, args) => {

                var email = editEmail.Text;
                var password = editPassword.Text;

                if ((email != null && password != null) && (!email.Equals("") && !password.Equals("")))
                {
                    Application.Current.Properties["email"] = email;
                    Application.Current.Properties["password"] = password;
                    Application.Current.Properties["token"] = "myownwonderfulmadeuptokenhahahaha231455544";
                    await Navigation.PushAsync(new CodedPages.CodedMainPage());
                }
            };
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            Navigation.RemovePage(this);
        }
    }
}
