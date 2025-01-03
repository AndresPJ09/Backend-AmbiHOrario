using Entity.Dto.Operational;
using Entity.Dto;
using Entity.Model.Operational;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces.Operational
{
    public interface IConsolidadoAmbienteRepository
    {
        Task Delete(int id);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
        Task<ConsolidadoAmbiente> GetById(int id);
        Task<ConsolidadoAmbiente> Save(ConsolidadoAmbiente entity);
        Task Update(ConsolidadoAmbiente entity);
        Task<IEnumerable<ConsolidadoAmbienteDto>> GetAll();
    }
}
