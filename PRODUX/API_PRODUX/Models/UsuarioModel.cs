using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Linq;
using System.Web;

namespace API_PRODUX.Models
{
    public class UsuarioModel
    {
        public UsuarioModel() { }

        public string Usuario { get; set; }

        public string Contrasenna { get; set; }

        public int Estado { get; set; }

        public string Usuario_Creacion { get; set; }


        public static string ValidarUsuarios(string IdUsuario, string Contrasenna)
        {
            OdbcConnection conn = Conexion.obtenerConexion();

            try
            {
                OdbcCommand command = new OdbcCommand();
                string Sql = "{call sp_Validar_Usuario(?,?)}";

                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = Sql;
                command.Connection = conn;

                command.Parameters.Add("@Id_Usuario", OdbcType.VarChar);
                command.Parameters["@Id_Usuario"].Value = IdUsuario;
                command.Parameters.Add("@Contrasenna", OdbcType.VarChar);
                command.Parameters["@Contrasenna"].Value = Contrasenna;

                OdbcDataReader reader = command.ExecuteReader();

                string valor = "";

                while (reader.Read())
                {

                    valor = reader["Id_Usuario"].ToString();
                }
                reader.Close();
                return valor;
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

        //Lista
        public List<UsuarioModel> SeleccionarUsuarios()
        {
            OdbcConnection conn = Conexion.obtenerConexion();

            try
            {
                OdbcCommand command = new OdbcCommand();
                string Sql = "{call [dbo].[sp_Seleccionar_Usuarios]}";

                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = Sql;
                command.Connection = conn;

                OdbcDataReader reader = command.ExecuteReader();

                List<UsuarioModel> lista = new List<UsuarioModel>();
                while (reader.Read())
                {
                    UsuarioModel Usuario = new UsuarioModel();

                    Usuario.Usuario = reader["Id_Usuario"].ToString();
                    Usuario.Contrasenna = reader["Contrasenna"].ToString();
                    Usuario.Estado = Convert.ToInt32(reader["Estado"].ToString());
                    lista.Add(Usuario);
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

        public List<UsuarioModel> SeleccionarUsuariosPorCodigo(string IdUsuario)
        {
            OdbcConnection conn = Conexion.obtenerConexion();

            try
            {
                OdbcCommand command = new OdbcCommand();
                string Sql = "{call [dbo].[sp_Seleccionar_Usuarios](?)}";

                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = Sql;
                command.Connection = conn;

                command.Parameters.Add("@Id_Usuario", OdbcType.VarChar);
                command.Parameters["@Id_Usuario"].Value = IdUsuario;

                OdbcDataReader reader = command.ExecuteReader();

                List<UsuarioModel> lista = new List<UsuarioModel>();

                while (reader.Read())
                {
                    UsuarioModel Usuario = new UsuarioModel();

                    Usuario.Usuario = reader["Id_Usuario"].ToString();
                    Usuario.Contrasenna = reader["Contrasenna"].ToString();
                    Usuario.Estado = Convert.ToInt32(reader["Estado"].ToString());
                    lista.Add(Usuario);
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

        public void InsertarUsuario(UsuarioModel usuario)
        {
            OdbcConnection conn = Conexion.obtenerConexion();
            try
            {
                OdbcCommand command = new OdbcCommand();
                string Sql = "{call [dbo].[sp_Insertar_Usuario](?,?,?,?)}";

                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = Sql;
                command.Connection = conn;

                command.Parameters.Add("@Id_Usuario", OdbcType.VarChar);
                command.Parameters["@Id_Usuario"].Value = usuario.Usuario;
                command.Parameters.Add("@Contrasenna", OdbcType.VarChar);
                command.Parameters["@Contrasenna"].Value = usuario.Contrasenna;
                command.Parameters.Add("@Estado", OdbcType.Int);
                command.Parameters["@Estado"].Value = usuario.Estado;
                command.Parameters.Add("@Usuario_Creacion", OdbcType.VarChar);
                command.Parameters["@Usuario_Creacion"].Value = usuario.Usuario_Creacion;//Usuario Logueado

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
        public void ActualizarUsuario(UsuarioModel usuario)
        {
            OdbcConnection conn = Conexion.obtenerConexion();
            try
            {
                OdbcCommand command = new OdbcCommand();
                string Sql = "{call [dbo].[sp_Actualizar_Usuario](?,?,?)}";

                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = Sql;
                command.Connection = conn;

                command.Parameters.Add("@Id_Usuario", OdbcType.VarChar);
                command.Parameters["@Id_Usuario"].Value = usuario.Usuario;
                command.Parameters.Add("@Contrasenna", OdbcType.VarChar);
                command.Parameters["@Contrasenna"].Value = usuario.Contrasenna;
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
        //Inactivar

        public void InactivarUsuario(UsuarioModel usuario)
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