using Entity.Dto;
using Entity.Dto.Operational;
using Entity.Model.Operational;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces.Operational
{
    public interface IConsolidadoHorarioService
    {
        Task<ConsolidadoHorarioDto> GetById(int id);
        Task<IEnumerable<ConsolidadoHorarioDto>> GetAll();
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
        Task<ConsolidadoHorario> Save(ConsolidadoHorarioDto entity);
        Task Update(ConsolidadoHorarioDto entity);
        Task Delete(int id);
        ConsolidadoHorario mapearDatos(ConsolidadoHorario consolidadoHorario, ConsolidadoHorarioDto entity);
    }
}
