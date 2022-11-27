using System;
using System.Collections.Generic;
using System.Text;

namespace OggettoApp
{
    public class User
    {
        public string Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }
        public string Email { get; set; }
        public string Adress { get; set; }
        public string WorkAdress { get; set; }
        public List<bool> achivements { get; set; }
    }
}
