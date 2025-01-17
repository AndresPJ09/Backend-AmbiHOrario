using Entity.Dto.Parameter;
using Entity.Model.Parameter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces.Parameter
{
    public interface IPeriodoRepository
    {
        Task Delete(int id);
        Task<Periodo> GetById(int id);
        Task<Periodo> Save(Periodo entity);
        Task Update(Periodo entity);
        Task<IEnumerable<PeriodoDto>> GetAll();
    }
}
