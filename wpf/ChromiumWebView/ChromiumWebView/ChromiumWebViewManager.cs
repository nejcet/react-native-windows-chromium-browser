using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using ReactNative.UIManager;
using ReactNative.UIManager.Annotations;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace ChromiumWebView
{
    class ChromiumWebViewManager : SimpleViewManager<WebView>
    {

        public override string Name
        {
            get
            {
                return "ChromiumWebView";
            }
        }

        [ReactProp("src")]
        public void SetSource(WebView view, string source)
        {
            var webView = (WebView)view;
            webView.Source = source;
        }

        public override void OnDropViewInstance(ThemedReactContext reactContext, WebView view)
        {
            base.OnDropViewInstance(reactContext, view);
            view.Cleanup();
        } 

        protected override WebView CreateViewInstance(ThemedReactContext reactContext)
        {
            return new WebView(); 
        }

      
    }
}
