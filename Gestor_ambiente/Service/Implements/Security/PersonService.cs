using Entity.Dto.Security;
using Entity.Dto;
using Entity.Model.Security;
using Service.Interfaces.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Interfaces.Security;
using System.Reflection;

namespace Service.Implements.Security
{
    public class PersonService: IPersonService
    {
        protected readonly IPersonRepository data;

        public PersonService(IPersonRepository data)
        {
            this.data = data;
        }

        public async Task Delete(int id)
        {
            await data.Delete(id);
        }

        public async Task<IEnumerable<PersonDto>> GetAll()
        {
            IEnumerable<Person> persons = await data.GetAll();
            var personDtos = persons.Select(person => new PersonDto
            {
                Id = person.Id,
                Name = person.Name,
                Last_name = person.Last_name,
                Email = person.Email,
                Identification = person.Identification,
                State = person.State
            });

            return personDtos;
        }

        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            return await data.GetAllSelect();
        }

        public async Task<PersonDto> GetById(int id)
        {
            Person person = await data.GetById(id);
            PersonDto personDto = new PersonDto();

            personDto.Id = person.Id;
            personDto.Name = person.Name;
            personDto.Last_name = person.Last_name;
            personDto.Email = person.Email;
            personDto.Identification = person.Identification;
            personDto.State = person.State;
            return personDto;
        }

        public Person mapearDatos(Person person, PersonDto entity)
        {
            person.Id = entity.Id;
            person.Name = entity.Name;
            person.Last_name = entity.Last_name;
            person.Email = entity.Email;
            person.Identification = entity.Identification;
            person.State = entity.State;
            return person;
        }

        public async Task<Person> Save(PersonDto entity)
        {
            var persons = await data.GetAll(); // Obtener todos los módulos (esto es asíncrono)
            // Validar que el identificación sea único
            if (persons.Any(p => p.Identification == entity.Identification)) // Si la identificación ya existe, lanzamos una excepción
            {
                throw new Exception("La identificación de person ya existe.");
            }

            // Validar que el correo sea único
            if (persons.Any(p => p.Email == entity.Email)) // Si la correo ya existe, lanzamos una excepción
            {
                throw new Exception("El correo de persona ya existe.");
            }

            Person person = new Person();
            person = mapearDatos(person, entity);
            person.CreatedAt = DateTime.Now;
            person.State = true;
            person.DeletedAt = null;
            person.UpdatedAt = null;

            return await data.Save(person);
        }

        public async Task Update(PersonDto entity)
        {
            var persons = await data.GetAll(); 

            if (persons.Any(p => p.Identification == entity.Identification && p.Id != entity.Id))
            {
                throw new Exception("La identificación de persona  ya existe.");
            }

            if (persons.Any(p => p.Email == entity.Email && p.Id != entity.Id))
            {
                throw new Exception("El correo de persona  ya existe.");
            }

            Person person = await data.GetById(entity.Id);
            if (person == null)
            {
                throw new Exception("Registro no encontrado");
            }
            person = mapearDatos(person, entity);
            person.UpdatedAt = DateTime.Now;

            await data.Update(person);
        }
    }
}
