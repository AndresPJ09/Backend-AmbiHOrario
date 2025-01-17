using Entity.Dto;
using Entity.Dto.Operational;
using Entity.Model.Operational;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces.Operational
{
    public interface IRapRepository
    {
        Task Delete(int id);
        Task<Rap> GetById(int id);
        Task<Rap> Save(Rap entity);
        Task Update(Rap entity);
        Task<IEnumerable<RapDto>> GetAll();
    }
}
