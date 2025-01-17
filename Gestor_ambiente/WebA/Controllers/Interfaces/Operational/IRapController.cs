using Entity.Dto;
using Entity.Dto.Operational;
using Microsoft.AspNetCore.Mvc;

namespace WebA.Controllers.Interfaces.Operational
{
    public interface IRapController
    {
        Task<ActionResult<ApiResponse<IEnumerable<RapDto>>>> GetAll();
        Task<ActionResult<ApiResponse<RapDto>>> Get(int id);
        Task<ActionResult> Post([FromBody] RapDto rap);
        Task<ActionResult> Put([FromBody] RapDto rap);
        Task<ActionResult> Delete(int id);
    }
}
