//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace product_api.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class coffee
    {
        public int id { get; set; }
        public string name { get; set; }
        public string teaser { get; set; }
        public string description { get; set; }
        public int price { get; set; }
        public string image { get; set; }
        public System.DateTime created_at { get; set; }
        public System.DateTime updated_at { get; set; }
        public Nullable<System.DateTime> deleted_at { get; set; }
    }
}
