using Entity.Dto.Parameter;
using Entity.Dto;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces.Parameter;
using WebA.Controllers.Interfaces.Parameter;
using Entity.Model.Parameter;

namespace WebA.Controllers.Implements.Parameter
{
    [Route("api/Nivel")]
    [ApiController]
    public class NivelController : ControllerBase, INivelController
    {
        protected readonly INivelService business;

        public NivelController(INivelService business)
        {
            this.business = business;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse<NivelDto>>> Get(int id)
        {
            var result = await business.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse<IEnumerable<NivelDto>>>> GetAll()
        {
            var result = await business.GetAll();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] NivelDto nivel)
        {
            if (nivel == null)
            {
                return BadRequest("Entity is null.");
            }
            var result = await business.Save(nivel);
            return CreatedAtAction(nameof(Get), new { id = result.Id }, result);
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] NivelDto nivel)
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

        [HttpGet("AllSelect")]
        public async Task<ActionResult<ApiResponse<IEnumerable<DataSelectDto>>>> GetAllSelect()
        {
            var result = await business.GetAllSelect();
            return Ok(result);
        }
    }
}
