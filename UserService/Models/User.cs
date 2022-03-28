using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserService.Models
{
    public class User
    {
        public User()
        {
            followers = new List<User>();
            following = new List<User>();
        }

        public int userID { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public List<User> followers { get; set; }
        public List<User> following { get; set; }

    }
}
