using Entity.Dto.Parameter;
using Entity.Dto;
using Microsoft.AspNetCore.Mvc;

namespace WebA.Controllers.Interfaces.Parameter
{
    public interface ICompetenciaController
    {
        Task<ActionResult<ApiResponse<IEnumerable<CompetenciaDto>>>> GetAll();
        Task<ActionResult<ApiResponse<CompetenciaDto>>> Get(int id);
        Task<ActionResult> Post([FromBody] CompetenciaDto competencia);
        Task<ActionResult> Put([FromBody] CompetenciaDto competencia);
        Task<ActionResult> Delete(int id);
    }
}
