using Entity.Context;
using Entity.Dto.Operational;
using Entity.Model.Operational;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Repository.Interfaces.Operational;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Implements.Operational
{
    public class ActividadRepository : IActividadRepository
    {
        private readonly ApplicationDBContext context;
        protected readonly IConfiguration configuration;

        public ActividadRepository(ApplicationDBContext context, IConfiguration configuration)
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
            context.Actividades.Update(entity);
            await context.SaveChangesAsync();
        }
        public async Task<Actividad> GetById(int id)
        {
            var sql = @"SELECT * FROM Actividades WHERE Id = @Id ORDER BY Id ASC";
            return await context.QueryFirstOrDefaultAsync<Actividad>(sql, new { Id = id });
        }

        public async Task<Actividad> Save(Actividad entity)
        {
            context.Actividades.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task Update(Actividad entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ActividadDto>> GetAll()
        {
            var sql = @"SELECT * FROM Actividades Where DeletedAt is null ORDER BY Id ASC";
            return await context.QueryAsync<ActividadDto>(sql);
        }
    }
}
