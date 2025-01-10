using Entity.Model.Parameter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model.Operational
{
    public class Actividad
    {
        public int Id { get; set; }
        public string Actividad_proyecto { get; set; }
        public int CompetenciaId { get; set; }
        public Competencia competencia { get; set; }
        public string Result_aprendizaje { get; set; }
        public DateTime Fecha_inicio_Ac { get; set; }
        public DateTime Fecha_fin_Ac { get; set; }
        public string Estado_RAP { get; set; }
        public string Num_semanas { get; set; }
        public Boolean State { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
