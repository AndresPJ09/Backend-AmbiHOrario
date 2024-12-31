using Entity.Dto.Operational;
using Entity.Dto;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces.Operational;
using WebA.Controllers.Interfaces.Operational;

namespace WebA.Controllers.Implements.Operational
{
    [Route("api/Ficha")]
    [ApiController]
    public class FichaController : ControllerBase, IFichaController
    {
        protected readonly IFichaService business;

        public FichaController(IFichaService business)
        {
            this.business = business;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse<FichaDto>>> Get(int id)
        {
            var result = await business.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse<IEnumerable<FichaDto>>>> GetAll()
        {
            var result = await business.GetAll();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] FichaDto nivel)
        {
            if (nivel == null)
            {
                return BadRequest("Entity is null.");
            }
            var result = await business.Save(nivel);
            return CreatedAtAction(nameof(Get), new { id = result.Id }, result);
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] FichaDto nivel)
        {
            if (nivel == null)
            {
                return BadRequest();
            }
            await business.Update(nivel);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await business.Delete(id);
            return NoContent();
        }
    }
}
