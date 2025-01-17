using Entity.Context;
using Entity.Dto.Operational;
using Entity.Model.Operational;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Repository.Interfaces.Operational;
using Repository.Interfaces.Parameter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Implements.Operational
{
    public class RapRepository : IRapRepository
    {
        private readonly ApplicationDBContext context;
        protected readonly IConfiguration configuration;

        public RapRepository(ApplicationDBContext context, IConfiguration configuration)
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
            context.raps.Update(entity);
            await context.SaveChangesAsync();
        }

        public async Task<Rap> GetById(int id)
        {
            var sql = @"SELECT * FROM Raps WHERE Id = @Id ORDER BY Id ASC";
            return await context.QueryFirstOrDefaultAsync<Rap>(sql, new { Id = id });
        }

        public async Task<Rap> Save(Rap entity)
        {
            context.raps.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task Update(Rap entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<RapDto>> GetAll()
        {
            var sql = @"SELECT * FROM Raps Where DeletedAt is null ORDER BY Id ASC";
            return await context.QueryAsync<RapDto>(sql);
        }

    }
}
