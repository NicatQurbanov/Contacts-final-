using System;
using System.Collections.Generic;
using System.Text;

namespace Contact.Models
{
    public class User
    {
        public string nickname, password;
        public Contact[] contacts;

        public User(string nickname, string password)
        {
            this.nickname = nickname;
            this.password = password;
            contacts = new Contact[1];
        }
    }
}