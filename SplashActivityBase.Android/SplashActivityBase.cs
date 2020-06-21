using System;
using System.Threading;
using Android.App;
using Android.Content.PM;
using Android.OS;

namespace SplashActivityBase.Android
{
    /// <summary>
    ///     Base class for Android Splash screen
    /// </summary>
    [Activity(NoHistory = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public abstract class SplashActivityBase : Activity
    {
        protected virtual int splashView => throw new NotImplementedException("SplashView Not Implemented");
        protected virtual Type mainActivity => throw new NotImplementedException("mainActivity Not Implemented");

        /// <summary>
        ///     called on creation of the splash screen activity
        /// </summary>
        /// <param name="bundle">Android mapping from string value to parcable type</param>
        protected override void OnCreate(Bundle bundle)
        {
            // get the display layout for this splash activity... 
            // and queue a thread to sleep it until the main activity is relevant.  
            SetContentView(splashView);
            ThreadPool.QueueUserWorkItem(o => LoadActivity());

            base.OnCreate(bundle);
        }

        /// <summary>
        ///     loading the splash activity, set to run for 2500 ms
        /// </summary>
        private void LoadActivity()
        {
            // sleep this activity / display the splash screen until 
            // main activity is relevant and the app needs to go to work.  
            Thread.Sleep(2500); // Simulate a long pause    

            RunOnUiThread(()
                => StartActivity(mainActivity));
        }

        /// <summary>
        ///     eat the back button pressed event... this is the splash activity
        /// </summary>
        public override void OnBackPressed()
        {
        }
    }
}