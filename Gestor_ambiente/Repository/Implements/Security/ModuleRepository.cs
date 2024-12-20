using Repository.Interfaces.Security;
using Entity.Context;
using Entity.Dto;
using Entity.Dto.Security;
using Entity.Model.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Repository.Implements.Security
{
    public class ModuleRepository : IModuleRepository
    {
        private readonly ApplicationDBContext context;
        protected readonly IConfiguration configuration;

        public ModuleRepository(ApplicationDBContext context, IConfiguration configuration)
        {
            this.context = context;
            this.configuration = configuration;
        }
        public async Task Delete(int id)
        {
            var entity = await GetById(id);
            if (entity == null)
            {
                throw new Exception("Registro no encontrado");
            }
            entity.DeletedAt = DateTime.Parse(DateTime.Today.ToString());
            entity.State = false;
            context.Modules.Update(entity);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            var sql = @"SELECT 
                        Id,
                        CONCAT(Name, ' - ', Description) AS TextoMostrar 
                    FROM 
                        Modules
                    WHERE DeletedAt IS NULL AND State = 1
                    ORDER BY Id ASC";
            return await context.QueryAsync<DataSelectDto>(sql);
        }

        public async Task<Module> GetById(int id)
        {
            var sql = @"SELECT * FROM Modules WHERE Id = @Id ORDER BY Id ASC";
            return await context.QueryFirstOrDefaultAsync<Module>(sql, new { Id = id });
        }

        public async Task<Module> Save(Module entity)
        {
            context.Modules.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task Update(Module entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ModuleDto>> GetAll()
        {
            var sql = @"SELECT * FROM Modules Where DeletedAt is null ORDER BY Id ASC";
            return await context.QueryAsync<ModuleDto>(sql);
        }
    }
}
