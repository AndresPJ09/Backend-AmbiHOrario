using Entity.Dto;
using Entity.Dto.Security;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces.Security;
using WebA.Controllers.Interfaces.Security;

namespace WebA.Controllers.Implements.Security
{
    [Route("api/Module")]
    [ApiController]
    public class ModuleController: ControllerBase, IModuloController
    {
        protected readonly IModuleService business;

        public ModuleController(IModuleService business)
        {
            this.business = business;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse<ModuleDto>>> Get(int id)
        {
            var result = await business.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse<IEnumerable<ModuleDto>>>> GetAll()
        {
            var result = await business.GetAll();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ModuleDto modulo)
        {
            if (modulo == null)
            {
                return BadRequest("Entity is null.");
            }
            var result = await business.Save(modulo);
            return CreatedAtAction(nameof(Get), new { id = result.Id }, result);
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] ModuleDto modulo)
        {
            if (modulo == null)
            {
                return BadRequest();
            }
            await business.Update(modulo);
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
