using System;
using System.Collections.Generic;
using System.Text;

namespace PRODUX.Model
{
    public class ClienteModel
    {
        public ClienteModel() { }

        #region Propiedades

        public string Cedula { get; set; }

        public string Nombre { get; set; }

        public string Telefono { get; set; }

        public string Email { get; set; }

        public int Estado { get; set; }

        public string Direccion { get; set; }

        public string Usuario_Creacion { get; set; }

        public DateTime Fecha_Creacion { get; set; }

        #endregion

        #region Métodos

        #endregion
    }
}
