using System;
using System.Collections.Generic;
using System.Text;

namespace MiPrimeraApp.Clases
{
    public class ClsProducto
    {
        public int IdProducto { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public int IdCategoria { get; set; }
        public string NombreCategoria { get; set; }
        public int IdMarca { get; set; }
        public string NombreMarca { get; set; }
    }
}
