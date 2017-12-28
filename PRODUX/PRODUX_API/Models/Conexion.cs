using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Odbc;
using System.Linq;
using System.Web;

namespace API_PRODUX.Models
{
    public class Conexion
    {
        public static string obtenerString()
        {
            return ConfigurationManager.ConnectionStrings["Connection"].ConnectionString;
        }


        public static OdbcConnection obtenerConexion()
        {
            OdbcConnection conn = new OdbcConnection();
            try
            {
                conn = new OdbcConnection(obtenerString());
                conn.ConnectionTimeout = 0;

            }
            catch (OdbcException ax)
            {
                throw new ApplicationException("Error en Base de Datos..! \n" + ax.Message);
            }
            finally
            {
                conn.Open();
            }

            return conn;
        }
    }
}
