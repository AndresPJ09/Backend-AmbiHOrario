using Entity.Dto.Operational;
using Entity.Model.Operational;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces.Operational
{
    public interface IInstructoHorarioRepository
    {
        Task Delete(int id);
        Task<InstructorHorario> GetById(int id);
        Task<InstructorHorario> Save(InstructorHorario entity);
        Task Update(InstructorHorario entity);
        Task<IEnumerable<InstructorHorarioDto>> GetAll();
    }
}
