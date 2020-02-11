using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinesObject.Entities;
using DataAccess.Repositories;

namespace BusinessLogic.Business
{
   public class Cliente_BL
    {
        public DataResponse_CL<string> insertarCliente(Cliente_CL cliente)
        {
            return new Cliente_DA().insertarCliente(cliente);
        }
        public DataResponse_CL<string> eliminarCliente(string tipo_documento, string documento)
        {
            return new Cliente_DA().eliminarCliente(tipo_documento, documento);
        }
        public DataResponse_CL<string> actualizarCliente(Cliente_CL cliente)
        {
            return new Cliente_DA().actualizarCliente(cliente);
        }
        public DataResponse_CL<Cliente_CL> consultarCliente(string tipo_documento, string documento)
        {
            return new Cliente_DA().consultarCliente(tipo_documento, documento);
        }
    }
}
