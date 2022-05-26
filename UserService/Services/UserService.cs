using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Text;
using UserService.Models;
using Microsoft.Extensions.Configuration;
using System.IO;

using TweetService.DataAccess;

namespace UserService
{

    public class UserService : IUserService
    {
        private readonly UserContext _db;

        public UserService(UserContext db)
        {
            _db = db;

        }


        public List<Users> getAll()
        {
            var users = _db.users.ToList();
            return users;
        }

        public List<Users> getUserByUserID(int userId)
        {
            var users = _db.users.Where(x => x.UserID == userId).ToList();
            return users;
        }

        Users IUserService.getUserByUserID(int userId)
        {
            throw new NotImplementedException();
        }

        public Users login(String username, String password)
        {
            //String encpassword = EncryptionHelper.Encrypt(password);
            var users = _db.users.Where(x => x.Username == username && x.Password == password).ToList();
            List<Users> ulist = users;
            Users u = new Users();
            foreach (Users user in ulist)
            {
                u = user;
            }
            return u;
        }

        public int register(String username, String password, String email)
        {
            String encpassword = EncryptionHelper.Encrypt(password);
            var emails = _db.users.Where(x => x.Username == username).ToList();
            List<Users> emaillist = emails;
            var usernames = _db.users.Where(x => x.Email == email).ToList();
            List<Users> usernamelist = usernames;

            //check of er al een gebruiker bestaat met die naam of email
            if (emaillist.Count < 1 && usernamelist.Count < 1)
            {
                var user = new Users { Username = username, Password = encpassword, Email = email };
                _db.users.Add(user);
                _db.SaveChanges();
            }

            //get userid van gemaakte user
            var users = _db.users.Where(x => x.Username == username && x.Password == encpassword).ToList();
            List<Users> ulist = users;
            Users us = new Users();
            foreach (Users user in ulist)
            {
                us = user;
            }
            return us.UserID;

        }
    }
}

