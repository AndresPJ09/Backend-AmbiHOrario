using Entity.Model.Operational;
using Entity.Model.Parameter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dto.Parameter
{
    public class PeriodoDto
    {
        public int Id { get; set; }
        public string mes { get; set; }
        public Boolean State { get; set; }
    }
}
