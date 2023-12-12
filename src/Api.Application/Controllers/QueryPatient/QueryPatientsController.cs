using System;
using System.Threading.Tasks;
using Api.Domain.Entities;
using Api.Domain.Interfaces.QueryPartient;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Application.Controllers.Patients
{
    [Route("api/[controller]")]
    [ApiController]
    public class QueryPatientsController : ControllerBase
    {
        private readonly IQueryPartientService _queryPatientService;

        public QueryPatientsController(IQueryPartientService queryPatientService)
        {
            _queryPatientService = queryPatientService ?? throw new ArgumentNullException(nameof(queryPatientService));
        }

        [Authorize("Bearer")]
        //[Authorize("AdministratorPolicy")]
        //[Authorize("PatientPolicy")]
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); //400 
            }
            try
            {
                var patients = await _queryPatientService.GetAllAsync();
                return Ok(patients); //200
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}"); //500
            }
        }

        [Authorize("Bearer")]
        //[Authorize("AdministratorPolicy")]
        //[Authorize("PatientPolicy")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPatientById(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); //400 
            }
            try
            {
                var queryPatient = await _queryPatientService.GetAsync(id);

                if (queryPatient == null)
                    return NotFound(); // Retornar 404 se o usuário não for encontrado

                return Ok(queryPatient); //200
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}"); //500
            }
        }

        [Authorize("Bearer")]
        //[Authorize("AdministratorPolicy")]
        //[Authorize("PatientPolicy")]
        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] QueryPartientEntity queryPatient)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); //400 
            }
            try
            {
                var createdqueryPatient = await _queryPatientService.PostAsync(queryPatient);
                if (createdqueryPatient != null)
                {
                    return CreatedAtAction(nameof(GetPatientById), new { id = createdqueryPatient.IdQueryPartient }, createdqueryPatient); //201
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
        //[Authorize("PatientPolicy")]
        [HttpPut]
        public async Task<IActionResult> UpdateUser([FromBody] QueryPartientEntity queryPatient)
        {
            try
            {
                var updatedqueryPatient = await _queryPatientService.PutAsync(queryPatient);

                if (updatedqueryPatient == null)
                    return NotFound(); // Retornar 404 se o usuário não for encontrado

                return Ok(updatedqueryPatient); //200
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}"); //500
            }
        }

        [Authorize("Bearer")]
        //[Authorize("AdministratorPolicy")]
        //[Authorize("PatientPolicy")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); //400 
            }

            try
            {
                var deletedqueryPatient = await _queryPatientService.DeleteAsync(id);

                if (deletedqueryPatient == null)
                    return NotFound(); // Retornar 404 se o usuário não for encontrado

                return Ok(deletedqueryPatient); //200
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}"); //500
            }
        }
    }
}
