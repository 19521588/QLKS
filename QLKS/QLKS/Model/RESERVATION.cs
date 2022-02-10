//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QLKS.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class RESERVATION
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RESERVATION()
        {
            this.RENTALs = new HashSet<RENTAL>();
        }
    
        public int IdReservation { get; set; }
        public int IdEmployee { get; set; }
        public int IdCustomer { get; set; }
        public Nullable<int> Date { get; set; }
        public int IdReservationDetail { get; set; }
        public int IdRoom { get; set; }
    
        public virtual CUSTOMER CUSTOMER { get; set; }
        public virtual EMPLOYEE EMPLOYEE { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RENTAL> RENTALs { get; set; }
        public virtual RESERVATION_DETAIL RESERVATION_DETAIL { get; set; }
        public virtual ROOM ROOM { get; set; }
    }
}
