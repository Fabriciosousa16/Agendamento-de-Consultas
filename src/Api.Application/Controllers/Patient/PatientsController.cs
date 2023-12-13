using System;
using System.Threading.Tasks;
using Api.Domain.Dtos.Patient;
using Api.Domain.Interfaces.Patient;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Application.Controllers.Patients
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly IPatientService _patientService;

        public PatientsController(IPatientService patientService)
        {
            _patientService = patientService ?? throw new ArgumentNullException(nameof(patientService));
        }


        [HttpGet]
        [Authorize("Bearer")]
        [Authorize("patient")]
        public async Task<IActionResult> GetAllUsers()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); //400 
            }
            try
            {
                var patients = await _patientService.GetAllAsync();
                return Ok(patients); //200
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}"); //500
            }
        }

        [HttpGet("{id}")]
        [Authorize("Bearer")]
        [Authorize("patient")]
        public async Task<IActionResult> GetPatientById(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); //400 
            }
            try
            {
                var patient = await _patientService.GetAsync(id);

                if (patient == null)
                    return NotFound(); // Retornar 404 se o usuário não for encontrado

                return Ok(patient); //200
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}"); //500
            }
        }

        [HttpPost]
        [Authorize("Bearer")]
        [Authorize("patient")]
        public async Task<IActionResult> CreateUser([FromBody] PatientDtoCreate patient)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); //400 
            }
            try
            {
                var createdPatient = await _patientService.PostAsync(patient);
                if (createdPatient != null)
                {
                    return CreatedAtAction(nameof(GetPatientById), new { id = createdPatient.IdPatient }, createdPatient); //201
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
        [Authorize("patient")]
        public async Task<IActionResult> UpdateUser([FromBody] PatientDtoUpdate patient)
        {
            try
            {
                var updatedPatient = await _patientService.PutAsync(patient);

                if (updatedPatient == null)
                    return NotFound(); // Retornar 404 se o usuário não for encontrado

                return Ok(updatedPatient); //200
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}"); //500
            }
        }

        [HttpDelete("{id}")]
        [Authorize("Bearer")]
        [Authorize("patient")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); //400 
            }

            try
            {
                var deletedPatient = await _patientService.DeleteAsync(id);

                if (deletedPatient == null)
                    return NotFound(); // Retornar 404 se o usuário não for encontrado

                return Ok(deletedPatient); //200
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}"); //500
            }
        }
    }
}
