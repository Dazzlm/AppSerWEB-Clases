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
    
    public partial class DEVOlucion
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DEVOlucion()
        {
            this.DEtalleDEvolucions = new HashSet<DEtalleDEvolucion>();
        }
    
        public int Codigo { get; set; }
        public string Documento { get; set; }
        public int NumeroFactura { get; set; }
        public System.DateTime Fecha { get; set; }
        public int CodigoEmpleado { get; set; }
        [JsonIgnore]

        public virtual CLIEnte CLIEnte { get; set; }
        [JsonIgnore]

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DEtalleDEvolucion> DEtalleDEvolucions { get; set; }
        [JsonIgnore]

        public virtual EMpleadoCArgo EMpleadoCArgo { get; set; }
    }
}
