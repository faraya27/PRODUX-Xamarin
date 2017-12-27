﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Linq;
using System.Web;

namespace API_PRODUX.Models
{
    public class PedidoModel
    {
        public PedidoModel() { }

        public string Id_Pedido { get; set; }

        public DateTime Fecha { get; set; }

        public string Cliente { get; set; }

        public string Unidad { get; set; }
        public string Estado { get; set; }

        public double TotalPedido { get; set; }
        public string Id_Producto { get; set; }
        public double Cant_Solicitada { get; set; }
        public double Precio_Unitario { get; set; }
        public double Subtotal { get; set; }

        public string Usuario_Confirmacion { get; set; }
        public string Usuario_Creacion { get; set; }

        //Lista


        public List<PedidoModel> SeleccionarProductos()
        {
            OdbcConnection conn = Conexion.obtenerConexion();

            try
            {
                OdbcCommand command = new OdbcCommand();
                string Sql = "{call [dbo].[sp_Seleccionar_Productos]}";

                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = Sql;
                command.Connection = conn;

                OdbcDataReader reader = command.ExecuteReader();

                List<PedidoModel> lista = new List<PedidoModel>();
                while (reader.Read())
                {
                    PedidoModel pedido = new PedidoModel();

                    pedido.Id_Pedido = reader["Id_Pedido"].ToString();
                    pedido.Fecha = Convert.ToDateTime(reader["Fecha"].ToString());
                    pedido.Cliente = reader["Cliente"].ToString();
                    pedido.TotalPedido = Convert.ToInt32(reader["Total"].ToString());
                    pedido.Estado = reader["Estado"].ToString();
                    pedido.Usuario_Confirmacion = reader["Usuario_Confirmacion"].ToString();
                    pedido.Usuario_Creacion = reader["Usuario_Creacion"].ToString();
                    lista.Add(pedido);
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

        public List<PedidoModel> SeleccionarProductoPorCodigo(string IdPedido)
        {
            OdbcConnection conn = Conexion.obtenerConexion();

            try
            {
                OdbcCommand command = new OdbcCommand();
                string Sql = "{call [dbo].[sp_Seleccionar_Producto_Por_Codigo](?)}";

                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = Sql;
                command.Connection = conn;

                command.Parameters.Add("@Id_Producto", OdbcType.VarChar);
                command.Parameters["@Id_Producto"].Value = IdPedido;

                OdbcDataReader reader = command.ExecuteReader();

                List<PedidoModel> lista = new List<PedidoModel>();

                while (reader.Read())
                {

                    PedidoModel pedido = new PedidoModel();

                    pedido.Id_Pedido = reader["Id_Pedido"].ToString();
                    pedido.Fecha = Convert.ToDateTime(reader["Fecha"].ToString());
                    pedido.Cliente = reader["Cliente"].ToString();
                    pedido.TotalPedido = Convert.ToInt32(reader["Total"].ToString());
                    pedido.Estado = reader["Estado"].ToString();
                    pedido.Usuario_Confirmacion = reader["Usuario_Confirmacion"].ToString();
                    pedido.Usuario_Creacion = reader["Usuario_Creacion"].ToString();
                    lista.Add(pedido);
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

        public void InsertarProducto(PedidoModel pedido)
        {
            OdbcConnection conn = Conexion.obtenerConexion();
            try
            {
                OdbcCommand command = new OdbcCommand();
                string Sql = "{call [dbo].[sp_Insertar_Pedido](?,?,?,?,?,?,?)}";

                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = Sql;
                command.Connection = conn;

                command.Parameters.Add("@Id_Pedido", OdbcType.VarChar);
                command.Parameters["@Id_Pedido"].Value = pedido.Id_Pedido;
                command.Parameters.Add("@Fecha", OdbcType.VarChar);
                command.Parameters["@Fecha"].Value = pedido.Fecha;
                command.Parameters.Add("@Cliente", OdbcType.Decimal);
                command.Parameters["@Cliente"].Value = pedido.Cliente;
                command.Parameters.Add("@Total", OdbcType.Decimal);
                command.Parameters["@Total"].Value = pedido.TotalPedido;//Usuario Logueado
                command.Parameters.Add("@Estado", OdbcType.Int);
                command.Parameters["@Estado"].Value = pedido.Estado;
                command.Parameters.Add("@Usuario_Confirmacion", OdbcType.VarChar);
                command.Parameters["@Usuario_Confirmacion"].Value = pedido.Usuario_Confirmacion;
                command.Parameters.Add("@Usuario_Creacion", OdbcType.Int);
                command.Parameters["@Usuario_Creacion"].Value = pedido.Usuario_Creacion;
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
        public void ActualizarProducto(PedidoModel pedido)
        {
            OdbcConnection conn = Conexion.obtenerConexion();
            try
            {
                OdbcCommand command = new OdbcCommand();
                string Sql = "{call [dbo].[sp_Actualizar_Pedido](?,?,?,?,?,?)}";

                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = Sql;
                command.Connection = conn;

                command.Parameters.Add("@Id_Pedido", OdbcType.VarChar);
                command.Parameters["@Id_Pedido"].Value = pedido.Id_Pedido;
                command.Parameters.Add("@Fecha", OdbcType.VarChar);
                command.Parameters["@Fecha"].Value = pedido.Fecha;
                command.Parameters.Add("@Cliente", OdbcType.Decimal);
                command.Parameters["@Cliente"].Value = pedido.Cliente;
                command.Parameters.Add("@Total", OdbcType.Decimal);
                command.Parameters["@Total"].Value = pedido.TotalPedido;//Usuario Logueado
                command.Parameters.Add("@Estado", OdbcType.Int);
                command.Parameters["@Estado"].Value = pedido.Estado;
                command.Parameters.Add("@Usuario_Confirmacion", OdbcType.VarChar);
                command.Parameters["@Usuario_Confirmacion"].Value = pedido.Usuario_Confirmacion;
               
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
        //Eliminar

        public void EliminarProducto(PedidoModel pedido)
        {
            OdbcConnection conn = Conexion.obtenerConexion();
            try
            {
                OdbcCommand command = new OdbcCommand();
                string Sql = "{call [sp_Eliminar_Pedido](?)}";

                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = Sql;
                command.Connection = conn;

                command.Parameters.Add("@Id_Pedido", OdbcType.VarChar);
                command.Parameters["@Id_Pedido"].Value = pedido.Id_Pedido;

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

        public void ConfirmarPedido(PedidoModel pedido)
        {
            OdbcConnection conn = Conexion.obtenerConexion();
            try
            {
                OdbcCommand command = new OdbcCommand();
                string Sql = "{call [dbo].[sp_Confirmar_Pedido](?,?,?)}";

                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = Sql;
                command.Connection = conn;

                command.Parameters.Add("@Id_Pedido", OdbcType.VarChar);
                command.Parameters["@Id_Pedido"].Value = pedido.Id_Pedido;
                command.Parameters.Add("@Estado", OdbcType.Int);
                command.Parameters["@Estado"].Value = pedido.Estado;
                command.Parameters.Add("@Usuario_Confirmacion", OdbcType.VarChar);
                command.Parameters["@Usuario_Confirmacion"].Value = pedido.Usuario_Confirmacion;

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
        //Confirmar
