using Entity.Model.Operational;
using Entity.Model.Parameter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dto.Operational
{
    public class InstructorHorarioDto
    {
        public int Id { get; set; }
        public int InstructorId { get; set; }
        public int HorarioId { get; set; }
        public string Observaciones { get; set; }
        public Boolean State { get; set; }
    }
}
