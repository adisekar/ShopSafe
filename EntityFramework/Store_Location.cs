//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ShopSafe_Web.EntityFramework
{
    using System;
    using System.Collections.Generic;
    
    public partial class Store_Location
    {
        public int Store_Id { get; set; }
        public int Location_Id { get; set; }
        public int Capacity_Id { get; set; }
        public string UserName { get; set; }
        public int Current_Capacity { get; set; }
    
        public virtual Capacity Capacity { get; set; }
    }
}
