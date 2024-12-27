using Entity.Dto;
using Entity.Dto.Parameter;
using Entity.Model.Parameter;
using Repository.Interfaces.Parameter;
using Service.Interfaces.Parameter;
using Service.Interfaces.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Implements.Parameter
{
    public class InstructorService : IInstructorService
    {
        private readonly IInstructorRepository data;

        public InstructorService(IInstructorRepository data)
        {
            this.data = data;
        }

        public async Task<InstructorDto> GetById(int id)
        {
            Instructor instructor = await data.GetById(id);
            InstructorDto instructorDto = new InstructorDto();

            instructorDto.Id = instructor.Id;
            instructorDto.Nombres = instructor.Nombres;
            instructorDto.Apellidos = instructor.Apellidos;
            instructorDto.Foto = instructor.Foto;
            instructorDto.Identificacion = instructor.Identificacion;
            instructorDto.Vinculo = instructor.Vinculo;
            instructorDto.Especialidad = instructor.Especialidad;
            instructorDto.Correo = instructor.Correo;
            instructorDto.Fecha_inicio = instructor.Fecha_inicio;
            instructorDto.Periodo = instructor.Periodo;
            instructorDto.Hora_ingreso = instructor.Hora_ingreso;
            instructorDto.Hora_egreso = instructor.Hora_egreso;
            instructorDto.State = instructor.State;
            return instructorDto;
        }

        public async Task<IEnumerable<InstructorDto>> GetAll()
        {
            IEnumerable<InstructorDto> instructores = await data.GetAll();
            var instructorDtos = instructores.Select(instructor => new InstructorDto
            {
                Id = instructor.Id,
                Nombres = instructor.Nombres,
                Apellidos = instructor.Apellidos,
                Foto = instructor.Foto,
                Identificacion = instructor.Identificacion,
                Vinculo = instructor.Vinculo,
                Especialidad = instructor.Especialidad,
                Correo = instructor.Correo,
                Fecha_inicio = instructor.Fecha_inicio,
                Periodo = instructor.Periodo,
                Hora_ingreso = instructor.Hora_ingreso,
                Hora_egreso = instructor.Hora_egreso,
                State = instructor.State,
            });

            return instructorDtos;
        }

        public async Task<Instructor> Save(InstructorDto entity)
        {
            Instructor instructor = new Instructor();
            instructor = mapearDatos(instructor, entity);
            instructor.CreatedAt = DateTime.Now;
            instructor.State = true;
            instructor.DeletedAt = null;
            instructor.UpdatedAt = null;
            return await data.Save(instructor);
        }

        public async Task Update(InstructorDto entity)
        {
            Instructor instructor = await data.GetById(entity.Id);
            if (instructor == null)
            {
                throw new Exception("Registro no encontrado");
            }
            instructor = mapearDatos(instructor, entity);
            instructor.UpdatedAt = DateTime.Now;

            await data.Update(instructor);
        }

        public async Task Delete(int id)
        {
            await data.Delete(id);
        }

        public Instructor mapearDatos(Instructor instructor, InstructorDto entity)
        {
            instructor.Id = entity.Id;
            instructor.Nombres = entity.Nombres;
            instructor.Apellidos = entity.Apellidos;
            instructor.Foto = entity.Foto;
            instructor.Identificacion = entity.Identificacion;
            instructor.Vinculo = entity.Vinculo;
            instructor.Especialidad = entity.Especialidad;
            instructor.Correo = entity.Correo;
            instructor.Fecha_inicio = entity.Fecha_inicio;
            instructor.Periodo = entity.Periodo;
            instructor.Hora_ingreso = entity.Hora_ingreso;
            instructor.Hora_egreso = entity.Hora_egreso;
            instructor.State = entity.State;
            return instructor;


        }

        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            return await data.GetAllSelect();
        }
    }
}
