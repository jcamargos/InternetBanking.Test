using System.Collections.Generic;
using System.Linq;
using Account.Domain.Contracts.Services;
using Account.Domain.Entity;
using Microsoft.AspNetCore.Mvc;

namespace Account.Api.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<User>> GetUsers()
        {
            return _userService.All().ToList();
        }


        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(User))]
        [ProducesResponseType(404)]
        public ActionResult<IEnumerable<User>> GetById(int id)
        {
            var user = _userService.FindById(id);

            if (user == null) { return NotFound(); }

            return Ok(user);
        }


        [HttpPost]
        [ProducesResponseType(201, Type = typeof(User))]
        public ActionResult<IEnumerable<User>> Post([FromBody] User user)
        {
            _userService.Save(user);

            return CreatedAtAction(nameof(GetById), new { id = user.Id }, user);
        }


        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult Put(int id, [FromBody] User user)
        {
            if (id != user.Id) { return NotFound(); }

            _userService.Update(user);

            return NoContent();
        }


        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult Delete(int id)
        {
            var user = _userService.GetById(id);

            if (user == null) { return NotFound(); }

            _userService.Remove(user);

            return NoContent();
        }
    }
}
