using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace InMemoryDB.Model
{
    public class User
    {

        private int _id;
        private string _username;
        private string _password;
        private string _email;

        public User(int id, string userName, string password, string email)
        {
            Id = id;
            Username = userName;
            Password = password;
            Email = email;
        }




        public int Id { get { return _id; } set { _id = value; } }
        public string Username { get { return _username; } set { _username = value; } }
        public string Password { get { return _password; } set { _password = value; } }
        public string Email { get { return _email; } set { _email = value; } }
    }
}
