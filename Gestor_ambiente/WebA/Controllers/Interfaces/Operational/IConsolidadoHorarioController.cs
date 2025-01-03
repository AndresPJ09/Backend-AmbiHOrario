using Entity.Dto.Operational;
using Entity.Dto;
using Microsoft.AspNetCore.Mvc;

namespace WebA.Controllers.Interfaces.Operational
{
    public interface IConsolidadoHorarioController
    {
        Task<ActionResult<ApiResponse<ConsolidadoHorarioDto>>> Get(int id);
        Task<ActionResult<ApiResponse<IEnumerable<ConsolidadoHorarioDto>>>> GetAll();
        Task<ActionResult> Post([FromBody] ConsolidadoHorarioDto entity);
        Task<ActionResult> Put([FromBody] ConsolidadoHorarioDto entity);
        Task<ActionResult> Delete(int id);
        Task<ActionResult<ApiResponse<IEnumerable<DataSelectDto>>>> GetAllSelect();
    }
}
