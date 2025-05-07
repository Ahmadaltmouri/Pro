using Pro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pro.Managers
{
    public class UserManager
    {
        private List<User> users = new List<User>();
          
        public UserManager()
        {
            users=new List<User>() { 
             new User { Username = "admin", Password = "admin" },
             new User { Username = "user", Password = "user" },
             new User { Username = "guest", Password = "guest" }
            
            };
        }

     
        public void RegisterUser(string username, string password)
        {
            if (users.Exists(u => u.Username == username))
            {
                throw new ArgumentException("Username already exists.");
            }
            users.Add(new User { Username = username, Password = password });
        }

       
        public User LoginUser(string username, string password)
        {
            var user = users.Find(u => u.Username == username && u.Password == password);
            return user;
        }

     
        public void RemoveUser(string username)
        {
            var user = users.Find(u => u.Username == username);
            if (user == null)
            {
                throw new ArgumentException("User not found.");
            }
            users.Remove(user);
        }

        public User SearchUser(string username)
        {
            return users.Find(u => u.Username == username);
        }
    }
}
