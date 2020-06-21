using System;
using BGStopwatch.Common.Mvvm;
using BGStopwatch.Services.Stopwatch;
using Prism.Commands;
using Prism.Logging;
using Prism.Navigation;
using Prism.Services;

namespace BGStopwatch.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private IStopwatch stopwatchService { get; }
        public string stopwatchtext { get; set; }
        public DelegateCommand StartTappedCommand { get; }
        public DelegateCommand StopTappedCommand { get; }
        public DelegateCommand ResetTappedCommand { get; }

        public MainPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService,
            ILoggerFacade logger, IStopwatch stopwatch)
            : base(navigationService, pageDialogService, logger)
        {
            StartTappedCommand = new DelegateCommand(OnStartTapped);
            StopTappedCommand = new DelegateCommand(OnStopTapped);
            ResetTappedCommand = new DelegateCommand(OnResetTapped);

            stopwatchtext = "00:00:00.00";
            stopwatchService = stopwatch;
        }

        private void OnResetTapped()
        {
            stopwatchtext = "00:00:00.00";
            stopwatchService.Reset();
        }

        private void OnStopTapped()
        {
            stopwatchService.Stop();
        }

        private void OnStartTapped()
        {
            if (!stopwatchService.IsRunning)
                stopwatchService.Start(TimeSpan.FromMilliseconds(100), () =>
                    {
                        stopwatchtext = string.Format("{0:hh\\:mm\\:ss\\.ff}", stopwatchService.Elapsed);

                        if (!stopwatchService.IsRunning)
                            return false;
                        return true;
                    }
                );
        }
    }
}