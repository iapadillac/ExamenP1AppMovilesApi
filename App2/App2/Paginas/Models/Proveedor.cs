using System;
using System.Collections.Generic;
using System.Text;

namespace App2.Paginas.Models
{
    internal class Proveedor
    {
        public string pro_cedula_ruc { get; set; }
        public string pro_nombre { get; set; }
        public string pro_direccion { get; set; }
        public string pro_ciudad { get; set; }
        public string pro_telefono { get; set; }
        public string pro_correo { get; set; }
        public bool? pro_credito_contado { get; set; }
        public bool? pro_estado { get; set; }

    }
}
