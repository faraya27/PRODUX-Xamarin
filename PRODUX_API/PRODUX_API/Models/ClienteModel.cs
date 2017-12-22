using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Linq;
using System.Web;

namespace PRODUX_API.Models
{
    public class ClienteModel
    {
        public ClienteModel() { }

        public string Cedula { get; set; }

        public string Nombre { get; set; }

        public string Telefono { get; set; }

        public string Email { get; set; }

        public int Estado { get; set; }

        public string Direccion { get; set; }
        public string Usuario_Creacion { get; set; }

        //Lista


        public List<ClienteModel> SeleccionarUsuarios()
        {
            OdbcConnection conn = Conexion.obtenerConexion();

            try
            {
                OdbcCommand command = new OdbcCommand();
                string Sql = "{call [dbo].[sp_Seleccionar_Cliente]}";

                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = Sql;
                command.Connection = conn;

                OdbcDataReader reader = command.ExecuteReader();

                List<ClienteModel> lista = new List<ClienteModel>();
                while (reader.Read())
                {
                    ClienteModel Cliente = new ClienteModel();

                    Cliente.Cedula = reader["Cedula"].ToString();
                    Cliente.Nombre = reader["Nombre"].ToString();
                    Cliente.Direccion = reader["Direccion"].ToString();
                    Cliente.Telefono = reader["Telefono"].ToString();
                    Cliente.Email = reader["Correo"].ToString();
                    Cliente.Estado = Convert.ToInt32(reader["Estado"].ToString());
                    lista.Add(Cliente);
                }
                reader.Close();
                return lista;
            }
            catch (OdbcException ax)
            {
                throw new ApplicationException("Error en Base de Datos..! \n" + ax.Message);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("ERROR AL OBTENER LA CONSULTA. DETALLE: " + ex.Message);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
        //Por codigo

        public List<ClienteModel> SeleccionarClientesPorCodigo(string Cedula)
        {
            OdbcConnection conn = Conexion.obtenerConexion();

            try
            {
                OdbcCommand command = new OdbcCommand();
                string Sql = "{call [dbo].[sp_Seleccionar_Cliente_Por_Codigo](?)}";

                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = Sql;
                command.Connection = conn;

                command.Parameters.Add("@Cedula", OdbcType.VarChar);
                command.Parameters["@Cedula"].Value = Cedula;

                OdbcDataReader reader = command.ExecuteReader();

                List<ClienteModel> lista = new List<ClienteModel>();

                while (reader.Read())
                {

                    ClienteModel Cliente = new ClienteModel();

                    Cliente.Cedula = reader["Cedula"].ToString();
                    Cliente.Nombre = reader["Nombre"].ToString();
                    Cliente.Direccion = reader["Direccion"].ToString();
                    Cliente.Telefono = reader["Telefono"].ToString();
                    Cliente.Email = reader["Correo"].ToString();
                    Cliente.Estado = Convert.ToInt32(reader["Estado"].ToString());
                    lista.Add(Cliente);
                }
                reader.Close();
                return lista;
            }
            catch (OdbcException ax)
            {
                throw new ApplicationException("Error en Base de Datos..! \n" + ax.Message);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("ERROR AL OBTENER LA CONSULTA. DETALLE: " + ex.Message);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
        //insertar

        public void InsertarCliente(ClienteModel cliente)
        {
            OdbcConnection conn = Conexion.obtenerConexion();
            try
            {
                OdbcCommand command = new OdbcCommand();
                string Sql = "{call [dbo].[sp_Insertar_Usuario](?,?,?,?,?,?,?)}";

                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = Sql;
                command.Connection = conn;

                command.Parameters.Add("@Cedula", OdbcType.VarChar);
                command.Parameters["@Cedula"].Value = cliente.Cedula;
                command.Parameters.Add("@Nombre", OdbcType.VarChar);
                command.Parameters["@Nombre"].Value = cliente.Nombre;
                command.Parameters.Add("@Direccion", OdbcType.VarChar);
                command.Parameters["@Direccion"].Value = cliente.Direccion;
                command.Parameters.Add("@Telefono", OdbcType.VarChar);
                command.Parameters["@Telefono"].Value = cliente.Telefono;//Usuario Logueado
                command.Parameters.Add("@Correo", OdbcType.VarChar);
                command.Parameters["@Correo"].Value = cliente.Email;
                command.Parameters.Add("@Estado", OdbcType.Int);
                command.Parameters["@Estado"].Value = cliente.Estado;
                command.Parameters.Add("@Usuario_Creacion", OdbcType.VarChar);
                command.Parameters["@Usuario_Creacion"].Value = cliente.Usuario_Creacion;
                command.ExecuteNonQuery();

                command.Dispose();


            }
            catch (OdbcException ax)
            {
                throw new ApplicationException("Error en Base de Datos..! \n" + ax.Message);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
        //Modificar
        public void ActualizarCliente(ClienteModel cliente)
        {
            OdbcConnection conn = Conexion.obtenerConexion();
            try
            {
                OdbcCommand command = new OdbcCommand();
                string Sql = "{call [dbo].[sp_Actualizar_Cliente](?,?,?,?,?,?)}";

                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = Sql;
                command.Connection = conn;

                command.Parameters.Add("@Cedula", OdbcType.VarChar);
                command.Parameters["@Cedula"].Value = cliente.Cedula;
                command.Parameters.Add("@Nombre", OdbcType.VarChar);
                command.Parameters["@Nombre"].Value = cliente.Nombre;
                command.Parameters.Add("@Direccion", OdbcType.VarChar);
                command.Parameters["@Direccion"].Value = cliente.Direccion;
                command.Parameters.Add("@Telefono", OdbcType.VarChar);
                command.Parameters["@Telefono"].Value = cliente.Telefono;//Usuario Logueado
                command.Parameters.Add("@Correo", OdbcType.VarChar);
                command.Parameters["@Correo"].Value = cliente.Email;
                command.Parameters.Add("@Estado", OdbcType.Int);
                command.Parameters["@Estado"].Value = cliente.Estado;
               command.ExecuteNonQuery();

                command.Dispose();


            }
            catch (OdbcException ax)
            {
                throw new ApplicationException("Error en Base de Datos..! \n" + ax.Message);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
        //Inactivar

        public void InactivarCliente(UsuarioModel usuario)
        {
            OdbcConnection conn = Conexion.obtenerConexion();
            try
            {
                OdbcCommand command = new OdbcCommand();
                string Sql = "{call [dbo].[sp_Inactivar_Usuario](?,?)}";

                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = Sql;
                command.Connection = conn;

                command.Parameters.Add("@Id_Usuario", OdbcType.VarChar);
                command.Parameters["@Id_Usuario"].Value = usuario.Usuario;
                command.Parameters.Add("@Estado", OdbcType.Int);
                command.Parameters["@Estado"].Value = usuario.Estado;

                command.ExecuteNonQuery();

                command.Dispose();


            }
            catch (OdbcException ax)
            {
                throw new ApplicationException("Error en Base de Datos..! \n" + ax.Message);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
    }
}