using System;
using System.Threading.Tasks;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Query;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Application.Controllers.Querys
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuerysController : ControllerBase
    {
        private readonly IQueryService _queryService;

        public QuerysController(IQueryService queryService)
        {
            _queryService = queryService ?? throw new ArgumentNullException(nameof(queryService));
        }

        [Authorize("Bearer")]
        //[Authorize("AdministratorPolicy")]
        //[Authorize("DoctorPolicy")]
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); //400 
            }
            try
            {
                var querys = await _queryService.GetAllAsync();
                return Ok(querys); //200
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}"); //500
            }
        }

        [Authorize("Bearer")]
        //[Authorize("AdministratorPolicy")]
        //[Authorize("DoctorPolicy")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetQueryById(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); //400 
            }
            try
            {
                var query = await _queryService.GetAsync(id);

                if (query == null)
                    return NotFound(); // Retornar 404 se o usuário não for encontrado

                return Ok(query); //200
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}"); //500
            }
        }

        [Authorize("Bearer")]
        //[Authorize("AdministratorPolicy")]
        //[Authorize("DoctorPolicy")]
        [HttpPost]
        public async Task<IActionResult> CreateQuery([FromBody] QueryEntity query)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); //400 
            }
            try
            {
                var createdQuery = await _queryService.PostAsync(query);
                if (createdQuery != null)
                {
                    return CreatedAtAction(nameof(GetQueryById), new { id = createdQuery.IdQuery }, createdQuery); //201
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
        //[Authorize("DoctorPolicy")]
        [HttpPut]
        public async Task<IActionResult> UpdateQuery([FromBody] QueryEntity query)
        {
            try
            {
                var updatedQuery = await _queryService.PutAsync(query);

                if (updatedQuery == null)
                    return NotFound(); // Retornar 404 se o usuário não for encontrado

                return Ok(updatedQuery); //200
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}"); //500
            }
        }

        [Authorize("Bearer")]
        //[Authorize("AdministratorPolicy")]
        //[Authorize("DoctorPolicy")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); //400 
            }

            try
            {
                var deletedQuery = await _queryService.DeleteAsync(id);

                if (deletedQuery == null)
                    return NotFound(); // Retornar 404 se o usuário não for encontrado

                return Ok(deletedQuery); //200
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}"); //500
            }
        }
    }
}
