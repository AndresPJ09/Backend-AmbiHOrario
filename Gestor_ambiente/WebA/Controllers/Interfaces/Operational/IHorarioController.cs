using Entity.Dto;
using Microsoft.AspNetCore.Mvc;
using Entity.Dto.Operational;

namespace WebA.Controllers.Interfaces.Operational
{
    public interface IHorarioController
    {
        Task<ActionResult<ApiResponse<IEnumerable<HorarioDto>>>> GetAll();
        Task<ActionResult<ApiResponse<HorarioDto>>> Get(int id);
        Task<ActionResult> Post([FromBody] HorarioDto nivel);
        Task<ActionResult> Put([FromBody] HorarioDto nivel);
        Task<ActionResult> Delete(int id);
    }
}
