using System;
using System.Diagnostics;
using System.Windows.Input;
using foregroundApp.Services;
using Xamarin.Forms;

namespace foregroundApp.ViewModels
{
    public class HomeVM : BaseViewModel
    {
        public ICommand StartBtnCommand { get; private set; }
        public ICommand StopBtnCommand { get; private set; }


        public HomeVM()
        {
            StartBtnCommand = new Command(() =>
            {
                Debug.WriteLine("Start button pressed!");
                DependencyService.Get<IAndroidService>().StartService();
            });

            StopBtnCommand = new Command(() =>
            {
                Debug.WriteLine("Stop button pressed!");
                DependencyService.Get<IAndroidService>().StopService();
            });
        }
    }
}
