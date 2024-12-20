using Service.Interfaces.Security;
using Repository.Interfaces.Security;
using Entity.Dto;
using Entity.Dto.Security;
using Entity.Model.Security;

namespace Service.Implements.Security
{
    public class ModuleService: IModuleService
    {
        private readonly IModuleRepository data;

        public ModuleService(IModuleRepository data)
        {
            this.data = data;
        }

        public async Task<ModuleDto> GetById(int id)
        {
            Module module = await data.GetById(id);
            ModuleDto ModuleDto = new ModuleDto();

            ModuleDto.Id = module.Id;
            ModuleDto.Name = module.Name;
            ModuleDto.Description = module.Description;
            ModuleDto.Position = module.Position;
            ModuleDto.State = module.State;
            return ModuleDto;
        }

        public async Task<IEnumerable<ModuleDto>> GetAll()
        {
            IEnumerable<ModuleDto> modules = await data.GetAll();
            var moduleDtos = modules.Select(module => new ModuleDto
            {
                Id = module.Id,
                Name = module.Name,
                Description = module.Description,
                Position = module.Position,
                State = module.State
            });

            return moduleDtos;
        }

        public async Task<Module> Save(ModuleDto entity)
        {
            Module module = new Module();
            module = mapearDatos(module, entity);
            module.CreatedAt = DateTime.Now;
            module.State = true;
            module.DeletedAt = null;
            module.UpdatedAt = null;
            return await data.Save(module);
        }

        public async Task Update(ModuleDto entity)
        {
            Module module = await data.GetById(entity.Id);
            if (module == null)
            {
                throw new Exception("Registro no encontrado");
            }
            module = mapearDatos(module, entity);
            module.UpdatedAt = DateTime.Now;

            await data.Update(module);
        }

        public async Task Delete(int id)
        {
            await data.Delete(id);
        }

        public Module mapearDatos(Module module, ModuleDto entity)
        {
            module.Id = entity.Id;
            module.Name = entity.Name;
            module.Description = entity.Description;
            module.Position = entity.Position;
            module.State = entity.State;
            return module;


        }

        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            return await data.GetAllSelect();
        }
    }
}
