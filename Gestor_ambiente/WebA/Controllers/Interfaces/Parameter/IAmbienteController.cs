using Entity.Dto.Parameter;
using Entity.Dto;
using Microsoft.AspNetCore.Mvc;

namespace WebA.Controllers.Interfaces.Parameter
{
    public interface IAmbienteController
    {
        Task<ActionResult<ApiResponse<IEnumerable<DataSelectDto>>>> GetAllSelect();
        Task<ActionResult<ApiResponse<IEnumerable<AmbienteDto>>>> GetAll();
        Task<ActionResult<ApiResponse<AmbienteDto>>> Get(int id);
        Task<ActionResult> Post([FromBody] AmbienteDto ambiente);
        Task<ActionResult> Put([FromBody] AmbienteDto ambiente);
        Task<ActionResult> Delete(int id);
    }
}
