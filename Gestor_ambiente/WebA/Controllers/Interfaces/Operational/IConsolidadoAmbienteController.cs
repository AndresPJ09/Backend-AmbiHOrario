using Entity.Dto;
using Entity.Dto.Operational;
using Entity.Model.Operational;
using Microsoft.AspNetCore.Mvc;

namespace WebA.Controllers.Interfaces.Operational
{
    public interface IConsolidadoAmbienteController
    {
        Task<ActionResult<ApiResponse<ConsolidadoAmbienteDto>>> Get(int id);
        Task<ActionResult<ApiResponse<IEnumerable<ConsolidadoAmbienteDto>>>> GetAll();
        Task<ActionResult> Post([FromBody] ConsolidadoAmbienteDto consolidadoAmbiente);
        Task<ActionResult> Put([FromBody] ConsolidadoAmbienteDto consolidadoAmbiente);
        Task<ActionResult> Delete(int id);
        Task<ActionResult<ApiResponse<IEnumerable<DataSelectDto>>>> GetAllSelect();
    }
}
