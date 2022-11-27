using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OggettoApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistrationPage : ContentPage
    {
        UserRepository repos = new UserRepository();
        public RegistrationPage()
        {
            InitializeComponent();

            btn.Clicked += SignIn;
        }
        private async void CreateFriend(object sender, EventArgs e)
        {
            RegistrationPage userpage = new RegistrationPage();
            await Navigation.PushAsync(userpage);
        }
        private async void SignIn(object sender, EventArgs e)
        {
            UserRepository repos = new UserRepository();

            var data = await repos.GetAllUsers();

            bool flag = false;
            string ID = "0";

            foreach (var item in data)
            {
                if (item.Login == UserLogin.Text && item.Password == HashPassword(UserPassword.Text))
                {
                    flag = true;
                    ID = item.Id;
                }
            }

            if (flag)
            {
                var user = await repos.GetByIdUser(ID);
                user.Id = ID;

                string value = UserLogin.Text;

                App.Current.Properties["name"] = value;

                await Navigation.PushAsync(new MainPage(user));
            }

            else
            {
                await DisplayAlert("Уведомление", "Неправильный логин или пароль", "Ок");
            }
        }
        private string HashPassword(string password)
        {
            using (SHA256 sHA256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(password);

                byte[] hash = sHA256.ComputeHash(bytes);

                string hash_password = BitConverter.ToString(hash).Replace("-", "").ToLower();

                return hash_password;
            }
        }
    }
}