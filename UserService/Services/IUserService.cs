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

namespace UserService
{

    public interface IUserService 
    {

        List<User> getAll();

        User getUserByUserID(int userId);

    }
}

