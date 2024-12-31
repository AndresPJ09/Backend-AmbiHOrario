using Entity.Dto.Operational;
using Entity.Model.Operational;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces.Operational
{
    public interface IProyectoService
    {
        Task<ProyectoDto> GetById(int id);
        Task<IEnumerable<ProyectoDto>> GetAll();
        Task<Proyecto> Save(ProyectoDto entity);
        Task Update(ProyectoDto entity);
        Task Delete(int id);
        Proyecto mapearDatos(Proyecto proyecto, ProyectoDto entity);
    }
}
