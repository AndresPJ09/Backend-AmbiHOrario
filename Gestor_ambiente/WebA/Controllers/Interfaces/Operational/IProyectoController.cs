using Entity.Dto.Operational;
using Entity.Dto;
using Microsoft.AspNetCore.Mvc;

namespace WebA.Controllers.Interfaces.Operational
{
    public interface IProyectoController
    {
        Task<ActionResult<ApiResponse<IEnumerable<ProyectoDto>>>> GetAll();
        Task<ActionResult<ApiResponse<ProyectoDto>>> Get(int id);
        Task<ActionResult> Post([FromBody] ProyectoDto nivel);
        Task<ActionResult> Put([FromBody] ProyectoDto nivel);
        Task<ActionResult> Delete(int id);
    }
}
