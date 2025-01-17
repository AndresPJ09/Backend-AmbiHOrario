using Entity.Model.Parameter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model.Operational
{
    public class Rap
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public int CompetenciaId { get; set; }
        public Competencia competencia { get; set; }
        public string estado_ideal_evaluacion_rap { get; set; }
        public Boolean State { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
