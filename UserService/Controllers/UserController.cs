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
        public ActionResult<List<Users>> login(String username, String password)
        {
            try
            {
                return Ok(_service.login(username, password));
            }
            catch
            {
                return NotFound();
            }
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
