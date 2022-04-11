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
    }
}

