using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using HockeyApp.iOS;
using UIKit;

namespace Zwaby.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        private string AppId = "eb2e2c6716a5445193d7913810c6349c";

        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            var manager = BITHockeyManager.SharedHockeyManager;
            manager.Configure(AppId);
            manager.StartManager();
            manager.Authenticator.AuthenticateInstallation();

            global::Xamarin.Forms.Forms.Init();

            LoadApplication(new App());

            return base.FinishedLaunching(app, options);
        }
    }
}
