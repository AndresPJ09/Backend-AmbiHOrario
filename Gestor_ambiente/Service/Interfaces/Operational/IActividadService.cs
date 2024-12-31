using Entity.Dto.Operational;
using Entity.Model.Operational;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces.Operational
{
    public interface IActividadService
    {
        Task<ActividadDto> GetById(int id);
        Task<IEnumerable<ActividadDto>> GetAll();
        Task<Actividad> Save(ActividadDto entity);
        Task Update(ActividadDto entity);
        Task Delete(int id);
        Actividad mapearDatos(Actividad actividad, ActividadDto entity);
    }
}
