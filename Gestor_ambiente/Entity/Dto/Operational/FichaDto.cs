﻿using Entity.Model.Operational;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dto.Operational
{
    public class FichaDto
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public int ProgramaId { get; set; }
        public int ProyectoId { get; set; }
        public DateTime Fecha_inicio { get; set; }
        public DateTime Fecha_fin { get; set; }
        public DateTime Fin_lectiva { get; set; }
        public int Num_semanas { get; set; }
        public int Cupo { get; set; }
        public Boolean State { get; set; }
    }
}
