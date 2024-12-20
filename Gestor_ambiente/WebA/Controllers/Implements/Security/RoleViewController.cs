using Entity.Dto.Security;
using Entity.Dto;
using Microsoft.AspNetCore.Mvc;
using WebA.Controllers.Interfaces.Security;
using Microsoft.AspNetCore.Authorization;
using Service.Interfaces.Security;

namespace WebA.Controllers.Implements.Security
{
    [Route("api/RoleView")]
    [ApiController]
    public class RoleViewController : ControllerBase, IRoleViewController
    {
        protected readonly IRoleViewService business;

        public RoleViewController(IRoleViewService business)
        {
            this.business = business;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse<RoleViewDto>>> Get(int id)
        {
            var result = await business.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse<IEnumerable<RoleViewDto>>>> GetAll()
        {
            var result = await business.GetAll();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] RoleViewDto roleView)
        {
            if (roleView == null)
            {
                return BadRequest("Entity is null");
            }
            var result = await business.Save(roleView);
            return CreatedAtAction(nameof(Get), new { id = result.Id }, result);
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] RoleViewDto roleView)
        {
            if (roleView == null)
            {
                return BadRequest();
            }
            await business.Update(roleView);
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
