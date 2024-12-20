using Entity.Dto;
using Entity.Dto.Security;
using Entity.Model.Security;

namespace Repository.Interfaces.Security
{
    public interface IPersonRepository
    {
        Task Delete(int id);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
        Task<Person> GetById(int id);
        Task<Person> Save(Person entity);
        Task Update(Person entity);
        Task<IEnumerable<Person>> GetAll();
    }
}
