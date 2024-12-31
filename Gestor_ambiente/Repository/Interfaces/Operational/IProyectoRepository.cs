using Entity.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Model.Operational;
using Entity.Dto.Operational;

namespace Repository.Interfaces.Operational
{
    public interface IProyectoRepository
    {
        Task Delete(int id);
        Task<Proyecto> GetById(int id);
        Task<Proyecto> Save(Proyecto entity);
        Task Update(Proyecto entity);
        Task<IEnumerable<ProyectoDto>> GetAll();
    }
}
