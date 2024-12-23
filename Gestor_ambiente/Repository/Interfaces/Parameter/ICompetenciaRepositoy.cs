using Entity.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Model.Parameter;
using Entity.Dto.Parameter;

namespace Repository.Interfaces.Parameter
{
    public interface ICompetenciaRepositoy
    {
        Task Delete(int id);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
        Task<Competencia> GetById(int id);
        Task<Competencia> Save(Competencia entity);
        Task Update(Competencia entity);
        Task<IEnumerable<CompetenciaDto>> GetAll();
    }
}
