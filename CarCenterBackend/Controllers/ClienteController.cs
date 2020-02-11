using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BusinesObject.Entities;
using BusinessLogic.Business;
using System.Web.Http.Cors;
using System.Web.Http.Description;

namespace CarCenterBackend.Controllers
{
    public class ClienteController : ApiController
    {
        /// <summary>
        /// Metodo inserta un nuevo empleado
        /// </summary>
        /// <param name="cliente">método post</param>
        /// <returns></returns>
        [HttpPost]
        [Route("Api/insertarCliente")]
        [ResponseType(typeof(DataResponse_CL<string>))]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IHttpActionResult insertarCliente(Cliente_CL cliente)
        {
            DataResponse_CL<string> resultCiente = new Cliente_BL().insertarCliente(cliente);
            return Ok(resultCiente);
        }
        
        /// <summary>
        /// Metodo elimina un cliente
        /// </summary>
        /// <param name="tipo_documento">tipo de documento</param>
        /// <param name="documento">documento</param>
        /// <returns></returns>
        [HttpDelete]
        [Route("Api/eliminarCliente/{tipo_documento}/{documento}")]
        [ResponseType(typeof(DataResponse_CL<string>))]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IHttpActionResult eliminarCliente(string tipo_documento, string documento)
        {
            DataResponse_CL<string> resultCiente = new Cliente_BL().eliminarCliente( tipo_documento,  documento);
            return Ok(resultCiente);
        }

        /// <summary>
        /// Método actualiza un cliente
        /// </summary>
        /// <param name="cliente"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("Api/actualizarCliente")]
        [ResponseType(typeof(DataResponse_CL<string>))]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IHttpActionResult actualizarCliente(Cliente_CL cliente)
        {
            DataResponse_CL<string> resultCiente = new Cliente_BL().actualizarCliente(cliente);
            return Ok(resultCiente);
        }

        /// <summary>
        /// M´rtodo consulta los clientes
        /// </summary>
        /// <param name="tipo_documento">tipo documento</param>
        /// <param name="documento">documento</param>
        /// <returns></returns>
        [HttpGet]
        [Route("Api/consultarCliente/{tipo_documento}/{documento}")]
        [ResponseType(typeof(DataResponse_CL<Cliente_CL>))]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IHttpActionResult consultarCliente(string tipo_documento, string documento)
        {
            DataResponse_CL<Cliente_CL> resultCiente = new Cliente_BL().consultarCliente(tipo_documento,  documento);
            return Ok(resultCiente);
        }
    }
}
