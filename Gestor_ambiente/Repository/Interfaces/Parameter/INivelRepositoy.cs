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
    public interface INivelRepositoy
    {
        Task Delete(int id);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
        Task<Nivel> GetById(int id);
        Task<Nivel> Save(Nivel entity);
        Task Update(Nivel entity);
        Task<IEnumerable<NivelDto>> GetAll();
    }
}
