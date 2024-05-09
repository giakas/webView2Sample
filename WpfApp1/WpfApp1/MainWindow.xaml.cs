using Microsoft.Web.WebView2.Core;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private Microsoft.Web.WebView2.Wpf.WebView2 webView;

        public MainWindow()
        {
            InitializeComponent();
            webView = new Microsoft.Web.WebView2.Wpf.WebView2();
            webView.NavigationCompleted += WebView2_NavigationCompleted;
            webView.WebMessageReceived += WebView2_WebMessageReceived;
            //webView.CoreWebView2InitializationCompleted += WebView2_Loaded;
            WebView2_Initialize();
        }

        private async void WebView2_Initialize()
        {
            webView.CreationProperties = new Microsoft.Web.WebView2.Wpf.CoreWebView2CreationProperties
            {
                IsInPrivateModeEnabled = true
            };

            await webView.EnsureCoreWebView2Async();
            //webView.CoreWebView2.AddHostObjectToScript("bridge", new BridgeRemoteObject());
            webView.Source = new System.Uri("https://www.bing.com");

            dockPanel.Children.Add(webView);
        }

        private void WebView2_NavigationCompleted(object sender, CoreWebView2NavigationCompletedEventArgs args)
        {
            StatusUpdate("Navigation complete");
        }

        private void WebView2_WebMessageReceived(object sender, CoreWebView2WebMessageReceivedEventArgs args)
        {
            Debug.WriteLine(args);
        }

        private void StatusUpdate(string message)
        {
            Debug.WriteLine(message);
        }
    }
}