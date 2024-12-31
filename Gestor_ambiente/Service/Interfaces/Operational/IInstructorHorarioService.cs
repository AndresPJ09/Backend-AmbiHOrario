using Entity.Dto.Operational;
using Entity.Model.Operational;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces.Operational
{
    public interface IInstructorHorarioService
    {
        Task<InstructorHorarioDto> GetById(int id);
        Task<IEnumerable<InstructorHorarioDto>> GetAll();
        Task<InstructorHorario> Save(InstructorHorarioDto entity);
        Task Update(InstructorHorarioDto entity);
        Task Delete(int id);
        InstructorHorario mapearDatos(InstructorHorario instructorHorario, InstructorHorarioDto entity);
    }
}
