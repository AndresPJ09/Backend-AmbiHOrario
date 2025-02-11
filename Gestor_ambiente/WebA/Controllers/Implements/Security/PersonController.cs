using Entity.Dto.Security;
using Entity.Dto;
using Microsoft.AspNetCore.Mvc;
using WebA.Controllers.Interfaces.Security;
using Service.Interfaces.Security;
using System.Text.RegularExpressions;

namespace WebA.Controllers.Implements.Security
{
    [Route("api/Person")]
    [ApiController]
    public class PersonController : ControllerBase, IPersonController
    {
        protected readonly IPersonService business;

        public PersonController(IPersonService business)
        {
            this.business = business;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await business.Delete(id);
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse<PersonDto>>> Get(int id)
        {
            var result = await business.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse<IEnumerable<PersonDto>>>> GetAll()
        {
            var result = await business.GetAll();
            return Ok(result);
        }

        [HttpGet("AllSelect")]
        public async Task<ActionResult<ApiResponse<IEnumerable<DataSelectDto>>>> GetAllSelect()
        {
            var result = business.GetAllSelect();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] PersonDto person)
        {
            if (person == null)
            {
                return BadRequest("La entidad es nula.");
            }

            try
            {
                // Validar la persona
                ValidatePerson(person);

                var result = await business.Save(person);
                return CreatedAtAction(nameof(Get), new { id = person.Id }, result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] PersonDto person)
        {
            if (person == null)
            {
                return BadRequest("La entidad es nula.");
            }

            try
            {
                // Validar la persona
                ValidatePerson(person);

                await business.Update(person);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }


        private void ValidatePerson(PersonDto entity)
        {
            // Validar Name y Last_name
            if (string.IsNullOrWhiteSpace(entity.Name) || entity.Name.Length > 50)
            {
                throw new Exception("El nombre no puede estar vacío y no debe superar los 50 caracteres.");
            }

            if (!Regex.IsMatch(entity.Name, @"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$"))
            {
                throw new Exception("El nombre solo puede contener letras y espacios.");
            }

            if (string.IsNullOrWhiteSpace(entity.Last_name) || entity.Last_name.Length > 50)
            {
                throw new Exception("El apellido no puede estar vacío y no debe superar los 50 caracteres.");
            }

            if (!Regex.IsMatch(entity.Last_name, @"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$"))
            {
                throw new Exception("El apellido solo puede contener letras y espacios.");
            }

            // Validar Email
            if (string.IsNullOrWhiteSpace(entity.Email) || entity.Email.Length > 50)
            {
                throw new Exception("El correo electrónico no puede estar vacío y no debe superar los 100 caracteres.");
            }

            if (!entity.Email.Contains("@") || !entity.Email.EndsWith("gmail.com"))
            {
                throw new Exception("El correo electrónico debe tener el formato correcto (debe contener '@' y terminar en 'gmail.com').");
            }

            // Validar Identification
            if (string.IsNullOrWhiteSpace(entity.Identification) || entity.Identification.Length > 10)
            {
                throw new Exception("La identificación no puede estar vacía y no debe superar los 10 caracteres.");
            }

            if (!Regex.IsMatch(entity.Identification, @"^\d{1,10}$") || entity.Identification.StartsWith("0"))
            {
                throw new Exception("La identificación debe contener solo números, no puede comenzar con 0 y no debe contener letras o signos.");
            }
        }

    }
}
