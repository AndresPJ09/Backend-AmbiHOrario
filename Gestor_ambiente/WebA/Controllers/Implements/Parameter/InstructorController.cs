using Entity.Dto;
using Entity.Dto.Parameter;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces.Parameter;
using WebA.Controllers.Interfaces.Parameter;
namespace WebA.Controllers.Implements.Parameter
{
    [Route("api/Instructor")]
    [ApiController]
    public class InstructorController : ControllerBase, IInstructorController
    {
        protected readonly IInstructorService business;

        public InstructorController(IInstructorService business)
        {
            this.business = business;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse<InstructorDto>>> Get(int id)
        {
            var result = await business.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse<IEnumerable<InstructorDto>>>> GetAll()
        {
            var result = await business.GetAll();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] InstructorDto instructor)
        {
            if (instructor == null)
            {
                return BadRequest("Entity is null.");
            }
            var result = await business.Save(instructor);
            return CreatedAtAction(nameof(Get), new { id = result.Id }, result);
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] InstructorDto instructor)
        {
            if (instructor == null)
            {
                return BadRequest();
            }
            await business.Update(instructor);
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
