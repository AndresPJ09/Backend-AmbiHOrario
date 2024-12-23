using Entity.Dto;
using Entity.Dto.Parameter;
using Entity.Model.Parameter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces.Parameter
{
    public interface ICompetenciaService
    {
        Task<CompetenciaDto> GetById(int id);
        Task<IEnumerable<CompetenciaDto>> GetAll();
        Task<Competencia> Save(CompetenciaDto entity);
        Task Update(CompetenciaDto entity);
        Task Delete(int id);
        Competencia mapearDatos(Competencia competencia, CompetenciaDto entity);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
    }
}
