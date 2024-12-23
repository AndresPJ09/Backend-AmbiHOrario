using Entity.Context;
using Entity.Dto;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Repository.Interfaces.Parameter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Model.Parameter;
using Entity.Dto.Parameter;

namespace Repository.Implements.Parameter
{
    public class InstructorRepository: IInstructorRepository
    {
        private readonly ApplicationDBContext context;
        protected readonly IConfiguration configuration;

        public InstructorRepository(ApplicationDBContext context, IConfiguration configuration)
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
            context.Instructores.Update(entity);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            var sql = @"SELECT 
                        Id,
                        CONCAT(Name, ' - ', Last_name) AS TextoMostrar 
                    FROM 
                        Instructores
                    WHERE DeletedAt IS NULL AND State = 1
                    ORDER BY Id ASC";
            return await context.QueryAsync<DataSelectDto>(sql);
        }

        public async Task<Instructor> GetById(int id)
        {
            var sql = @"SELECT * FROM Instructores WHERE Id = @Id ORDER BY Id ASC";
            return await context.QueryFirstOrDefaultAsync<Instructor>(sql, new { Id = id });
        }

        public async Task<Instructor> Save(Instructor entity)
        {
            context.Instructores.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task Update(Instructor entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<InstructorDto>> GetAll()
        {
            var sql = @"SELECT * FROM Instructores Where DeletedAt is null ORDER BY Id ASC";
            return await context.QueryAsync<InstructorDto>(sql);
        }
    }
}
