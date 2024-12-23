using Entity.Dto;
using Entity.Dto.Parameter;
using Microsoft.AspNetCore.Mvc;

namespace WebA.Controllers.Interfaces.Parameter
{
    public interface INivelController
    {
        Task<ActionResult<ApiResponse<IEnumerable<DataSelectDto>>>> GetAllSelect();
        Task<ActionResult<ApiResponse<IEnumerable<NivelDto>>>> GetAll();
        Task<ActionResult<ApiResponse<NivelDto>>> Get(int id);
        Task<ActionResult> Post([FromBody] NivelDto nivel);
        Task<ActionResult> Put([FromBody] NivelDto nivel);
        Task<ActionResult> Delete(int id);
    }
}
