using System;
using Android.Content;
using foregroundApp.Droid.Services;
using foregroundApp.Services;

[assembly: Xamarin.Forms.Dependency(typeof(AndroidServiceHelper))]
namespace foregroundApp.Droid.Services
{
    internal class AndroidServiceHelper : IAndroidService
    {
        private static Context context = global::Android.App.Application.Context;

        public void StartService()
        {
            //var intent = new Intent(context, typeof(DataSource));
            var intent = new Intent(context, typeof(BackgroundForegroundService));

            if (Android.OS.Build.VERSION.SdkInt >= Android.OS.BuildVersionCodes.O)
            {
                context.StartForegroundService(intent);
            }
            else
            {
                context.StartService(intent);
            }
        }

        public void StopService()
        {
            var intent = new Intent(context, typeof(DataSource));
            context.StopService(intent);
        }
    }
}
