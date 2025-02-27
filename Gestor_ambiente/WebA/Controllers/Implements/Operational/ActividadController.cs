﻿using Entity.Dto.Operational;
using Entity.Dto;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces.Operational;
using WebA.Controllers.Interfaces.Operational;
using Entity.Model.Parameter;

namespace WebA.Controllers.Implements.Operational
{
    [Route("api/Actividad")]
    [ApiController]
    public class ActividadController : ControllerBase, IActividadController
    {
        protected readonly IActividadService business;

        public ActividadController(IActividadService business)
        {
            this.business = business;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse<ActividadDto>>> Get(int id)
        {
            var result = await business.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse<IEnumerable<ActividadDto>>>> GetAll()
        {
            var result = await business.GetAll();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ActividadDto actividad)
        {
            if (actividad == null)
            {
                return BadRequest("Entity is null.");
            }
            try
            {
                var result = await business.Save(actividad);
                return CreatedAtAction(nameof(Get), new { id = result.Id }, result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] ActividadDto actividad)
        {
            if (actividad == null)
            {
                return BadRequest();
            }
            try
            {
                await business.Update(actividad);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await business.Delete(id);
            return NoContent();
        }
    }
}
