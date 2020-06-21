using BGStopwatch.Services.Stopwatch;
using BGStopwatch.ViewModels;
using BGStopWatch.Views;
using Prism;
using Prism.Ioc;
using Prism.Unity;

namespace BGStopwatch
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer platformInitializer) : base(platformInitializer)
        {
        }

        protected override void OnInitialized()
        {
            InitializeComponent();
            NavigationService.NavigateAsync("MainPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IStopwatch, StopwatchService>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}