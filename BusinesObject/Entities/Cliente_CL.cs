using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinesObject.Entities
{
   public class Cliente_CL
    {
        public string tipo_documento { get; set; }
        public int documento { get; set; }
        public string primer_nombre { get; set; }
        public string segundo_nombre { get; set; }
        public string primer_apellido { get; set; }
        public string segundo_apellido { get; set; }
        public string celular { get; set; }
        public string direccion { get; set; }
        public string email { get; set; }
    }
}
