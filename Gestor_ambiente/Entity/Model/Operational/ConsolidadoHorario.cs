using Entity.Model.Parameter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model.Operational
{
    public class ConsolidadoHorario
    {
        public int Id { get; set; }
        public int FichaID { get; set; }
        public Ficha ficha { get; set; }
        public int InstructorId { get; set; }
        public Instructor instructor { get; set; }
        public string Observaciones { get; set; }
        public Boolean State { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
