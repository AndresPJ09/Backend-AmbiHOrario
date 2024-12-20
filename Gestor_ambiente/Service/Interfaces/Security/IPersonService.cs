using Entity.Dto.Security;
using Entity.Dto;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces.Security
{
    public interface IPersonService
    {
        Task<PersonDto> GetById(int id);
        Task<IEnumerable<PersonDto>> GetAll();
        Task<Person> Save(PersonDto entity);
        Task Update(PersonDto entity);
        Task Delete(int id);
        Person mapearDatos(Person person, PersonDto entity);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
    }
}
