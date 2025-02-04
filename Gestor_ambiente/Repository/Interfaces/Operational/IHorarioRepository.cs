using Entity.Dto.Operational;
using Entity.Model.Operational;
using Entity.Model.Parameter;
using Entity.Model.Security;
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
        Task<User> GetUsuarioById(int userId);
        Task<Ficha> GetFichaById(int fichaId);
        Task<Periodo> GetPeriodoById(int periodoId);
        Task SaveInstructorHorario(int horarioId, int instructorId, string observaciones);


    }
}
