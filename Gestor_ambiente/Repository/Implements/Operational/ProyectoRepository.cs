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
    public class ProyectoRepository : IProyectoRepository
    {
        private readonly ApplicationDBContext context;
        protected readonly IConfiguration configuration;

        public ProyectoRepository(ApplicationDBContext context, IConfiguration configuration)
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
            context.Proyectos.Update(entity);
            await context.SaveChangesAsync();
        }
        public async Task<Proyecto> GetById(int id)
        {
            var sql = @"SELECT * FROM Proyectos WHERE Id = @Id ORDER BY Id ASC";
            return await context.QueryFirstOrDefaultAsync<Proyecto>(sql, new { Id = id });
        }

        public async Task<Proyecto> Save(Proyecto entity)
        {
            context.Proyectos.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task Update(Proyecto entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ProyectoDto>> GetAll()
        {
            var sql = @"SELECT * FROM Proyectos Where DeletedAt is null ORDER BY Id ASC";
            return await context.QueryAsync<ProyectoDto>(sql);
        }
    }
}
