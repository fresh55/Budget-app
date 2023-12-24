using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BudgetApi.Data;
using BudgetApi.Interfaces;
using BudgetApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BudgetApi.Controllers
{
[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{
     private readonly IUserService _userService;
     private readonly ILogger<UsersController> _logger;

   public UsersController(IUserService userService, ILogger<UsersController> logger)
{
    _userService = userService;
    _logger = logger;
}

    // GET: api/Users
     [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {   _logger.LogInformation($"Creating user");
            return Ok(await _userService.GetAllUsersAsync());
        }

    // GET: api/Users/5
    [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return user;
        }

    // POST: api/Users
    [HttpPost]
    public async Task<ActionResult<User>> PostUser(User user)
        {
            var createdUser = await _userService.CreateUserAsync(user);
            return CreatedAtAction(nameof(GetUser), new { id = createdUser.UserId }, createdUser);
        }

    // PUT: api/Users/5
    [HttpPut("{id}")]
       public async Task<IActionResult> PutUser(int id, User user)
        {
            if (id != user.UserId)
            {
                return BadRequest();
            }

            await _userService.UpdateUserAsync(user);
            return NoContent();
        }

    // DELETE: api/Users/5
    [HttpDelete("{id}")]
     public async Task<IActionResult> DeleteUser(int id)
        {
            await _userService.DeleteUserAsync(id);
            return NoContent();
        }

 public class UserCreationRequest
{
    public string Username { get; set; }
    public string Email { get; set; }
}

[HttpPost("createWithDetails")]
public async Task<ActionResult<User>> CreateUserWithDetails([FromBody] UserCreationRequest request)
{
    _logger.LogInformation($"Creating user with username: {request.Username} and email: {request.Email}");
    var user = await _userService.CreateUserWithDetailsAsync(request.Username, request.Email);
    return CreatedAtAction(nameof(GetUser), new { id = user.UserId }, user);
}

}
}