using API_PRODUX.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Linq;
using System.Web;

namespace PRODUX_API.Models
{
    public class PedidoLineaModel
    {
        public string Id_Pedido { get; set; }
        public string Id_Producto { get; set; }
        public double Cant_Solicitada { get; set; }
        public double Precio_Unitario { get; set; }
        public double Subtotal { get; set; }
        public string Desc_Producto { get; set; }

        public string Imagen { get; set; }

        public bool Seleccionado { get; set; }



        public static List<PedidoLineaModel> SeleccionarPedidoLinea(string IdPedido)
        {
            OdbcConnection conn = Conexion.obtenerConexion();

            try
            {
                OdbcCommand command = new OdbcCommand();
                string Sql = "{call [dbo].[sp_Seleccionar_Pedido_Linea_Por_Codigo](?)}";

                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = Sql;
                command.Connection = conn;

                command.Parameters.Add("@Id_Pedido", OdbcType.VarChar);
                command.Parameters["@Id_Pedido"].Value = IdPedido;

                OdbcDataReader reader = command.ExecuteReader();

                List<PedidoLineaModel> lista = new List<PedidoLineaModel>();

                while (reader.Read())
                {

                    PedidoLineaModel pedidoLinea = new PedidoLineaModel();

                    pedidoLinea.Id_Pedido = reader["Id_Pedido"].ToString();
                    pedidoLinea.Id_Producto = reader["Id_Producto"].ToString();
                    pedidoLinea.Cant_Solicitada = Convert.ToDouble(reader["Cant_Solicitada"].ToString());
                    pedidoLinea.Precio_Unitario = Convert.ToDouble(reader["Precio_Unitario"].ToString());
                    pedidoLinea.Subtotal = Convert.ToDouble(reader["Subtotal"].ToString());
                    pedidoLinea.Desc_Producto = reader["Descripcion"].ToString();
                    pedidoLinea.Imagen = reader["Imagen"].ToString();
                    pedidoLinea.Seleccionado = Convert.ToBoolean(int.Parse(reader["Seleccionado"].ToString()));
                    lista.Add(pedidoLinea);
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

        public static string InsertarPedidoLinea(PedidoLineaModel pedido)
        {
            OdbcConnection conn = Conexion.obtenerConexion();
            try
            {
                OdbcCommand command = new OdbcCommand();
                string Sql = "{call [dbo].[sp_Insertar_Pedido_Linea](?,?,?,?,?)}";

                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = Sql;
                command.Connection = conn;

                command.Parameters.Add("@Id_Pedido", OdbcType.VarChar);
                command.Parameters["@Id_Pedido"].Value = pedido.Id_Pedido;
                command.Parameters.Add("@Id_Producto", OdbcType.VarChar);
                command.Parameters["@Id_Producto"].Value = pedido.Id_Producto;
                command.Parameters.Add("@Cant_Solicitada", OdbcType.Decimal);
                command.Parameters["@Cant_Solicitada"].Value = pedido.Cant_Solicitada;
                command.Parameters.Add("@Precio_Unitario", OdbcType.Decimal);
                command.Parameters["@Precio_Unitario"].Value = pedido.Precio_Unitario;//Usuario Logueado
                command.Parameters.Add("@Subtotal", OdbcType.Decimal);
                command.Parameters["@Subtotal"].Value = pedido.Subtotal;
                command.ExecuteNonQuery();

                command.Dispose();
                return "true";

            }
            catch (Exception ax)
            {
                return "false";
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
        //Modificar
        public static string ActualizarPedidoLinea(PedidoLineaModel pedido)
        {
            OdbcConnection conn = Conexion.obtenerConexion();
            try
            {
                OdbcCommand command = new OdbcCommand();
                string Sql = "{call [dbo].sp_Actualizar_Pedido_Linea(?,?,?,?,?)}";

                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = Sql;
                command.Connection = conn;

                command.Parameters.Add("@Id_Pedido", OdbcType.VarChar);
                command.Parameters["@Id_Pedido"].Value = pedido.Id_Pedido;
                command.Parameters.Add("@Id_Producto", OdbcType.VarChar);
                command.Parameters["@Id_Producto"].Value = pedido.Id_Producto;
                command.Parameters.Add("@Cant_Solicitada", OdbcType.Decimal);
                command.Parameters["@Cant_Solicitada"].Value = pedido.Cant_Solicitada;
                command.Parameters.Add("@Precio_Unitario", OdbcType.Decimal);
                command.Parameters["@Precio_Unitario"].Value = pedido.Precio_Unitario;//Usuario Logueado
                command.Parameters.Add("@Subtotal", OdbcType.Decimal);
                command.Parameters["@Subtotal"].Value = pedido.Subtotal;

                command.ExecuteNonQuery();

                command.Dispose();

                return "true";

            }
            catch (Exception ax)
            {

                return "false";
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
        //Eliminar

        public static string EliminarPedidoLinea(PedidoLineaModel pedido)
        {
            OdbcConnection conn = Conexion.obtenerConexion();
            try
            {
                OdbcCommand command = new OdbcCommand();
                string Sql = "{call [sp_Eliminar_Pedido_Linea](?,?)}";

                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = Sql;
                command.Connection = conn;

                command.Parameters.Add("@Id_Pedido", OdbcType.VarChar);
                command.Parameters["@Id_Pedido"].Value = pedido.Id_Pedido;
                command.Parameters.Add("@Id_Producto", OdbcType.VarChar);
                command.Parameters["@Id_Producto"].Value = pedido.Id_Producto;

                command.ExecuteNonQuery();

                command.Dispose();

                return "true";

            }
            catch (Exception ax)
            {

                return "false";
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
    }
}