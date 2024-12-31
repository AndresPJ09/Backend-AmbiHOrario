using Entity.Dto.Operational;
using Entity.Dto;
using Microsoft.AspNetCore.Mvc;

namespace WebA.Controllers.Interfaces.Operational
{
    public interface IActividadController
    {
        Task<ActionResult<ApiResponse<IEnumerable<ActividadDto>>>> GetAll();
        Task<ActionResult<ApiResponse<ActividadDto>>> Get(int id);
        Task<ActionResult> Post([FromBody] ActividadDto nivel);
        Task<ActionResult> Put([FromBody] ActividadDto nivel);
        Task<ActionResult> Delete(int id);
    }
}
