using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserService.Models;

namespace TweetService.DataAccess
{
    public class UserContext : DbContext
    {
        //entity framework
        public UserContext(DbContextOptions<UserContext> options) : base(options) { }

        public DbSet<Users> users { get; set; }

        public DbSet<Following> following { get; set; }

    }
}