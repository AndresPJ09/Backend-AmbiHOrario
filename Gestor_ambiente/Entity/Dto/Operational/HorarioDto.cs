using Entity.Model.Operational;
using Entity.Model.Parameter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dto.Operational
{
    public class HorarioDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int FichaId { get; set; }
        public int AmbienteId { get; set; }
        public int PeriodoId { get; set; }
        public string Jornada_programa { get; set; }
        public DateTime Fecha_inicio { get; set; }
        public DateTime Hora_ingreso { get; set; }
        public DateTime Hora_egreso { get; set; }
        public string Validación { get; set; }
        public string Horas { get; set; }
        public string Observaciones { get; set; }
        public Boolean State { get; set; }
    }
}