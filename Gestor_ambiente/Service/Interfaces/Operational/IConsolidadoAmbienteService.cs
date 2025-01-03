using Entity.Dto.Operational;
using Entity.Dto;
using Entity.Model.Operational;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces.Operational
{
    public interface IConsolidadoAmbienteService
    {
        Task<ConsolidadoAmbienteDto> GetById(int id);
        Task<IEnumerable<ConsolidadoAmbienteDto>> GetAll();
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
        Task<ConsolidadoAmbiente> Save(ConsolidadoAmbienteDto entity);
        Task Update(ConsolidadoAmbienteDto entity);
        Task Delete(int id);
        ConsolidadoAmbiente mapearDatos(ConsolidadoAmbiente consolidadoAmbiente, ConsolidadoAmbienteDto entity);
    }
}
