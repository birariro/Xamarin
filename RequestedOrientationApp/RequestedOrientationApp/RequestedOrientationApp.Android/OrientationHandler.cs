using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using RequestedOrientationApp.Droid;
using Xamarin.Forms;

[assembly:Dependency(typeof(OrientationHandler))]
namespace RequestedOrientationApp.Droid
{
    class OrientationHandler : BaseDependency,IOrientationHandler
    {
        public void ForceLandscape()
        {
            GetActivity().RequestedOrientation = ScreenOrientation.Landscape;
        }

        public void ForcePortrait()
        {
            GetActivity().RequestedOrientation = ScreenOrientation.Portrait;
        }
    }
}