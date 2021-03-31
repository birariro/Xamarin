using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using RequestedOrientationApp.iOS;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(OrientationHandlerImplementation))]
namespace RequestedOrientationApp.iOS
{
    class OrientationHandlerImplementation : IOrientationHandler
    {
        public void ForceLandscape()
        {
            UIDevice.CurrentDevice.SetValueForKey(new NSNumber((int)UIInterfaceOrientation.LandscapeLeft), new NSString("orientation"));
        }

        public void ForcePortrait()
        {
            UIDevice.CurrentDevice.SetValueForKey(new NSNumber((int)UIInterfaceOrientation.Portrait), new NSString("orientation"));
        }
    }
}