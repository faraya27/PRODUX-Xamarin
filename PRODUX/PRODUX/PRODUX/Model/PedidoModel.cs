using System;
using System.Collections.Generic;
using System.Text;

namespace PRODUX.Model
{
    public class PedidoModel
    {
        public PedidoModel() { }

        public string Numero { get; set; }

        public DateTime Fecha { get; set; }

        public ClienteModel Cliente { get; set; }

        public UsuarioModel Unidad { get; set; }

        public double TotalPedido { get; set; }
    }
}
