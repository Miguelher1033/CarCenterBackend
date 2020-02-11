using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using BusinesObject.Entities;

namespace DataAccess.Repositories
{
    public class Cliente_DA
    {
        string sConnection = ConfigurationManager.ConnectionStrings["CarCenter"].ConnectionString;

        public DataResponse_CL<string> insertarCliente(Cliente_CL cliente)
        {
            SqlConnection cn = new SqlConnection(sConnection);
            try
            {
                SqlCommand cmd = new SqlCommand("INSERTAR_CLIENTE", cn);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@tipo_documento", SqlDbType.VarChar).Value = cliente.tipo_documento;
                cmd.Parameters.Add("@documento", SqlDbType.Int).Value = cliente.documento;
                cmd.Parameters.Add("@primer_nombre", SqlDbType.VarChar).Value = cliente.primer_nombre;
                cmd.Parameters.Add("@primer_apellido", SqlDbType.VarChar).Value = cliente.primer_apellido;
                cmd.Parameters.Add("@segundo_nombre", SqlDbType.VarChar).Value = cliente.segundo_nombre;
                cmd.Parameters.Add("@segundo_apellido", SqlDbType.VarChar).Value = cliente.segundo_apellido;
                cmd.Parameters.Add("@celular", SqlDbType.VarChar).Value = cliente.celular;
                cmd.Parameters.Add("@direccion", SqlDbType.VarChar).Value = cliente.direccion;
                cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = cliente.email;

                cn.Open();
                cmd.ExecuteNonQuery();

                return new DataResponse_CL<string>()
                {
                    Code = 1,
                    Message = "ok",
                    Results = null
                };


            }
            catch (Exception ex)
            {
                return new DataResponse_CL<string>()
                {
                    Code = 0,
                    Message = ex.Message,
                    Results = null
                };

            }
            finally
            {
                cn.Close();
                cn.Dispose();
            }


        }
        public DataResponse_CL<string> eliminarCliente(string tipo_documento, string documento)
        {
            SqlConnection cn = new SqlConnection(sConnection);
            try
            {
                SqlCommand cmd = new SqlCommand("ELIMINAR_CLIENTE", cn);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@tipo_documento", SqlDbType.VarChar).Value = tipo_documento;
                cmd.Parameters.Add("@documento", SqlDbType.Int).Value = documento;

                cn.Open();
                cmd.ExecuteNonQuery();

                return new DataResponse_CL<string>()
                {
                    Code = 1,
                    Message = "Cliente eliminado correctamente",
                    Results = null
                };


            }
            catch (Exception ex)
            {
                return new DataResponse_CL<string>()
                {
                    Code = 0,
                    Message = ex.Message,
                    Results = null
                };

            }
            finally
            {
                cn.Close();
                cn.Dispose();
            }


        }
        public DataResponse_CL<string> actualizarCliente(Cliente_CL cliente)
        {
            SqlConnection cn = new SqlConnection(sConnection);
            try
            {
                SqlCommand cmd = new SqlCommand("ACTUALIZAR_CLIENTE", cn);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@tipo_documento", SqlDbType.VarChar).Value = cliente.tipo_documento;
                cmd.Parameters.Add("@documento", SqlDbType.Int).Value = cliente.documento;
                cmd.Parameters.Add("@primer_nombre", SqlDbType.VarChar).Value = cliente.primer_nombre;
                cmd.Parameters.Add("@primer_apellido", SqlDbType.VarChar).Value = cliente.primer_apellido;
                cmd.Parameters.Add("@segundo_nombre", SqlDbType.VarChar).Value = cliente.segundo_nombre;
                cmd.Parameters.Add("@segundo_apellido", SqlDbType.VarChar).Value = cliente.segundo_apellido;
                cmd.Parameters.Add("@celular", SqlDbType.VarChar).Value = cliente.celular;
                cmd.Parameters.Add("@direccion", SqlDbType.VarChar).Value = cliente.direccion;
                cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = cliente.email;

                cn.Open();
                cmd.ExecuteNonQuery();

                return new DataResponse_CL<string>()
                {
                    Code = 1,
                    Message = "Cliente actualizado correctamente",
                    Results = null
                };


            }
            catch (Exception ex)
            {
                return new DataResponse_CL<string>()
                {
                    Code = 0,
                    Message = ex.Message,
                    Results = null
                };

            }
            finally
            {
                cn.Close();
                cn.Dispose();
            }


        }
        public DataResponse_CL<Cliente_CL> consultarCliente(string tipo_documento, string documento)
        {
            List<Cliente_CL> lstCliente = new List<Cliente_CL>();

            SqlConnection cn = new SqlConnection(sConnection);
            try
            {
                SqlCommand cmd = new SqlCommand("CONSULTAR_CLIENTE", cn);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@tipo_documento", SqlDbType.VarChar).Value = tipo_documento;
                cmd.Parameters.Add("@documento", SqlDbType.Int).Value = documento;

                cn.Open();

                SqlDataReader dr = null;
                dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {

                    while (dr.Read())
                    {
                        lstCliente.Add(new Cliente_CL
                        {
                            tipo_documento = dr["tipo_documento"].ToString(),
                            documento = int.Parse(dr["documento"].ToString()),
                            primer_nombre = dr["primer_nombre"].ToString(),
                            segundo_nombre = dr["segundo_nombre"].ToString(),
                            primer_apellido = dr["primer_apellido"].ToString(),
                            segundo_apellido = dr["segundo_apellido"].ToString(),
                            celular = dr["celular"].ToString(),
                            direccion = dr["direccion"].ToString(),
                            email = dr["email"].ToString()
                        });

                    }
                    dr.Close();
                    return new DataResponse_CL<Cliente_CL>()
                    {
                        Code = 1,
                        Message = "ok",
                        Results = lstCliente
                    };
                }
                else
                {
                    return new DataResponse_CL<Cliente_CL>()
                    {
                        Code = 0,
                        Message = "Cliente no encontrado",
                        Results = null
                    };

                }

            }
            catch (Exception ex)
            {
                return new DataResponse_CL<Cliente_CL>()
                {
                    Code = 0,
                    Message = ex.Message,
                    Results = null
                };

            }
            finally
            {
                cn.Close();
                cn.Dispose();
            }


        }
    }
}
