using System;

namespace BGStopwatch.Services.Stopwatch
{
    public interface IStopwatch
    {
        void Start(TimeSpan interval, Func<bool> callback);
        void Stop();
        void Reset();
        bool IsRunning { get; }
        TimeSpan Elapsed { get; }
    }
}