using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PRODUX_API.Models
{
    public class ProductoModel
    {
        public ProductoModel() { }

        public string Codigo { get; set; }

        public string Descripcion { get; set; }

        public double Precio { get; set; }

        public double CantidadInventario { get; set; }

        public bool Estado { get; set; }

        public string Observaciones { get; set; }

        public string Imagen { get; set; }


        //Lista
        //Por codigo
        //insertar
        //Modificar
        //Eliminar
    }
}