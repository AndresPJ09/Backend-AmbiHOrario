using Entity.Dto.Operational;
using Entity.Dto;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces.Operational;
using Service.Interfaces.Security;
using WebA.Controllers.Interfaces.Operational;
using WebA.Controllers.Interfaces.Security;

namespace WebA.Controllers.Implements.Operational
{
    [Route("api/ConsolidadoHorario")]
    [ApiController]
    public class ConsolidadoHorarioController : ControllerBase, IConsolidadoHorarioController
    {
        protected readonly IConsolidadoHorarioService business;

        public ConsolidadoHorarioController(IConsolidadoHorarioService business)
        {
            this.business = business;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse<ConsolidadoHorarioDto>>> Get(int id)
        {
            var result = await business.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse<IEnumerable<ConsolidadoHorarioDto>>>> GetAll()
        {
            var result = await business.GetAll();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ConsolidadoHorarioDto entity)
        {
            if (entity == null)
            {
                return BadRequest("Entity is null.");
            }
            var result = await business.Save(entity);
            return CreatedAtAction(nameof(Get), new { id = result.Id }, result);
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] ConsolidadoHorarioDto entity)
        {
            if (entity == null)
            {
                return BadRequest();
            }
            await business.Update(entity);
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
