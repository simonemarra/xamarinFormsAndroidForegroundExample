using System;
using Android.App;

namespace foregroundApp.Droid.Services
{
    public interface INotification
    {
        Notification ReturnNotif();
        Notification ReturnNotif(string title, string body);
    }
}
