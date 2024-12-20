using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dto.Security
{
    public class moduleDao
    {
        public string Module {  get; set; }
        public string ModuleDescription { get; set; }
        public List<ViewDao> Views { get; set; }
    }
}
