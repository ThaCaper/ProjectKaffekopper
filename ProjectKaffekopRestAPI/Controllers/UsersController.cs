using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectKaffekop.Core.AppService;
using ProjectKaffekop.Core.DomainService;
using ProjectKaffekop.Core.Entity;

namespace ProjectKaffekopRestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        // GET api/users -- read all
        [HttpGet]
        public ActionResult<IEnumerable<User>> GetAllUsers()
        {
            return _userService.GetAllUsers();
        }

        // GET api/users/5 -- read by Id
        [HttpGet("{id}")]
        public ActionResult<User> Get(int id)
        {
            return _userService.GetUserById(id);
        }

        // POST api/users --Create JSON
        [HttpPost]
        public ActionResult<User> Post([FromBody] User user)
        {
            return _userService.CreateUser(user);
        }

        // PUT api/user/5 -- Update
        [HttpPut("{id}")]
        public ActionResult<User> Put(int id, [FromBody] User user)
        {
            if (id < 1 || id != user.Id)
            {
                return BadRequest("Parameter Id and CoffeeCup id must be the same");
            }
            return Ok(_userService.UpdateUser(user));
        }

        // DELETE api/user/5
        [HttpDelete("{id}")]
        public ActionResult<User> Delete(int id)
        {
            var cc = _userService.DeleteUserById(id);
            if (cc == null)
            {
                return StatusCode(404, "Did not find any Coffee Cups with the Id" + id);
            }

            return NoContent();
        }
    }
}