using Entity.Dto.Operational;
using Entity.Model.Operational;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces.Operational
{
    public interface IActividadRepository
    {
        Task Delete(int id);
        Task<Actividad> GetById(int id);
        Task<Actividad> Save(Actividad entity);
        Task Update(Actividad entity);
        Task<IEnumerable<ActividadDto>> GetAll();
    }
}
