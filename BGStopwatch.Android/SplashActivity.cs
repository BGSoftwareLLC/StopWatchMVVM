using System;
using Android.App;

namespace BGStopwatch.Droid
{
    [Activity(Label = "BGStopwatch", Icon = "@drawable/icon", Theme = "@style/Theme.Splash", MainLauncher = true)]
    public class SplashActivity : SplashActivityBase.Android.SplashActivityBase
    {
        protected override int splashView => Resource.Layout.SplashLayout;
        protected override Type mainActivity => typeof(MainActivity);
    }
}