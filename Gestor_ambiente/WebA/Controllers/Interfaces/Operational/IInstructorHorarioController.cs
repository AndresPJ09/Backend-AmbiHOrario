using Entity.Dto.Operational;
using Entity.Dto;
using Microsoft.AspNetCore.Mvc;

namespace WebA.Controllers.Interfaces.Operational
{
    public interface IInstructorHorarioController
    {
        Task<ActionResult<ApiResponse<IEnumerable<InstructorHorarioDto>>>> GetAll();
        Task<ActionResult<ApiResponse<InstructorHorarioDto>>> Get(int id);
        Task<ActionResult> Post([FromBody] InstructorHorarioDto nivel);
        Task<ActionResult> Put([FromBody] InstructorHorarioDto nivel);
        Task<ActionResult> Delete(int id);
    }
}
