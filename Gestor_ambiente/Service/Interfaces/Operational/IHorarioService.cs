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
    public interface IHorarioService
    {
        Task<HorarioDto> GetById(int id);
        Task<IEnumerable<HorarioDto>> GetAll();
        Task<Horario> Save(HorarioDto entity);
        Task Update(HorarioDto entity);
        Task Delete(int id);
        Horario mapearDatos(Horario horario, HorarioDto entity);
    }
}
