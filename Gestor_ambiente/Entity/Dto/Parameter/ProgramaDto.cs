using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dto.Parameter
{
    public class ProgramaDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int NivelId { get; set; }
        public bool State { get; set; }
    }
}
