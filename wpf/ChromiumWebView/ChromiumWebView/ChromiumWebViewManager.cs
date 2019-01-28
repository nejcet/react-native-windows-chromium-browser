using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using ReactNative.Bridge;
using ReactNative.UIManager;
using ReactNative.UIManager.Annotations;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace ChromiumWebView
{
    class ChromiumWebViewManager : SimpleViewManager<WebView>
    {

        private const string BLANK_URL = "about:blank";

        public override string Name
        {
            get
            {
                return "ChromiumWebView";
            }
        }

        [ReactProp("source")]
        public void SetSource(WebView view, JObject source)
        {

            if (source != null)
            {
                var html = source.Value<string>("html");
                if (html != null)
                {
                    var baseUrl = source.Value<string>("baseUrl");
                    if (baseUrl != null)
                    {
                        view.NavigateToString(html, baseUrl);
                        return;
                    }

                    view.NavigateToString(html);
                    return;
                }

                var uri = source.Value<string>("uri");
                if (uri != null)
                {
                    string previousUri = view.currentUrl;
                    if (!String.IsNullOrWhiteSpace(previousUri) && previousUri.Equals(uri))
                    {
                        return;
                    }

                    view.currentUrl = uri;
                    return;
                }
            }

            view.currentUrl = BLANK_URL;
        }

        public override void OnDropViewInstance(ThemedReactContext reactContext, WebView view)
        {
            base.OnDropViewInstance(reactContext, view);
            view.Dispose();
        } 

        protected override WebView CreateViewInstance(ThemedReactContext reactContext)
        {
            return new WebView(BLANK_URL)
            {
                HorizontalAlignment = HorizontalAlignment.Stretch,
            };
        }

      
    }
}
