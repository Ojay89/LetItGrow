using LetItGrowInMemoryDB.Model;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace LetItGrowInMemoryDB.model
{
    public class User
    {

        private int _id;
        private string _username;
        private string _password;
        private string _email;
        private List<Plant> _plants = new List<Plant>();



        public User( )
        {

        }

        public User( string userName, string password, string email, List<Plant> plants)
        {
          
            Username = userName;
            Password = password;
            Email = email;
            Plants = plants;

        }


        

        public int Id { get { return _id; } set { _id = value; } }
        public string Username { get { return _username; } set { _username = value; } }
        public string Password { get { return _password; } set { _password = value; } }
        public string Email { get { return _email; } set { _email = value; } }
       public List<Plant> Plants { get { return _plants; } set { _plants = value; } }

    }
}
