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
    public partial class AdaptationPage : ContentPage
    {
        public AdaptationPage(User user)
        {
            InitializeComponent();
        }
    }
}