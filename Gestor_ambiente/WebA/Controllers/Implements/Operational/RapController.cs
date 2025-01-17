using Entity.Dto.Security;
using Entity.Dto;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces.Security;
using WebA.Controllers.Interfaces.Operational;
using Service.Interfaces.Operational;
using Entity.Dto.Operational;

namespace WebA.Controllers.Implements.Operational
{
    [Route("api/Rap")]
    [ApiController]
    public class RapController : ControllerBase, IRapController
    {
        protected readonly IRapService business;

        public RapController(IRapService business)
        {
            this.business = business;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse<RapDto>>> Get(int id)
        {
            var result = await business.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse<IEnumerable<RapDto>>>> GetAll()
        {
            var result = await business.GetAll();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] RapDto rap)
        {
            // Validar los datos de entrada
            if (rap == null)
            {
                return BadRequest("La entidad no puede ser nula.");
            }

            try
            {
                var result = await business.Save(rap);
                return CreatedAtAction(nameof(Get), new { id = result.Id }, result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] RapDto rap)
        {
            if (rap == null)
            {
                return BadRequest();
            }

            try
            {
                await business.Update(rap);
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
