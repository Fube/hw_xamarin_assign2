using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Assign2.Droid
{
    [Activity(Label = "SplishSplash", Icon = "@mipmap/icon", NoHistory = true, Theme = "@style/MyTheme.Splash", MainLauncher = true, 
        ConfigurationChanges = ConfigChanges.ScreenSize |
        ConfigChanges.Orientation | ConfigChanges.UiMode |
        ConfigChanges.ScreenLayout |
        ConfigChanges.SmallestScreenSize)]
    public class SplishSplash : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            StartActivity(typeof(MainActivity));
            Thread.Sleep(2000);
            Finish();
        }
    }
}