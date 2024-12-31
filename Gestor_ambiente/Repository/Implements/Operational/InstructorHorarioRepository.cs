using Entity.Context;
using Entity.Dto;
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
    public class InstructorHorarioRepository: IInstructoHorarioRepository
    {
        private readonly ApplicationDBContext context;
        protected readonly IConfiguration configuration;

        public InstructorHorarioRepository(ApplicationDBContext context, IConfiguration configuration)
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
            context.InstructorHorarios.Update(entity);
            await context.SaveChangesAsync();
        }
        public async Task<InstructorHorario> GetById(int id)
        {
            var sql = @"SELECT * FROM InstructorHorarios WHERE Id = @Id ORDER BY Id ASC";
            return await context.QueryFirstOrDefaultAsync<InstructorHorario>(sql, new { Id = id });
        }

        public async Task<InstructorHorario> Save(InstructorHorario entity)
        {
            context.InstructorHorarios.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task Update(InstructorHorario entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<InstructorHorarioDto>> GetAll()
        {
            var sql = @"SELECT * FROM InstructorHorarios Where DeletedAt is null ORDER BY Id ASC";
            return await context.QueryAsync<InstructorHorarioDto>(sql);
        }
    }
}
