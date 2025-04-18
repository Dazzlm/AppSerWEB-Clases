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
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    
    public partial class FActuraCOmpra
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FActuraCOmpra()
        {
            this.DEtalleFacturaCompras = new HashSet<DEtalleFacturaCompra>();
        }
    
        public int Codigo { get; set; }
        public int CodigoEmpleado { get; set; }
        public string DocumentoProveedor { get; set; }
        public System.DateTime Fecha { get; set; }
        public System.DateTime FechaPago { get; set; }
        [JsonIgnore]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

        public virtual ICollection<DEtalleFacturaCompra> DEtalleFacturaCompras { get; set; }
        [JsonIgnore]

        public virtual EMpleadoCArgo EMpleadoCArgo { get; set; }
        [JsonIgnore]

        public virtual PROVeedor PROVeedor { get; set; }
    }
}
