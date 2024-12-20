using Entity.Dto.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces.Additional
{
    public interface IEmailService
    {
        Task<bool> SendEmail(EmailDto request);
        Task<string> CrearEventoEnlaceAsync(string fechaEntrada, string fechaSalida, string descripcion, string ciudad, string departamento, string pais, string nombre);
    }
}
