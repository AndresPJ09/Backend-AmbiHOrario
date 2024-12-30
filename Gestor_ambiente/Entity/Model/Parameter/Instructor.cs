using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model.Parameter
{
    public class Instructor
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
        public string Periodo { get; set; }
        public DateTime Hora_ingreso { get; set; }
        public DateTime Hora_egreso { get; set; }
        public Boolean State { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
