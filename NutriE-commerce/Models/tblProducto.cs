//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NutriE_commerce.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblProducto
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblProducto()
        {
            this.tblVenta = new HashSet<tblVenta>();
        }
    
        public int proId { get; set; }
        public Nullable<int> catId { get; set; }
        public string proCodigo { get; set; }
        public string proNombre { get; set; }
        public Nullable<int> proStock { get; set; }
        public string proDesc { get; set; }
        public Nullable<decimal> proPrecio { get; set; }
        public string proObser { get; set; }
        public Nullable<System.DateTime> proFecha { get; set; }
        public string proEstado { get; set; }
    
        public virtual tblCategoria tblCategoria { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblVenta> tblVenta { get; set; }
    }
}
