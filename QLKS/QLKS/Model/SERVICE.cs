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
    
    public partial class SERVICE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SERVICE()
        {
            this.RENTALDETAILs = new HashSet<RENTALDETAIL>();
        }
    
        public int IdService { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public Nullable<int> IdCategoryService { get; set; }
    
        public virtual CATEGORY_SERVICE CATEGORY_SERVICE { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RENTALDETAIL> RENTALDETAILs { get; set; }
    }
}