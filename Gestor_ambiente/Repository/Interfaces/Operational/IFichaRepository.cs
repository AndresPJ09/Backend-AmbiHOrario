using Entity.Dto.Operational;
using Entity.Model.Operational;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces.Operational
{
    public interface IFichaRepository
    {
        Task Delete(int id);
        Task<Ficha> GetById(int id);
        Task<Ficha> Save(Ficha entity);
        Task Update(Ficha entity);
        Task<IEnumerable<FichaDto>> GetAll();
    }
}
