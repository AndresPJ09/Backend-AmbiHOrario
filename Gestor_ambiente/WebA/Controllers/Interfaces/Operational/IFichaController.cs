using Entity.Dto.Operational;
using Entity.Dto;
using Microsoft.AspNetCore.Mvc;

namespace WebA.Controllers.Interfaces.Operational
{
    public interface IFichaController
    {
        Task<ActionResult<ApiResponse<IEnumerable<FichaDto>>>> GetAll();
        Task<ActionResult<ApiResponse<FichaDto>>> Get(int id);
        Task<ActionResult> Post([FromBody] FichaDto nivel);
        Task<ActionResult> Put([FromBody] FichaDto nivel);
        Task<ActionResult> Delete(int id);
    }
}
