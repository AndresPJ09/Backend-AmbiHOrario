using Entity.Dto;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces.Security
{
    public interface IViewRepository
    {
        Task Delete(int id);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
        Task<View> GetById(int id);
        Task<View> Save(View entity);
        Task Update(View entity);
        Task<View> GetByName(string name);
        Task<IEnumerable<View>> GetAll();
    }
}
