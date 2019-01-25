using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using ReactNative.UIManager;
using ReactNative.UIManager.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Media;

namespace ChromiumWebView
{
    class ChromiumWebViewManager : SimpleViewManager<ChromiumWebView>
    {
        public override string Name
        {
            get
            {
                return "ChromiumWebView";
            }
        }

        public override void OnDropViewInstance(ThemedReactContext reactContext, ChromiumWebView view)
        {
            base.OnDropViewInstance(reactContext, view);
            //view.Dispose();
        }

        protected override ChromiumWebView CreateViewInstance(ThemedReactContext reactContext)
        {
            return new ChromiumWebView();
        }
    }
}
