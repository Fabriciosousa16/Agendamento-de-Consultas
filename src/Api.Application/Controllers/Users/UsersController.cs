using System;
using System.Net;
using System.Threading.Tasks;
using Api.Domain.Entities;
using Api.Domain.Interfaces.User;
using Microsoft.AspNetCore.Mvc;

namespace Api.Application.Controllers.Users
{
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
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

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] UserEntity user)
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

        [HttpPut]
        public async Task<IActionResult> UpdateUser([FromBody] UserEntity user)
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
