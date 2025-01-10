using Entity.Model.Parameter;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model.Operational
{
    public class Ficha
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public int UserId { get; set; }
        public User user { get; set; }
        public int ProgramaId { get; set; }
        public Programa programa { get; set; }
        public int AmbienteId { get; set; }
        public Ambiente ambiente { get; set; }
        public int ProyectoId { get; set; }
        public Proyecto proyecto { get; set; }
        public DateTime Fecha_inicio { get; set; }
        public DateTime Fecha_fin { get; set; }
        public DateTime Fin_lectiva { get; set; }
        public string Estado_ideal_evalu_rap { get; set; }
        public int Num_semanas { get; set; }
        public Boolean State { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
