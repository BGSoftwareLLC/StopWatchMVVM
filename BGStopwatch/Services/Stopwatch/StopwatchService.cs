using System;
using Xamarin.Forms;

namespace BGStopwatch.Services.Stopwatch
{
    public class StopwatchService : IStopwatch
    {
        private System.Diagnostics.Stopwatch stopwatch { get; }

        public StopwatchService()
        {
            stopwatch = new System.Diagnostics.Stopwatch();
        }

        public void Start(TimeSpan interval, Func<bool> callback)
        {
            stopwatch.Start();
            Device.StartTimer(TimeSpan.FromMilliseconds(100), () =>
            {
                Device.BeginInvokeOnMainThread(() => { callback(); });
                return true;
            });
        }

        public void Stop()
        {
            stopwatch.Stop();
        }

        public void Reset()
        {
            stopwatch.Reset();
        }

        bool IStopwatch.IsRunning => stopwatch.IsRunning;

        TimeSpan IStopwatch.Elapsed => stopwatch.Elapsed;
    }
}