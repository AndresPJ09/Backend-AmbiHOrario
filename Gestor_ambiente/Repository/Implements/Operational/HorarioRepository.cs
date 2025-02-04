using Entity.Context;
using Entity.Dto;
using Entity.Dto.Operational;
using Entity.Model.Operational;
using Entity.Model.Parameter;
using Entity.Model.Security;
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
    public class HorarioRepository : IHorarioRepository
    {
        private readonly ApplicationDBContext context;
        protected readonly IConfiguration configuration;

        public HorarioRepository(ApplicationDBContext context, IConfiguration configuration)
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
            context.Horarios.Update(entity);
            await context.SaveChangesAsync();
        }
        public async Task<Horario> GetById(int id)
        {
            var sql = @"SELECT * FROM Horarios WHERE Id = @Id ORDER BY Id ASC";
            return await context.QueryFirstOrDefaultAsync<Horario>(sql, new { Id = id });
        }

        public async Task<Horario> Save(Horario entity)
        {
            context.Horarios.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task Update(Horario entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<HorarioDto>> GetAll()
        {
            var sql = @"SELECT * FROM Horarios Where DeletedAt is null ORDER BY Id ASC";
            return await context.QueryAsync<HorarioDto>(sql);
        }

        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            var sql = @"SELECT 
                        Id,
                        Observaciones AS TextoMostrar 
                    FROM 
                        Horarios
                    WHERE DeletedAt IS NULL AND State = 1
                    ORDER BY Id ASC";
            return await context.QueryAsync<DataSelectDto>(sql);
        }

        public async Task<Ambiente> GetAmbientesById(int ambienteId)
        {
            var sql = @"SELECT *
                FROM Ambientes 
                WHERE Id = @AmbienteId AND DeletedAt IS NULL";
            return await context.QueryFirstOrDefaultAsync<Ambiente>(sql, new { AmbienteId = ambienteId });
        }
        public async Task<User> GetUsuarioById(int userId)
        {
            var sql = @"SELECT * FROM Users WHERE Id = @UserId AND State = 1 AND DeletedAt IS NULL";
            return await context.QueryFirstOrDefaultAsync<User>(sql, new { UserId = userId });
        }

        public async Task<Ficha> GetFichaById(int fichaId)
        {
            var sql = @"SELECT * FROM Fichas WHERE Id = @FichaId AND State = 1 AND DeletedAt IS NULL";
            return await context.QueryFirstOrDefaultAsync<Ficha>(sql, new { FichaId = fichaId });
        }

        public async Task<Periodo> GetPeriodoById(int periodoId)
        {
            var sql = @"SELECT * FROM Periodos WHERE Id = @PeriodoId AND State = 1 AND DeletedAt IS NULL";
            return await context.QueryFirstOrDefaultAsync<Periodo>(sql, new { PeriodoId = periodoId });
        }
        public async Task SaveInstructorHorario(int horarioId, int instructorId, string observaciones)
        {
            var instructorHorario = new InstructorHorario
            {
                HorarioId = horarioId,
                InstructorId = instructorId,
                Observaciones = observaciones,
                State = true
            };

            await context.InstructorHorarios.AddAsync(instructorHorario);
            await context.SaveChangesAsync();
        }


    }
}
