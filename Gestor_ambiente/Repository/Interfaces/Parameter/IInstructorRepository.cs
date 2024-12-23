using Entity.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Model.Parameter;
using Entity.Dto.Parameter;

namespace Repository.Interfaces.Parameter
{
    public interface IInstructorRepository
    {
        Task Delete(int id);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
        Task<Instructor> GetById(int id);
        Task<Instructor> Save(Instructor entity);
        Task Update(Instructor entity);
        Task<IEnumerable<InstructorDto>> GetAll();
    }
}
