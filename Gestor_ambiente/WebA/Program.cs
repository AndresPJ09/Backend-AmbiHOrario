using Service.Implements.Additional;
using Service.Implements.Security;
using Service.Interfaces.Additional;
using Service.Interfaces.Security;
using Repository.Implements.Security;
using Repository.Interfaces.Security;
using Entity.Context;
using Entity.Dto.Security;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces.Parameter;
using Repository.Implements.Parameter;
using Service.Interfaces.Parameter;
using Service.Implements.Parameter;

namespace WebA
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //Configuracion Cords
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin",
                    builder =>
                    {
                        //policy.WithOrigins("http://localhost:4200")
                        builder.AllowAnyOrigin()
                               .AllowAnyHeader()
                               .AllowAnyMethod();
                    });
            });

            // Configura DbContext con SQL Server
            builder.Services.AddDbContext<ApplicationDBContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DbfaultConnection")));

            //Configuiracion de Reppository I,S
            builder.Services.AddScoped<IModuleRepository, ModuleRepository>();
            builder.Services.AddScoped<IPersonRepository, PersonRepository>();
            builder.Services.AddScoped<IRoleRepository, RoleRepository>();
            builder.Services.AddScoped<IRoleViewRepository, RoleViewRepository>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IUserRoleRepository, UserRoleRepository>();
            builder.Services.AddScoped<IViewRepository, ViewRepository>();
            builder.Services.AddScoped<IInstructorRepository, InstructorRepository>();
            builder.Services.AddScoped<INivelRepositoy, NivelRepository>();
            builder.Services.AddScoped<ICompetenciaRepositoy, CompetenciaRespository>();
            builder.Services.AddScoped<IProgramaRepositoy, ProgramaRepository>();
            builder.Services.AddScoped<IAmbienteRepositoy, AmbienteRepository>();

            //Configuracion de Service I,S
            builder.Services.AddScoped<IModuleService, ModuleService>();
            builder.Services.AddScoped<IPersonService, PersonService>();
            builder.Services.AddScoped<IRoleService, RoleService>();
            builder.Services.AddScoped<IRoleViewService, RoleViewService>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IUserRoleService, UserRoleService>();
            builder.Services.AddScoped<IViewService, ViewService>();
            builder.Services.AddScoped<IEmailService, EmailService>();
            builder.Services.AddScoped<IInstructorService, InstructorService>();
            builder.Services.AddScoped<INivelService, NivelService>();
            builder.Services.AddScoped<ICompetenciaService, CompetenciaService>();
            builder.Services.AddScoped<IProgramaService, ProgramaService>();
            builder.Services.AddScoped<IAmbienteService, AmbienteService>();

            // Add services to the container.
            builder.Services.AddControllers();


            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors("AllowSpecificOrigin");


            //app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}