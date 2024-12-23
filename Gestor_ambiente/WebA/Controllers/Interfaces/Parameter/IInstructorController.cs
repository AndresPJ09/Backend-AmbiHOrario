using Entity.Dto.Parameter;
using Entity.Dto;
using Microsoft.AspNetCore.Mvc;

namespace WebA.Controllers.Interfaces.Parameter
{
    public interface IInstructorController
    {
        Task<ActionResult<ApiResponse<IEnumerable<DataSelectDto>>>> GetAllSelect();
        Task<ActionResult<ApiResponse<IEnumerable<InstructorDto>>>> GetAll();
        Task<ActionResult<ApiResponse<InstructorDto>>> Get(int id);
        Task<ActionResult> Post([FromBody] InstructorDto instructor);
        Task<ActionResult> Put([FromBody] InstructorDto instructor);
        Task<ActionResult> Delete(int id);
    }
}
