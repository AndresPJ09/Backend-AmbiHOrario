using Entity.Dto;
using Entity.Dto.Security;
using Microsoft.AspNetCore.Mvc;

namespace WebA.Controllers.Interfaces.Security
{
    public interface IModuloController
    {
        Task<ActionResult<ApiResponse<IEnumerable<DataSelectDto>>>> GetAllSelect();
        Task<ActionResult<ApiResponse<IEnumerable<ModuleDto>>>> GetAll();
        Task<ActionResult<ApiResponse<ModuleDto>>> Get(int id);
        Task<ActionResult> Post([FromBody] ModuleDto modulo);
        Task<ActionResult> Put([FromBody] ModuleDto modulo);
        Task<ActionResult> Delete(int id);
    }
}
