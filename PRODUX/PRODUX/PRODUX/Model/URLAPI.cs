using System;
using System.Collections.Generic;
using System.Text;

namespace PRODUX.Model
{
    public class URLAPI
    {
        private static string URLRaiz = "https://9f3c01d9.ngrok.io";

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
