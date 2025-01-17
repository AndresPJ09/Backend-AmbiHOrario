using Entity.Model.Operational;
using Entity.Model.Parameter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dto.Operational
{
    public class ActividadDto
    {
        public int Id { get; set; }
        public string Actividad_proyecto { get; set; }
        public int CompetenciaId { get; set; }
        public DateTime Fecha_inicio_Ac { get; set; }
        public DateTime Fecha_fin_Ac { get; set; }
        public string Num_semanas { get; set; }
        public Boolean State { get; set; }
    }
}
