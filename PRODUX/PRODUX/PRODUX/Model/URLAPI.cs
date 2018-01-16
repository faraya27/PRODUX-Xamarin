using System;
using System.Collections.Generic;
using System.Text;

namespace PRODUX.Model
{
    public class URLAPI
    {
        private static string URLRaiz = "http://192.168.1.139";

        public static string Usuario()
        {
            return URLRaiz + "/api/usuario/";
        }

        public static string Cliente()
        {
            return URLRaiz + "/api/cliente/";
        }

        public static string Producto()
        {
            return URLRaiz + "/api/producto/";
        }

        public static string Pedido()
        {
            return URLRaiz + "/api/pedido/";
        }

        public static string PedidoLinea()
        {
            return URLRaiz + "/api/pedidolinea/";
        }
    }
}
