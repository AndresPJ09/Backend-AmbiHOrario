
using Entity.Dto;
using Entity.Dto.Security;
using Entity.Model.Security;

namespace Service.Interfaces.Security
{
    public interface IModuleService
    {
        Task<ModuleDto> GetById(int id);
        Task<IEnumerable<ModuleDto>> GetAll();
        Task<Module> Save(ModuleDto entity);
        Task Update(ModuleDto entity);
        Task Delete(int id);
        Module mapearDatos(Module module, ModuleDto entity);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
    }
}

