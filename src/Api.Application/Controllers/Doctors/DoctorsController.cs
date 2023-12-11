using System;
using System.Threading.Tasks;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Doctor;
using Microsoft.AspNetCore.Mvc;

namespace Api.Application.Controllers.Users
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private readonly IDoctorService _doctorService;

        public DoctorsController(IDoctorService doctorService)
        {
            _doctorService = doctorService ?? throw new ArgumentNullException(nameof(doctorService));
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
                var doctors = await _doctorService.GetAllAsync();
                return Ok(doctors); //200
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}"); //500
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDoctorById(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); //400 
            }
            try
            {
                var doctor = await _doctorService.GetAsync(id);

                if (doctor == null)
                    return NotFound(); // Retornar 404 se o usuário não for encontrado

                return Ok(doctor); //200
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}"); //500
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] DoctorEntity doctor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); //400 
            }
            try
            {
                var createdDoctor = await _doctorService.PostAsync(doctor);
                if (createdDoctor != null)
                {
                    return CreatedAtAction(nameof(GetDoctorById), new { id = createdDoctor.IdDoctor }, createdDoctor); //201
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
        public async Task<IActionResult> UpdateUser([FromBody] DoctorEntity doctor)
        {
            try
            {
                var updatedDoctor = await _doctorService.PutAsync(doctor);

                if (updatedDoctor == null)
                    return NotFound(); // Retornar 404 se o usuário não for encontrado

                return Ok(updatedDoctor); //200
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
                var deletedDoctor = await _doctorService.DeleteAsync(id);

                if (deletedDoctor == null)
                    return NotFound(); // Retornar 404 se o usuário não for encontrado

                return Ok(deletedDoctor); //200
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}"); //500
            }
        }
    }
}
