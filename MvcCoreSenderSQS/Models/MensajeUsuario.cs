using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCoreSenderSQS.Models
{
    public class MensajeUsuario
    {
        public String Asunto { get; set; }
        public String Email { get; set; }
        public String Mensaje { get; set; }
        public DateTime FechaMensaje { get; set; }
    }
}
