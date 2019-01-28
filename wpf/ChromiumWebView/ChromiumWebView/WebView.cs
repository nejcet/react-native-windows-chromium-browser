using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;
using System.Windows.Controls;
using ReactNative.Views.ControlView;
using System.Windows;

namespace ChromiumWebView
{
    class WebView : EO.Wpf.WebControl, IDisposable
    {

        public WebView(String url) : base()
        {
            this.WebView.Url = url;
        }

        public String currentUrl
        {
            get {
                return this.WebView.Url;
            }
            set {
                this.WebView.Url = value;
            }
        }

        public void setCurrentUrl(String url)
        {
            this.WebView.Url = url;
        }

        public void NavigateToString(String html)
        {
            this.WebView.LoadHtml(html);
        }

        public void NavigateToString(String html, String basePath)
        {
            this.WebView.LoadHtml(html, basePath);
        }

        public void Dispose()
        {
            // TODO: cleanup webview
        }
    }
}
