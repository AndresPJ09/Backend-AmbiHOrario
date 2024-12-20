using Entity.Dto.Security;
using Entity.Dto;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces.Security;
using WebA.Controllers.Interfaces.Security;

namespace WebA.Controllers.Implements.Security
{
    [Route("api/Role")]
    [ApiController]
    public class RoleController : ControllerBase, IRoleController
    {
        protected readonly IRoleService business;

        public RoleController(IRoleService business)
        {
            this.business = business;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse<RoleDto>>> Get(int id)
        {
            var result = await business.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse<IEnumerable<RoleDto>>>> GetAll()
        {
            var result = await business.GetAll();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] RoleDto role)
        {
            if (role == null)
            {
                return BadRequest("Entity is null.");
            }
            var result = await business.Save(role);
            return CreatedAtAction(nameof(Get), new { id = result.Id }, result);
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] RoleDto role)
        {
            if (role == null)
            {
                return BadRequest();
            }
            await business.Update(role);
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
