using EntityFrameworkCoreExample.DTO;
using EntityFrameworkCoreExample.Interfaces.Services;
using EntityFrameworkCoreExample.Models;
using Microsoft.AspNetCore.Mvc;

namespace EntityFrameworkCoreExample.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpGet]
        [ActionName("InitialDataLoad")]
        public IActionResult InitialDataLoad()
        {
            _userService.InitialDataLoad();
            return Ok();
        }

        [HttpGet]
        [ActionName("GetAllUsers")]
        public Response<List<User>> GetAllUsers()
        {
            return _userService.GetAllUsers();
        }

        [HttpGet]
        [ActionName("GetUserById")]
        public Response<User> GetUserById(Guid id)
        {
            return _userService.GetUser(id);
        }

        [HttpGet]
        [ActionName("GetUserByEmail")]
        public Response<User> GetUserByEmail(string email)
        {
            return _userService.GetUserByEmail(email);
        }


        [HttpPost]
        [ActionName("CreateUser")]
        public Response<User> CreateUser([FromBody] UserDTO user)
        {
            return _userService.AddUser(user);
        }


        [HttpPut]
        [ActionName("UpdateUser")]
        public Response<User> UpdateUser([FromBody] User user)
        {
            return _userService.UpdateUser(user);
        }



        [HttpDelete]
        [ActionName("DeleteUse")]
        public Response<User> DeleteUser(Guid id)
        {
            return _userService.DeleteUser(id);
        }

    }
}
