using System;
using System.Threading.Tasks;
using Api.Domain.Dtos.Doctor;
using Api.Domain.Interfaces.Doctor;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Application.Controllers.Doctors
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
        [Authorize("Bearer")]
        [Authorize("doctor")]

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

        [Authorize("Bearer")]
        [Authorize("doctor")]
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

        [Authorize("Bearer")]
        [Authorize("doctor")]
        public async Task<IActionResult> CreateUser([FromBody] DoctorDtoCreate doctor)
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

        [Authorize("Bearer")]
        [Authorize("doctor")]
        public async Task<IActionResult> UpdateUser([FromBody] DoctorDtoUpdate doctor)
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

        [Authorize("Bearer")]
        [Authorize("doctor")]
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
