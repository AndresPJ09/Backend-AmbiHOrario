using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dto.Operational
{
    public class ProyectoDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Jornada_tecnica { get; set; }
        public int ActividadId { get; set; }
        public string Fase { get; set; }
        public Boolean State { get; set; }
    }
}
