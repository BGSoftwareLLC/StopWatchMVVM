using Prism.AppModel;
using Prism.Logging;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Threading.Tasks;

namespace BGStopwatch.Common.Mvvm
{
    public abstract class ViewModelBase : BindableBase, INavigationAware, IPageLifecycleAware, IDestructible
    {
        protected INavigationService NavigationService { get; }

        protected IPageDialogService PageDialogService { get; }

        public ILoggerFacade Logger { get; }

        public ViewModelBase(INavigationService navigationService, IPageDialogService pageDialogService, ILoggerFacade logger)
        {
            NavigationService = navigationService;
            PageDialogService = pageDialogService;
            Logger = logger;
            IsNotBusy = true;
        }

        public string Title { get; set; }

        public string Subtitle { get; set; }

        public bool IsBusy { get; set; }

        public bool IsNotBusy { get; set; }

        protected async Task HandleNavigationRequest(string name, INavigationParameters parameters = null)
        {
            try
            {
                var result = await NavigationService.NavigateAsync(name, parameters);
                if (!result.Success)
                    throw result.Exception;
            }
            catch (Exception ex)
            {
                await PageDialogService.DisplayAlertAsync("Error", $"An error occured while navigating. {ex.Message}", "Ok");
            }
        }

        private void OnIsBusyChanged() => IsNotBusy = !IsBusy;

        private void OnIsNotBusyChanged() => IsBusy = !IsNotBusy;

        public virtual void OnNavigatedFrom(INavigationParameters parameters)
        {
        }

        public virtual void OnNavigatedTo(INavigationParameters parameters)
        {
        }

        public virtual void OnNavigatingTo(INavigationParameters parameters)
        {
        }

        public virtual void OnAppearing()
        {
        }

        public virtual void OnDisappearing()
        {
        }

        public virtual void Destroy()
        {
        }
    }
}