using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserService.Models;

namespace UserService.Controllers
{
    [ApiController]
    [Route("/user")]
    public class UserController : ControllerBase
    {

        private readonly ILogger<UserController> _logger;
        private IUserService iUserService;

        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
            iUserService = new UserService();
        }

        [HttpGet]
        public ActionResult<List<User>> getAll()
        {
            try
            {
                return Ok(iUserService.getAll());
            }
            catch 
            {
                return NotFound();
            }
        }

        [HttpGet("{userID}")]
        public ActionResult<User> getUserByUserID(int userID)
        {
            try
            {
                return Ok(iUserService.getUserByUserID(userID));
            }
            catch
            {
                return NotFound();
            }
        }
    }
}
