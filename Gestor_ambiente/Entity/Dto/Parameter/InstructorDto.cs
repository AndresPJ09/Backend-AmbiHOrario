using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dto.Parameter
{
    public class InstructorDto
    {
        public int Id { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public byte[]? Foto { get; set; }
        public string Identificacion { get; set; }
        public string Vinculo { get; set; }
        public string Especialidad { get; set; }
        public string Correo { get; set; }
        public DateTime Fecha_inicio { get; set; }
        public DateTime Hora_ingreso { get; set; }
        public DateTime Hora_egreso { get; set; }
        public bool State { get; set; }
    }
}
