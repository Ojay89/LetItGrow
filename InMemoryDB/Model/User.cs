using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InMemoryDB.Model
{
    public class User
    {

        private int _id;
        private string _username;
        private string _password;
        private string _email;
        private List<Plant> _plants = new List<Plant>();

        public User(string userName, string password, string email, List<Plant> plants)
        {
            
            Username = userName;
            Password = password;
            Email = email;
            Plants = plants;
        }   

        public User()
        {

        }



        public int Id { get { return _id; } set { _id = value; } }
        public string Username { get { return _username; } set { _username = value; } }
        public string Password { get { return _password; } set { _password = value; } }
        public string Email { get { return _email; } set { _email = value; } }
        public List<Plant> Plants { get { return _plants; } set { _plants = value; } }
    }
    
}