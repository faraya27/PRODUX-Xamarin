using System;
using System.Collections.Generic;
using System.Text;

namespace PRODUX.Model
{
    public class ClienteModel
    {
        public ClienteModel() { }

        public string Cedula { get; set; }

        public string Nombre { get; set; }

        public string Telefono { get; set; }

        public string Email { get; set; }

        public bool Estado { get; set; }

        public string Direccion { get; set; }
    }
}
