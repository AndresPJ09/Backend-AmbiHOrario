using Entity.Context;
using Entity.Dto;
using Entity.Dto.Parameter;
using Entity.Model.Parameter;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Repository.Interfaces.Parameter;
using Repository.Interfaces.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Implements.Parameter
{
    public class PeriodoRepository : IPeriodoRepository
    {
        private readonly ApplicationDBContext context;
        protected readonly IConfiguration configuration;

        public PeriodoRepository(ApplicationDBContext context, IConfiguration configuration)
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
            context.Periodos.Update(entity);
            await context.SaveChangesAsync();
        }

        public async Task<Periodo> GetById(int id)
        {
            var sql = @"SELECT * FROM Periodos WHERE Id = @Id ORDER BY Id ASC";
            return await context.QueryFirstOrDefaultAsync<Periodo>(sql, new { Id = id });
        }

        public async Task<Periodo> Save(Periodo entity)
        {
            context.Periodos.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task Update(Periodo entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<PeriodoDto>> GetAll()
        {
            var sql = @"SELECT * FROM Periodos Where DeletedAt is null ORDER BY Id ASC";
            return await context.QueryAsync<PeriodoDto>(sql);
        }
    }
}
