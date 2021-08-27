using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MiniMarketPresentacion.Models
{
    public class Producto
    {
        public int id { get; set; }
        public string descripcion { get; set; }
        public string medidas { get; set; }
        public int cantidad { get; set; }
        public decimal precio { get; set; }
    
    }
}