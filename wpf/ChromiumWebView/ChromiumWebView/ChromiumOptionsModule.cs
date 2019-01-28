using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReactNative.Bridge;
using ReactNative.Modules.Core;

namespace ChromiumWebView
{
    class ChromiumOptionsModule : ReactContextNativeModuleBase
    {
        public ChromiumOptionsModule(ReactContext reactContext)
            : base(reactContext)
        {
            EO.WebEngine.Engine.Default.Options.AllowProprietaryMediaFormats();

            EO.WebEngine.BrowserOptions options = new EO.WebEngine.BrowserOptions();
            options.EnableWebSecurity = false;
            options.AllowZooming = false;
        }

        public override string Name
        {
            get
            {
                return "ChromiumOptions";
            }
        }

        [ReactMethod]
        public void AddLicense(string license)
        {
            DispatcherHelpers.RunOnDispatcher(new Action(() =>
            {
                EO.WebBrowser.Runtime.AddLicense(license);
            }));
        }
    }
}
