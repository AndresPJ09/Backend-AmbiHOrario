using Entity.Dto.Operational;
using Entity.Model.Operational;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces.Operational
{
    public interface IFichaService
    {
        Task<FichaDto> GetById(int id);
        Task<IEnumerable<FichaDto>> GetAll();
        Task<Ficha> Save(FichaDto entity);
        Task Update(FichaDto entity);
        Task Delete(int id);
        Ficha mapearDatos(Ficha ficha, FichaDto entity);
    }
}
