using Entity.Dto;
using Entity.Dto.Security;
using Entity.Model.Security;


namespace Repository.Interfaces.Security
{
    public interface IModuleRepository
    {
        Task Delete(int id);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
        Task<Module> GetById(int id);
        Task<Module> Save(Module entity);
        Task Update(Module entity);
        Task<IEnumerable<ModuleDto>> GetAll();
    }
}
