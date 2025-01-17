using Entity.Model.Parameter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dto.Operational
{
    public class RapDto
    {
        public int Id { get; set; }
        public string Descripción { get; set; }
        public int CompetenciaId { get; set; }
        public string estado_ideal_evaluacion_rap { get; set; }
        public Boolean State { get; set; }
    }
}
