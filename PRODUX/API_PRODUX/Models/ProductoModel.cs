﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Linq;
using System.Web;

namespace API_PRODUX.Models
{
    public class ProductoModel
    {
        public ProductoModel() { }

        public string Codigo { get; set; }

        public string Descripcion { get; set; }

        public double Precio { get; set; }

        public int CantidadInventario { get; set; }

        public int Estado { get; set; }

        public string Observaciones { get; set; }

        public string Imagen { get; set; }

        public string Usuario_Creacion { get; set; }


        //Lista


        public static List<ProductoModel> SeleccionarProductos()
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

                List<ProductoModel> lista = new List<ProductoModel>();
                while (reader.Read())
                {
                    ProductoModel Producto = new ProductoModel();

                    Producto.Codigo = reader["Id_Producto"].ToString();
                    Producto.Descripcion = reader["Descripcion"].ToString();
                    Producto.Precio = Convert.ToDouble(reader["Precio"].ToString());
                    Producto.CantidadInventario = Convert.ToInt32(reader["Cant_Inventario"].ToString());
                    Producto.Observaciones = reader["Observaciones"].ToString();
                    Producto.Imagen = reader["Imagen"].ToString();
                    Producto.Estado = Convert.ToInt32(reader["Estado"].ToString());
                    lista.Add(Producto);
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

        public static List<ProductoModel> SeleccionarProductoPorCodigo(string IdProducto)
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
                command.Parameters["@Id_Producto"].Value = IdProducto;

                OdbcDataReader reader = command.ExecuteReader();

                List<ProductoModel> lista = new List<ProductoModel>();

                while (reader.Read())
                {

                    ProductoModel Producto = new ProductoModel();
                    Producto.Codigo = reader["Id_Producto"].ToString();
                    Producto.Descripcion = reader["Descripcion"].ToString();
                    Producto.Precio = Convert.ToDouble(reader["Precio"].ToString());
                    Producto.CantidadInventario = Convert.ToInt32(reader["Cant_Inventario"].ToString());
                    Producto.Observaciones = reader["Observaciones"].ToString();
                    Producto.Imagen = reader["Imagen"].ToString();
                    Producto.Estado = Convert.ToInt32(reader["Estado"].ToString());
                    lista.Add(Producto);
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

        public static string InsertarProducto(ProductoModel producto)
        {
            OdbcConnection conn = Conexion.obtenerConexion();
            try
            {
                OdbcCommand command = new OdbcCommand();
                string Sql = "{call [dbo].[sp_Insertar_Producto](?,?,?,?,?,?,?,?)}";

                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = Sql;
                command.Connection = conn;

                command.Parameters.Add("@Id_Producto", OdbcType.VarChar);
                command.Parameters["@Id_Producto"].Value = producto.Codigo;
                command.Parameters.Add("@Descripcion", OdbcType.VarChar);
                command.Parameters["@Descripcion"].Value = producto.Descripcion;
                command.Parameters.Add("@Precio", OdbcType.Decimal);
                command.Parameters["@Precio"].Value = producto.Precio;
                command.Parameters.Add("@Cant_Inventario", OdbcType.Int);
                command.Parameters["@Cant_Inventario"].Value = producto.CantidadInventario;//Usuario Logueado
                command.Parameters.Add("@Observaciones", OdbcType.VarChar);
                command.Parameters["@Observaciones"].Value = producto.Observaciones;
                command.Parameters.Add("@Imagen", OdbcType.VarChar);
                command.Parameters["@Imagen"].Value = producto.Imagen;
                command.Parameters.Add("@Estado", OdbcType.Int);
                command.Parameters["@Estado"].Value = producto.Estado;
                command.Parameters.Add("@Usuario_Creacion", OdbcType.VarChar);
                command.Parameters["@Usuario_Creacion"].Value = producto.Usuario_Creacion;
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
        public static string ActualizarProducto(ProductoModel producto)
        {
            OdbcConnection conn = Conexion.obtenerConexion();
            try
            {
                OdbcCommand command = new OdbcCommand();
                string Sql = "{call [dbo].[sp_Actualizar_Producto](?,?,?,?,?,?,?)}";

                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = Sql;
                command.Connection = conn;

                command.Parameters.Add("@Id_Producto", OdbcType.VarChar);
                command.Parameters["@Id_Producto"].Value = producto.Codigo;
                command.Parameters.Add("@Descripcion", OdbcType.VarChar);
                command.Parameters["@Descripcion"].Value = producto.Descripcion;
                command.Parameters.Add("@Precio", OdbcType.Decimal);
                command.Parameters["@Precio"].Value = producto.Precio;
                command.Parameters.Add("@Cant_Inventario", OdbcType.Int);
                command.Parameters["@Cant_Inventario"].Value = producto.CantidadInventario;//Usuario Logueado
                command.Parameters.Add("@Observaciones", OdbcType.VarChar);
                command.Parameters["@Observaciones"].Value = producto.Observaciones;
                command.Parameters.Add("@Imagen", OdbcType.VarChar);
                command.Parameters["@Imagen"].Value = producto.Imagen;
                command.Parameters.Add("@Estado", OdbcType.Int);
                command.Parameters["@Estado"].Value = producto.Estado;
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

        public static string EliminarProducto(ProductoModel producto)
        {
            OdbcConnection conn = Conexion.obtenerConexion();
            try
            {
                OdbcCommand command = new OdbcCommand();
                string Sql = "{call [sp_Eliminar_Producto](?)}";

                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = Sql;
                command.Connection = conn;

                command.Parameters.Add("@Id_Producto", OdbcType.VarChar);
                command.Parameters["@Id_Producto"].Value = producto.Codigo;

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
