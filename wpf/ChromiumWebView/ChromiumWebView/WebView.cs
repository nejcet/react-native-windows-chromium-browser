using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CefSharp;
using CefSharp.Wpf;
using System.Windows.Threading;
using System.Windows.Controls;
using ReactNative.Views.ControlView;
using System.Windows;

namespace ChromiumWebView
{
    class WebView: ChromiumWebBrowser, IDisposable
    {
        private DispatcherTimer _cefInitTimer = null;
        private String _initUrl = String.Empty;

        public WebView(): base()
        {
            initCef();
        }

        private void initCef()
        {
            if (!Cef.IsInitialized)
            {
                if (Cef.Initialize(new CefSettings(), performDependencyCheck: true, browserProcessHandler: null))
                {
                    // IsInitialized
                }
                else
                {
                    // throw exception!!
                }
            }
        }

        private void startCefInitTimer()
        {
            if (_cefInitTimer == null)
            {
                _cefInitTimer = new DispatcherTimer();
                _cefInitTimer.Interval = TimeSpan.FromMilliseconds(3000.0);
                _cefInitTimer.Tick += OnInitTimerTick;
                _cefInitTimer.Start();
            }
        }

        private void stopCefInitTimer()
        {
            _initUrl = String.Empty;

            if (_cefInitTimer != null)
            {
                _cefInitTimer.Tick -= OnInitTimerTick;
                _cefInitTimer.Stop();
            }
        }

        private void OnInitTimerTick(object sender, object e)
        {
            if (_cefInitTimer != null)
            {
                if ( Cef.IsInitialized && this.IsInitialized)
                {
                    this.Load(_initUrl);
                    stopCefInitTimer();
                }
            }
        }

        

        public void Cleanup()
        {
            stopCefInitTimer();
            this.Dispose();
        }

        public string Source
        {
            set
            {
                if (this.IsInitialized)
                {
                    this.Load(value);
                }
                else
                {
                    _initUrl = value;
                    startCefInitTimer();
                }
            }
        }

    }
}
