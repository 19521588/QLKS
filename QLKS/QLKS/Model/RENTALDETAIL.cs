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
    
    public partial class RENTALDETAIL
    {
        public int IdRentalDetail { get; set; }
        public int IdRental { get; set; }
        public int IdService { get; set; }
        public int Amount { get; set; }
        public int Total { get; set; }
    
        public virtual RENTAL RENTAL { get; set; }
        public virtual SERVICE SERVICE { get; set; }
    }
}
