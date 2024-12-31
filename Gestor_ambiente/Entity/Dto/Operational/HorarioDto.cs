using Entity.Model.Operational;
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
        public int FichaId { get; set; }
        public string Jornada_programa { get; set; }
        public string Validación { get; set; }
        public string Horas { get; set; }
        public DateTime Hora_ingreso { get; set; }
        public DateTime Hora_egreso { get; set; }
        public string Observaciones { get; set; }
        public Boolean State { get; set; }
    }
}
