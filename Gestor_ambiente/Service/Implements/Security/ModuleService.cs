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
            if (module == null)
            {
                throw new Exception("El módulo no existe.");
            }
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
            // Validar que no existan más de 5 módulos
            var modules = await data.GetAll(); // Obtener todos los módulos (esto es asíncrono)
            if (modules.Count() >= 5) // Si ya hay 5 módulos, no se puede crear más
            {
                throw new Exception("No se pueden crear más de 5 módulos.");
            }

            // Validar que el nombre sea único
            if (modules.Any(m => m.Name == entity.Name)) // Si el nombre ya existe, lanzamos una excepción
            {
                throw new Exception("El nombre del módulo ya existe.");
            }

            // Validar que la posición sea única
            if (modules.Any(m => m.Position == entity.Position)) // Si la posición ya existe, lanzamos una excepción
            {
                throw new Exception("La posición del módulo ya existe.");
            }

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

            var modules = await data.GetAll(); // Obtener todos los módulos (esto es asíncrono)

            // Validar que el nombre sea único
            if (modules.Any(m => m.Name == entity.Name && m.Id != entity.Id))
            {
                throw new Exception("El nombre del módulo ya existe.");
            }

            // Validar que la posición sea única, excluyendo el módulo actual
            if (modules.Any(m => m.Position == entity.Position && m.Id != entity.Id))
            {
                throw new Exception("La posición del módulo ya existe.");
            }
            module = mapearDatos(module, entity);
            module.UpdatedAt = DateTime.Now;

            await data.Update(module);
        }

        public async Task Delete(int id)
        {
            Module module = await data.GetById(id);
            if (module == null)
            {
                throw new Exception("El módulo no existe.");
            }
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
