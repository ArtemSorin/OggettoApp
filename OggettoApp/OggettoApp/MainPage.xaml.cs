using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace OggettoApp
{
    public partial class MainPage : TabbedPage
    {
        public MainPage(User user)
        {
            InitializeComponent();

            string ID = user.Id;

            List<Frame> list= new List<Frame>()
            {
                framegl1, framegl2, framegl3
            };

            avaimage.Text = user.Name;
            avaimag.Text = user.Name;
            phone_number.Text = user.Number;
            mail.Text = user.Email;
            address.Text = user.Adress;
            work.Text = user.WorkAdress;

            medical.Clicked += (s, e) => Navigation.PushAsync(new MedicalPage());
            references.Clicked += (s, e) => Navigation.PushAsync(new ReferencesPage());

            game_button.Clicked += (s, e) => Navigation.PushAsync(new SelectRegionPage());
            game_btn.Clicked += (s, e) => Navigation.PushAsync(new SelectRegionPage()); ;
            adaptation.Clicked += (s, e) => Navigation.PushAsync(new AdaptationPage(user));
            achivement.Clicked += (s, e) => Navigation.PushAsync(new AchievementPage(user));

            button_web1.Clicked += (s, e) => Navigation.PushAsync(new WebPage("https://rutube.ru/video/fdc7db8075fb2bf791954318742beb04/"));
            button_web2.Clicked += (s, e) => Navigation.PushAsync(new WebPage("https://oggetto.academy/"));

            base_btn1.Clicked += (s, e) => setframe(0, list);
            base_btn2.Clicked += (s, e) => setframe(1, list);
            base_btn3.Clicked += (s, e) => setframe(2, list);
        }
        private void setframe(int index, List<Frame> list)
        {
            switch (index)
            {
                case 0:
                    list[1].IsVisible = false;
                    list[2].IsVisible = false;
                    list[0].IsVisible = true;
                    break;
                case 1:
                    list[0].IsVisible = false;
                    list[2].IsVisible = false;
                    list[1].IsVisible = true;
                    break;
                case 2:
                    list[1].IsVisible = false;
                    list[0].IsVisible = false;
                    list[2].IsVisible = true;
                    break;
            }
        }
    }
}
