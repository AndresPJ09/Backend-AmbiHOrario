using Entity.Dto.Parameter;
using Entity.Dto;
using Microsoft.AspNetCore.Mvc;

namespace WebA.Controllers.Interfaces.Parameter
{
    public interface IProgramaController
    {
        Task<ActionResult<ApiResponse<IEnumerable<DataSelectDto>>>> GetAllSelect();
        Task<ActionResult<ApiResponse<IEnumerable<ProgramaDto>>>> GetAll();
        Task<ActionResult<ApiResponse<ProgramaDto>>> Get(int id);
        Task<ActionResult> Post([FromBody] ProgramaDto programa);
        Task<ActionResult> Put([FromBody] ProgramaDto programa);
        Task<ActionResult> Delete(int id);
    }
}
