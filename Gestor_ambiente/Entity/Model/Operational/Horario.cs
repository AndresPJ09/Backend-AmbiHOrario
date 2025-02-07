using Entity.Model.Parameter;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model.Operational
{
    public class Horario
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User user { get; set; }
        public int FichaId { get; set; }
        public Ficha ficha { get; set; }
        public int AmbienteId { get; set; }
        public Ambiente ambiente { get; set; }
        public int PeriodoId { get; set; }
        public Periodo periodo { get; set; }
        public string Jornada_programa { get; set; }
        public DateTime Fecha_inicio { get; set; }
        public DateTime Hora_ingreso { get; set; }
        public DateTime Hora_egreso { get; set; }
        public string Validacion { get; set; }
        public string Horas { get; set; }
        public string Observaciones { get; set; }
        public Boolean State { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
