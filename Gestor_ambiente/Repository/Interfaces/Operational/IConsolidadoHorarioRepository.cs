using Entity.Dto;
using Entity.Dto.Operational;
using Entity.Model.Operational;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces.Operational
{
    public interface IConsolidadoHorarioRepository
    {
        Task Delete(int id);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
        Task<ConsolidadoHorario> GetById(int id);
        Task<ConsolidadoHorario> Save(ConsolidadoHorario entity);
        Task Update(ConsolidadoHorario entity);
        Task<IEnumerable<ConsolidadoHorarioDto>> GetAll();
    }
}
