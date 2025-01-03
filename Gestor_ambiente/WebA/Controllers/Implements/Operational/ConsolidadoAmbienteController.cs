using Entity.Dto;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces.Operational;
using WebA.Controllers.Interfaces.Operational;
using Entity.Model.Operational;
using Entity.Dto.Operational;

namespace WebA.Controllers.Implements.Operational
{
    [Route("api/ConsolidadoAmbiente")]
    [ApiController]
    public class ConsolidadoAmbienteController : ControllerBase, IConsolidadoAmbienteController
    {
        protected readonly IConsolidadoAmbienteService business;

        public ConsolidadoAmbienteController(IConsolidadoAmbienteService business)
        {
            this.business = business;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse<ConsolidadoAmbienteDto>>> Get(int id)
        {
            var result = await business.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse<IEnumerable<ConsolidadoAmbienteDto>>>> GetAll()
        {
            var result = await business.GetAll();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ConsolidadoAmbienteDto consolidadoAmbiente)
        {
            if (consolidadoAmbiente == null)
            {
                return BadRequest("Entity is null.");
            }
            var result = await business.Save(consolidadoAmbiente);
            return CreatedAtAction(nameof(Get), new { id = result.Id }, result);
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] ConsolidadoAmbienteDto consolidadoAmbiente)
        {
            if (consolidadoAmbiente == null)
            {
                return BadRequest();
            }
            await business.Update(consolidadoAmbiente);
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
