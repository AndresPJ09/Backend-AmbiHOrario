using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model.Operational
{
    public class Proyecto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int ActividadId { get; set; }
        public Actividad actividad { get; set; }
        public string Jornada_tecnica { get; set; }
        public string Fase { get; set; }
        public Boolean State { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
