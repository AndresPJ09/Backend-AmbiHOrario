using Entity.Dto;
using Entity.Dto.Parameter;
using Entity.Model.Parameter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces.Parameter
{
    public interface IProgramaRepositoy
    {
        Task Delete(int id);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
        Task<Programa> GetById(int id);
        Task<Programa> Save(Programa entity);
        Task Update(Programa entity);
        Task<IEnumerable<ProgramaDto>> GetAll();
    }
}
