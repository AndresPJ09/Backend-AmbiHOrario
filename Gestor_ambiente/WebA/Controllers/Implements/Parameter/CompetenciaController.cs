using Entity.Dto.Parameter;
using Entity.Dto;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces.Parameter;
using WebA.Controllers.Interfaces.Parameter;

namespace WebA.Controllers.Implements.Parameter
{
    [Route("api/Competencia")]
    [ApiController]
    public class CompetenciaController : ControllerBase, ICompetenciaController
    {
        protected readonly ICompetenciaService business;

        public CompetenciaController(ICompetenciaService business)
        {
            this.business = business;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse<CompetenciaDto>>> Get(int id)
        {
            var result = await business.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse<IEnumerable<CompetenciaDto>>>> GetAll()
        {
            var result = await business.GetAll();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CompetenciaDto competencia)
        {
            if (competencia == null)
            {
                return BadRequest("Entity is null.");
            }
            var result = await business.Save(competencia);
            return CreatedAtAction(nameof(Get), new { id = result.Id }, result);
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] CompetenciaDto competencia)
        {
            if (competencia == null)
            {
                return BadRequest();
            }
            await business.Update(competencia);
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
