using Entity.Dto.Operational;
using Entity.Model.Operational;
using Entity.Model.Parameter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces.Operational
{
    public interface IHorarioRepository
    {
        Task Delete(int id);
        Task<Horario> GetById(int id);
        Task<Horario> Save(Horario entity);
        Task Update(Horario entity);
        Task<IEnumerable<HorarioDto>> GetAll();
        Task<Ambiente> GetAmbientesById(int ambienteId);
    }
}
