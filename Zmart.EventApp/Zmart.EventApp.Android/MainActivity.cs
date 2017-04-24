using System;
using Android.App;
using Android.Content.PM;
using Android.OS;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Acr.UserDialogs;

namespace Zmart.EventApp.Droid
{
    [Activity(Label = "Zmart.EventApp", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);
            //var dbPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);

            Forms.Init(this, bundle);
            UserDialogs.Init(() => (Activity)Forms.Context);
            this.LoadApplication(new App());
        }
    }
}

