//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SyncThinkTechnology.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Stock
    {
        public Stock()
        {
            this.Orders = new HashSet<Order>();
        }
    
        public int Quantity { get; set; }
        public int ProductId { get; set; }
        public int ProductBarcode { get; set; }
    
        public virtual ICollection<Order> Orders { get; set; }
        public virtual Product Product { get; set; }
    }
}
