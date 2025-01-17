using Entity.Dto.Operational;
using Entity.Dto;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces.Operational;
using WebA.Controllers.Interfaces.Parameter;
using Service.Interfaces.Parameter;
using Entity.Dto.Parameter;

namespace WebA.Controllers.Implements.Parameter
{
    [Route("api/Periodo")]
    [ApiController]
    public class PeriodoController : ControllerBase, IPeriodoController
    {
        protected readonly IPeriodoService business;

        public PeriodoController(IPeriodoService business)
        {
            this.business = business;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse<PeriodoDto>>> Get(int id)
        {
            var result = await business.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse<IEnumerable<PeriodoDto>>>> GetAll()
        {
            var result = await business.GetAll();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] PeriodoDto periodo)
        {
            // Validar los datos de entrada
            if (periodo == null)
            {
                return BadRequest("La entidad no puede ser nula.");
            }

            try
            {
                var result = await business.Save(periodo);
                return CreatedAtAction(nameof(Get), new { id = result.Id }, result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] PeriodoDto periodo)
        {
            if (periodo == null)
            {
                return BadRequest();
            }

            try
            {
                await business.Update(periodo);
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
