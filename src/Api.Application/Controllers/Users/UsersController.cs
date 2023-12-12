using System;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Dtos.User;
using Api.Domain.Entities;
using Api.Domain.Interfaces.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Application.Controllers.Users
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        }

        [Authorize("Bearer")]
        //[Authorize("AdministratorPolicy")]
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var claims = User.Claims.Select(c => $"{c.Type}: {c.Value}");
            Console.WriteLine($"User Claims: {string.Join(", ", claims)}");

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); //400 
            }
            try
            {
                var users = await _userService.GetAllAsync();
                return Ok(users); //200
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}"); //500
            }
        }

        [Authorize("Bearer")]
        //[Authorize("AdministratorPolicy")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); //400 
            }
            try
            {
                var user = await _userService.GetAsync(id);

                if (user == null)
                    return NotFound(); // Retornar 404 se o usuário não for encontrado

                return Ok(user); //200
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}"); //500
            }
        }

        [Authorize("Bearer")]
        //[Authorize("AdministratorPolicy")]
        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] UserDtoCreate user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); //400 
            }
            try
            {
                var createdUser = await _userService.PostAsync(user);
                if (createdUser != null)
                {
                    return CreatedAtAction(nameof(GetUserById), new { id = createdUser.IdUser }, createdUser); //201
                }
                else
                {
                    return BadRequest(ModelState); //400 
                }

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");//500
            }
        }
        [Authorize("Bearer")]
        //[Authorize("AdministratorPolicy")]
        [HttpPut]
        public async Task<IActionResult> UpdateUser([FromBody] UserDtoUpdate user)
        {
            try
            {
                var updatedUser = await _userService.PutAsync(user);

                if (updatedUser == null)
                    return NotFound(); // Retornar 404 se o usuário não for encontrado

                return Ok(updatedUser); //200
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}"); //500
            }
        }

        [Authorize("Bearer")]
        //[Authorize("AdministratorPolicy")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); //400 
            }

            try
            {
                var deletedUser = await _userService.DeleteAsync(id);

                if (deletedUser == null)
                    return NotFound(); // Retornar 404 se o usuário não for encontrado

                return Ok(deletedUser); //200
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}"); //500
            }
        }
    }
}
