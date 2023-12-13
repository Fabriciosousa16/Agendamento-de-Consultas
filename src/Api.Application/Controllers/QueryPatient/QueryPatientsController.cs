using System;
using System.Threading.Tasks;
using Api.Domain.Dtos.QueryPatient;
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
                var patients = await _queryPatientService.GetAllAsync();
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

        [HttpPost]
        [Authorize("Bearer")]
        [Authorize("patient")]
        public async Task<IActionResult> CreateUser([FromBody] QueryPatientDtoCreate queryPatient)
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

        [HttpPut]
        [Authorize("Bearer")]
        [Authorize("patient")]
        public async Task<IActionResult> UpdateUser([FromBody] QueryPatientDtoUpdate queryPatient)
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
