using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TweetService.DataAccess;
using UserService.Models;

namespace UserService.Controllers
{
    [ApiController]
    [Route("/user")]
    public class UserController : ControllerBase
    {

        private readonly ILogger<UserController> _logger;
        private IUserService _service;
        private readonly UserContext _db;

        public UserController(UserContext db)
        {
            _db = db;
            _service = new UserService(_db);

        }

        [HttpGet]
        public ActionResult<List<Users>> getAll()
        {
            try
            {
                return Ok(_service.getAll());
            }
            catch 
            {
                return NotFound();
            }
        }

        [HttpGet("{userID}")]
        public ActionResult<Users> getUserByUserID(int userID)
        {
            try
            {
                return Ok(_service.getUserByUserID(userID));
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpGet("/login")]
        public ActionResult<int> login(String username, String password)
        {
            try
            {
                return _service.login(username, password);
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpGet("/test")]
        public ActionResult<List<Users>> test()
        {
            Users een = new Users("bas", "ww", "test");
            Users twee = new Users("bas", "ww", "test");
            Users drie = new Users("bas", "ww", "test");
            List<Users> users = new List<Users>();
            users.Add(een); users.Add(twee); users.Add(drie);
            return users;
        }

        [HttpGet("/register")]
        public ActionResult<List<Users>> register(String username, String password, String email)
        {
            try
            {
                return Ok(_service.register(username, password, email));
            }
            catch
            {
                return NotFound();
            }
        }
    }
}
