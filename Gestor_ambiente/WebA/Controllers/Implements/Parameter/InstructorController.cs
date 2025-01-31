using Entity.Dto;
using Entity.Dto.Parameter;
using Entity.Model.Security;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces.Parameter;
using System;
using WebA.Controllers.Interfaces.Parameter;
using static Dapper.SqlMapper;
namespace WebA.Controllers.Implements.Parameter
{
    [Route("api/Instructor")]
    [ApiController]
    public class InstructorController : ControllerBase, IInstructorController
    {
        protected readonly IInstructorService business;

        public InstructorController(IInstructorService business)
        {
            this.business = business;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse<InstructorDto>>> Get(int id)
        {
            var result = await business.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse<IEnumerable<InstructorDto>>>> GetAll()
        {
            var result = await business.GetAll();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] InstructorDto instructor)
        {
            if (instructor == null)
            {
                return BadRequest("Entity is null.");
            }
            try
            {
                ValidateHorario(instructor.Hora_ingreso, instructor.Hora_egreso);

                var result = await business.Save(instructor);
                return CreatedAtAction(nameof(Get), new { id = instructor.Id }, result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] InstructorDto instructor)
        {
            if (instructor == null)
            {
                return BadRequest();
            }
            try
            {
                // Validar la persona
                ValidateHorario(instructor.Hora_ingreso, instructor.Hora_egreso);

                await business.Update(instructor);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await business.Delete(id);
            return NoContent();
        }

        [HttpGet("AllSelect")]
        public async Task<ActionResult<ApiResponse<IEnumerable<DataSelectDto>>>> GetAllSelect()
        {
            var result = await business.GetAllSelect();
            return Ok(result);
        }

        private void ValidateHorario(DateTime horaIngreso, DateTime horaEgreso)
        {
            // Definir las horas permitidas
            TimeSpan horaMinima = TimeSpan.FromHours(6); // 6:00 AM
            TimeSpan horaMaxima = TimeSpan.FromHours(18); // 6:00 PM

            if (horaIngreso.TimeOfDay < horaMinima || horaIngreso.TimeOfDay > horaMaxima)
            {
                throw new Exception("La hora de ingreso debe estar entre las 6:00 AM y las 6:00 PM.");
            }

            if (horaEgreso.TimeOfDay < horaMinima || horaEgreso.TimeOfDay > horaMaxima)
            {
                throw new Exception("La hora de egreso debe estar entre las 6:00 AM y las 6:00 PM.");
            }

            if (horaIngreso >= horaEgreso)
            {
                throw new Exception("La hora de ingreso no puede ser mayor o igual a la hora de egreso.");
            }
        }
    }
}
