using Entity.Dto.Security;
using Entity.Dto;
using Microsoft.AspNetCore.Mvc;

namespace WebA.Controllers.Interfaces.Security
{
    public interface IUserController
    {
        Task<ActionResult<ApiResponse<IEnumerable<DataSelectDto>>>> GetAllSelect();
        Task<ActionResult<ApiResponse<IEnumerable<UserDto>>>> GetAll();
        Task<ActionResult<ApiResponse<UserDto>>> Get(int id);
        Task<ActionResult> Post([FromBody] UserDto roleView);
        Task<ActionResult> Put([FromBody] UserDto roleView);
        Task<ActionResult> Delete(int id);
    }
}
