//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HEAPIFY_540_Software.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class AdjustmentCode
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AdjustmentCode()
        {
            this.Billings = new HashSet<Billing>();
        }
    
        public int AdjustmentCodeID { get; set; }
        public string AdjustmentDescription { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Billing> Billings { get; set; }
    }
}
