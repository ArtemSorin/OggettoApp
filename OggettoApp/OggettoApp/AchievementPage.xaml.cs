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
    public partial class AchievementPage : ContentPage
    {
        UserRepository repos = new UserRepository();
        public AchievementPage(User user)
        {
            InitializeComponent();

            List<ImageButton> list = new List<ImageButton>()
            {
                btn1, btn2, btn3, btn4, btn5, btn6,
            };

            for(int i = 0; i < list.Count; i++) 
            {
                if (!user.achivements[i])
                {
                    list[i].IsEnabled= false;
                }
            }
        }
    }
}