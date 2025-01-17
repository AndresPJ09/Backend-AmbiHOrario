using Entity.Dto;
using Entity.Dto.Parameter;
using Microsoft.AspNetCore.Mvc;

namespace WebA.Controllers.Interfaces.Parameter
{
    public interface IPeriodoController
    {
        Task<ActionResult<ApiResponse<IEnumerable<PeriodoDto>>>> GetAll();
        Task<ActionResult<ApiResponse<PeriodoDto>>> Get(int id);
        Task<ActionResult> Post([FromBody] PeriodoDto periodo);
        Task<ActionResult> Put([FromBody] PeriodoDto periodo);
        Task<ActionResult> Delete(int id);
    }
}
