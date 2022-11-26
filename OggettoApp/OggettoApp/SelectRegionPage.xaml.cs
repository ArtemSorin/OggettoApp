using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OggettoApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SelectRegionPage : ContentPage
    {
        public SelectRegionPage()
        {
            InitializeComponent();

            back_btn.Clicked += (s, e) => Navigation.PopAsync();

            btn1.Clicked += (s, e) => Navigation.PushAsync(new GamePage());
        }
    }
}