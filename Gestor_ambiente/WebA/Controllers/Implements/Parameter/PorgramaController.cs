﻿using Entity.Dto.Parameter;
using Entity.Dto;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces.Parameter;
using WebA.Controllers.Interfaces.Parameter;
namespace WebA.Controllers.Implements.Parameter
{
    [Route("api/Programa")]
    [ApiController]
    public class PorgramaController : ControllerBase, IProgramaController
    {
        protected readonly IProgramaService business;

        public PorgramaController(IProgramaService business)
        {
            this.business = business;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse<ProgramaDto>>> Get(int id)
        {
            var result = await business.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse<IEnumerable<ProgramaDto>>>> GetAll()
        {
            var result = await business.GetAll();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ProgramaDto programa)
        {
            if (programa == null)
            {
                return BadRequest("Entity is null.");
            }
            var result = await business.Save(programa);
            return CreatedAtAction(nameof(Get), new { id = result.Id }, result);
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] ProgramaDto programa)
        {
            if (programa == null)
            {
                return BadRequest();
            }
            await business.Update(programa);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await business.Delete(id);
            return NoContent();
        }

        [HttpGet("AllSelect")]
        public async Task<ActionResult<ApiResponse<IEnumerable<DataSelectDto>>>> GetAllSelect()
        {
            var result = await business.GetAllSelect();
            return Ok(result);
        }
    }
}
