using Entity.Dto.Security;
using Entity.Dto;
using Microsoft.AspNetCore.Mvc;

namespace WebA.Controllers.Interfaces.Security
{
    public interface IRoleViewController
    {
        Task<ActionResult<ApiResponse<IEnumerable<RoleViewDto>>>> GetAll();
        Task<ActionResult<ApiResponse<RoleViewDto>>> Get(int id);
        Task<ActionResult> Post([FromBody] RoleViewDto role);
        Task<ActionResult> Put([FromBody] RoleViewDto role);
        Task<ActionResult> Delete(int id);
        Task<ActionResult<ApiResponse<IEnumerable<DataSelectDto>>>> GetAllSelect();
    }
}
