//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AppSerWEB.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class DEtalleDEvolucion
    {
        public int Codigo { get; set; }
        public int CodigoDevolucion { get; set; }
        public int CodigoProducto { get; set; }
        public int Cantidad { get; set; }
        public int ValorUnitario { get; set; }
    
        public virtual DEVOlucion DEVOlucion { get; set; }
    }
}
