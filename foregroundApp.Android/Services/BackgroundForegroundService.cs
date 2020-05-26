using System;
using Android.App;
using Android.Content;
using Android.OS;
using Xamarin.Forms;

namespace foregroundApp.Droid.Services
{
    [Service]
    public class BackgroundForegroundService : Service
    {
        NotificationManager NotificationManager;
        Handler ServiceHandler;

        public const int ServiceRunningNotifID = 9005;
        private string Tag = "ForegoundApp";
        private string ChannelId = ServiceRunningNotifID.ToString();

        public override IBinder OnBind(Intent intent)
        {
            // TODO:
            return null;
        }

        public override StartCommandResult OnStartCommand(Intent intent, StartCommandFlags flags, int startId)
        {
            Notification notif = DependencyService.Get<INotification>().ReturnNotif("Background", "body della notifica");
            StartForeground(ServiceRunningNotifID, notif);

            //_ = DoLongRunningOperationThings();

            return StartCommandResult.Sticky;
        }

        public override void OnDestroy()
        {
            base.OnDestroy();
        }

        public override void OnCreate()
        {
            base.OnCreate();

            HandlerThread handlerThread = new HandlerThread(Tag);
            handlerThread.Start();
            ServiceHandler = new Handler(handlerThread.Looper);
            NotificationManager = (NotificationManager)GetSystemService(NotificationService);

            if (Build.VERSION.SdkInt >= BuildVersionCodes.O)
            {
                string name = "com.simonemarra.foregroundApp"; // GetString(Resource.String.app_name);
                NotificationChannel mChannel = new NotificationChannel(ChannelId, name, NotificationImportance.Default);
                NotificationManager.CreateNotificationChannel(mChannel);
            }
        }

        public override bool StopService(Intent name)
        {
            return base.StopService(name);
        }
    }
}
