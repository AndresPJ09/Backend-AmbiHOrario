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
    public interface IAmbienteRepositoy
    {
        Task Delete(int id);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
        Task<Ambiente> GetById(int id);
        Task<Ambiente> Save(Ambiente entity);
        Task Update(Ambiente entity);
        Task<IEnumerable<AmbienteDto>> GetAll();
    }
}
