using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OggettoApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WebPage : ContentPage
    {
        WebView webView;
        public WebPage(string url)
        {
            InitializeComponent();
            StackLayout stack = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
            };
            webView = new WebView
            {
                Source = new UrlWebViewSource { Url = $"{url}" },
                VerticalOptions = LayoutOptions.FillAndExpand
            };
            this.Content = new StackLayout { Children = { stack, webView } };
        }
    }
}