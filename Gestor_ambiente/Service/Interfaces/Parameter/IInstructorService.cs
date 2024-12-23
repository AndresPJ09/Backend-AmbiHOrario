using Entity.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Model.Parameter;
using Entity.Dto.Parameter;

namespace Service.Interfaces.Parameter
{
    public interface IInstructorService
    {
        Task<InstructorDto> GetById(int id);
        Task<IEnumerable<InstructorDto>> GetAll();
        Task<Instructor> Save(InstructorDto entity);
        Task Update(InstructorDto entity);
        Task Delete(int id);
        Instructor mapearDatos(Instructor instructor, InstructorDto entity);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
    }
}
