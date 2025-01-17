﻿using Dapper;
using Entity.Model;
using Entity.Model.Operational;
using Entity.Model.Parameter;
using Entity.Model.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace Entity.Context
{
    public class ApplicationDBContext : DbContext
    {
        protected readonly IConfiguration _configuration;
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var config = new GenericConfig();
            config.ConfigureUser(modelBuilder.Entity<User>());
            config.ConfigurePerson(modelBuilder.Entity<Person>());
            config.ConfigureModule(modelBuilder.Entity<Module>());
  

            modelBuilder.ApplyConfigurationsFromAssembly(System.Reflection.Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<decimal>().HavePrecision(18, 2);
        }

        public override int SaveChanges()
        {
            EnsureAudit();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSucces, CancellationToken cancellationToken = default)
        {
            EnsureAudit();
            return base.SaveChangesAsync(acceptAllChangesOnSucces,
                                         cancellationToken);
        }

        public async Task<IEnumerable<T>> QueryAsync<T>(string text, object parameters = null, int? timeout = null, CommandType? type = null)
        {
            using var command = new DapperEFCoreCommand(this,
                                                        text,
                                                        parameters,
                                                        timeout,
                                                        type,
                                                        CancellationToken.None);
            var connection = Database.GetDbConnection();
            return await connection.QueryAsync<T>(command.Definition);
        }

        public async Task<T> QueryFirstOrDefaultAsync<T>(string text, object parameters = null, int? timeout = null, CommandType? type = null)
        {
            using var command = new DapperEFCoreCommand(this,
                                                        text,
                                                        parameters,
                                                        timeout,
                                                        type,
                                                        CancellationToken.None);
            var connection = Database.GetDbConnection();
            return await connection.QueryFirstOrDefaultAsync<T>(command.Definition);
        }

        private void EnsureAudit()
        {
            ChangeTracker.DetectChanges();
        }

        //Security
        public DbSet<Role> Roles => Set<Role>();
        public DbSet<Module> Modules => Set<Module>();
        public DbSet<Person> Persons => Set<Person>();
        public DbSet<RoleView> RoleViews => Set<RoleView>();
        public DbSet<User> Users => Set<User>();
        public DbSet<UserRole> UserRoles => Set<UserRole>();
        public DbSet<View> Views => Set<View>();


        //Paramaeter
        public DbSet<Instructor> Instructores => Set<Instructor>();
        public DbSet<Nivel> Niveles => Set<Nivel>();
        public DbSet<Programa> Programas => Set<Programa>();
        public DbSet<Competencia> Competencias => Set<Competencia>();
        public DbSet<Ambiente> Ambientes => Set<Ambiente>();
        public DbSet<Periodo> Periodos => Set<Periodo>();

        //Operational
        public DbSet<Proyecto> Proyectos => Set<Proyecto>();
        public DbSet<Actividad> Actividades => Set<Actividad>();
        public DbSet<Ficha> Fichas => Set<Ficha>();
        public DbSet<Horario> Horarios => Set<Horario>();
        public DbSet<Rap> raps => Set<Rap>();
        public DbSet<InstructorHorario> InstructorHorarios => Set<InstructorHorario>();
        public DbSet<ConsolidadoAmbiente> ConsolidadoAmbientes => Set<ConsolidadoAmbiente>();
        public DbSet<ConsolidadoHorario> ConsolidadoHorarios => Set<ConsolidadoHorario>();


        public readonly struct DapperEFCoreCommand : IDisposable
        {
            public DapperEFCoreCommand(DbContext context, string text, object parameters, int? timeout, CommandType? type, CancellationToken ct)
            {
                var transaction = context.Database.CurrentTransaction?.GetDbTransaction();
                var commandType = type ?? CommandType.Text;
                var commandTimeout = timeout ?? context.Database.GetCommandTimeout() ?? 30;

                Definition = new CommandDefinition(
                    text,
                    parameters,
                    transaction,
                    commandTimeout,
                    commandType,
                    cancellationToken: ct
                    );
            }

            public CommandDefinition Definition { get; }

            public void Dispose() { }
        }
    }
}
