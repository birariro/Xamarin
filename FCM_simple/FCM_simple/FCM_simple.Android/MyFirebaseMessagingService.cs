using Android.App;
using Android.Content;
using Android.OS;
using Android.Util;
using AndroidX.Core.App;
using Firebase.Messaging;
using System;
using System.Text.RegularExpressions;

namespace FCM_simple.Droid
{
    [Service]
    [IntentFilter(new[] { "com.google.firebase.MESSAGING_EVENT" })]
    class MyFirebaseMessagingService : FirebaseMessagingService
    {
        const string TAG = "MyFireBaseMessagingService";
        public const string PRIMARY_CHANNEL = "default";
        public override void OnNewToken(string p0)
        {
            Log.Debug(TAG, "GetToken : " + p0);
            Console.WriteLine("GetToken :" + p0);
            base.OnNewToken(p0);
            

        }
        public override void OnMessageReceived(RemoteMessage message)
        {
            Log.Debug(TAG, "From: " + message.From);

            var body = message.GetNotification().Body;
            Log.Debug(TAG, "Notification Message Body: " + body);
            SendNotifications(message);
        }
        public void SendNotifications(RemoteMessage message)
        {
            try
            {
                NotificationManager manager = (NotificationManager)GetSystemService(NotificationService);
                var seed = Convert.ToInt32(Regex.Match(Guid.NewGuid().ToString(), @"\d+").Value);
                int id = new Random(seed).Next(000000000, 999999999);
                var push = new Intent();
                var fullScreenPendingIntent = PendingIntent.GetActivity(this, 0,
               push, PendingIntentFlags.CancelCurrent);
                NotificationCompat.Builder notification;
                if (Build.VERSION.SdkInt >= BuildVersionCodes.O)
                {
                    var chan1 = new NotificationChannel(PRIMARY_CHANNEL,
                    new Java.Lang.String("Primary"), NotificationImportance.High);
                    manager.CreateNotificationChannel(chan1);
                    notification = new NotificationCompat.Builder(this, PRIMARY_CHANNEL);
                }
                else
                {
                    notification = new NotificationCompat.Builder(this, PRIMARY_CHANNEL);
                }
                notification.SetContentIntent(fullScreenPendingIntent)
                         .SetContentTitle(message.GetNotification().Title)
                         .SetContentText(message.GetNotification().Body)
                         .SetStyle((new NotificationCompat.BigTextStyle()))
                         .SetPriority(NotificationCompat.PriorityHigh)
                         .SetColor(0x9c6114)
                         .SetAutoCancel(true);
                manager.Notify(id, notification.Build());
            }
            catch (Exception ex)
            {
            }
        }

    }
}