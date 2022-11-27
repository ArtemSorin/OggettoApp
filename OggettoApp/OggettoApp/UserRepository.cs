using Firebase.Database;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OggettoApp
{
    public class UserRepository
    {
        FirebaseClient firebaseClient = new FirebaseClient("https://oggettoapp-default-rtdb.europe-west1.firebasedatabase.app");

        public async Task<bool> SaveUser(User user)
        {
            var data = await firebaseClient.Child(nameof(User)).PostAsync(JsonConvert.SerializeObject(user));

            if (string.IsNullOrEmpty(data.Key))
            {
                return false;
            }

            return true;
        }

        public async Task<List<User>> GetAllUsers()
        {
            return (await firebaseClient.Child(nameof(User)).OnceAsync<User>()).Select(item => new User
            {
                Login = item.Object.Login,
                Password = item.Object.Password,
                Number = item.Object.Number,
                Email = item.Object.Email,
                Adress = item.Object.Adress,
                WorkAdress = item.Object.WorkAdress,
                achivements = item.Object.achivements,
                Id = item.Key,
            }).ToList();
        }

        public async Task<User> GetByIdUser(string id)
        {
            return (await firebaseClient.Child(nameof(User) + "/" + id).OnceSingleAsync<User>());
        }

        public async Task<bool> Update(User user)
        {
            await firebaseClient.Child(nameof(User) + "/" + user.Id).PutAsync(JsonConvert.SerializeObject(user));
            return true;
        }

    }
}
