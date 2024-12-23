using Entity.Dto.Parameter;
using Entity.Dto;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces.Parameter;
using WebA.Controllers.Interfaces.Parameter;
using Entity.Model.Parameter;

namespace WebA.Controllers.Implements.Parameter
{
    [Route("api/Ambiente")]
    [ApiController]
    public class AmbienteController : ControllerBase, IAmbienteController
    {
        protected readonly IAmbienteService business;

        public AmbienteController(IAmbienteService business)
        {
            this.business = business;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse<AmbienteDto>>> Get(int id)
        {
            var result = await business.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse<IEnumerable<AmbienteDto>>>> GetAll()
        {
            var result = await business.GetAll();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] AmbienteDto ambiente)
        {
            if (ambiente == null)
            {
                return BadRequest("Entity is null.");
            }
            var result = await business.Save(ambiente);
            return CreatedAtAction(nameof(Get), new { id = result.Id }, result);
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] AmbienteDto ambiente)
        {
            if (ambiente == null)
            {
                return BadRequest();
            }
            await business.Update(ambiente);
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
